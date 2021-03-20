﻿using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Viajes365RestApi.Extensions
{
    public class AuthorizationAttribute : TypeFilterAttribute
    {
        private readonly string _actionName = string.Empty;

        public AuthorizationAttribute(string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { new Claim(_actionName, claimValue) };
        }

        public class ClaimRequirementFilter : IAsyncActionFilter
        {
            private readonly Claim _claim;

            public ClaimRequirementFilter(Claim claim)
            {
                _claim = claim;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var permission = _claim.Value;
                // just one role for user in this viajes 365 project
                var rolesString = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Role")?.Value;
                if (rolesString != null)
                {
                    var rolesList = rolesString.Split(',').ToArray();
                    bool hasPermission = rolesList.Contains(permission);
                    if (hasPermission)
                    {
                        await next();
                    }
                    else
                    {
                        if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                        {
                            await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { statuscode = HttpStatusCode.Forbidden, message = $"You are not authorized to use this function." }));
                            context.Result = new EmptyResult();
                        }
                        else
                        {
                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { statuscode = HttpStatusCode.Unauthorized, message = "Role: " + rolesString + $" is not authorized." }));
           
                        }
                    }
                }
                else
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
            }
        }
    }
}
