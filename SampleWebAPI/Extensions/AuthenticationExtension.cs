using Common.Wrappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Utility.Extensions;

namespace Sample.API.Extensions
{
    public static class AuthenticationExtension
    {
        public static void AddAuthentication(this IServiceCollection services, IConfiguration _config)
        {
            var tokenkey = _config.GetValue<string>("AppSettings:Secret");
            var key = Encoding.ASCII.GetBytes(tokenkey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x =>
             {

                 x.RequireHttpsMetadata = false;
                 x.SaveToken = false;
                 x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.Zero,
                     ValidIssuer = _config["JWTSettings:Issuer"],
                     ValidAudience = _config["JWTSettings:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:Key"]))
                 };
                 x.Events = new JwtBearerEvents()
                 {
                     OnAuthenticationFailed = c =>
                     {
                         c.NoResult();
                         c.Response.StatusCode = 500;
                         c.Response.ContentType = "text/plain";
                         return c.Response.WriteAsync(c.Exception.ToString());
                     },
                     OnChallenge = context =>
                     {
                         context.HandleResponse();
                         context.Response.StatusCode = 401;
                         context.Response.ContentType = "application/json";
                         var result = new Response<string>("You are not Authorized").ToJsonSerialize();
                         return context.Response.WriteAsync(result);
                     },
                     OnForbidden = context =>
                     {
                         context.Response.StatusCode = 403;
                         context.Response.ContentType = "application/json";
                         var result = new Response<string>("You are not authorized to access this resource").ToJsonSerialize();
                         return context.Response.WriteAsync(result);
                     }
                 };
             });
        }
    }
}
