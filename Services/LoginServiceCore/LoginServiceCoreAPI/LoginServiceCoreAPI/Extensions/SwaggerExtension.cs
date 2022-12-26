using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace LoginServiceCoreAPI.Extensions
{
    public static class SwaggerExtension
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app, bool IsDevelopmentEnvirment)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                if (IsDevelopmentEnvirment)
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Login Service");
                }
                else
                {
                    c.SwaggerEndpoint("/LoginService/swagger/v1/swagger.json", "Login Service");
                }
            });
        }
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "UPI Architecture - WebApi",
                    Description = "This Api will be responsible for overall data distribution and authorization.",
                    Contact = new OpenApiContact
                    {
                        Name = "FinoPay",
                        Email = "info@finopay.com",
                        Url = new Uri("https://www.google.com"),
                    }
                });

                //c.OperationFilter<FileUploadOperation>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });
            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });

            //services.AddVersionedApiExplorer(options =>
            //{
            //    // add the versioned api explorer , Which also adds IApiVersionedApiExplorer service
            //    // note: the specification format code will format the version as "'v'major[.minor][-status]"
            //    options.GroupNameFormat = "'v'VVV";


            //    //note: this option is only necessary when versioning by url segment. the SubstitutionFormat
            //    // can also be used to control the format of the API version in route templates
            //    options.SubstituteApiVersionInUrl = true;

            //});

        }
    }
}
