using AspNet.Attributes.Model;
using Common.Wrappers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using Utility.Extensions;


namespace AspNet.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : FlagsAttribute, IAuthorizationFilter
    {

        public AuthorizeAttribute()
        {

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (Response<AuthenticationResponse>)context.HttpContext.Items["User"];
            if (user == null)
            {

                var result = new Response<string>("You are not Authorized").ToJsonSerialize();
                // not logged in or role not authorized
                //context.Result = new JsonResult(result) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            //else if (user.Data == null || (_roles.Any() && !_roles.Contains(Enum.Parse<Roles>(user?.Data.Roles?[0]))))
            //{
            //    var result = JsonConvert.SerializeObject(new Response<string>("You are not Authorized"));
            //    // not logged in or role not authorized
            //    context.Result = new JsonResult(result) { StatusCode = StatusCodes.Status401Unauthorized };
            //}
        }
    }
}
