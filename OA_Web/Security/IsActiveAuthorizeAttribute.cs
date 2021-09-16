using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using OA_Service.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_Web.Security
{
    public class IsActiveHandler : AuthorizationHandler<IsActiveRequirement>
    {
        private readonly AccountAppService _accountAppService;

        public IsActiveHandler(AccountAppService account)
        {
            _accountAppService = account;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsActiveRequirement requirement)
        {
            //var authFilterContext = context.Resource as AuthorizationFilterContext;
            //if (authFilterContext == null)
            //{
            //    return Task.CompletedTask;
            //}



            var user = _accountAppService.FindByEmail(context.User.Identity.Name);            

            if (context.User.Identity.IsAuthenticated && user.IsActive)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
        
    }
    public class NoDirectAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var canAcess = false;

            // check the refer
            var referer = filterContext.HttpContext.Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
            {
                var rUri = new System.UriBuilder(referer).Uri;
                var req = filterContext.HttpContext.Request;
                if (req.Host.Host == rUri.Host && req.Host.Port == rUri.Port && req.Scheme == rUri.Scheme)
                {
                    canAcess = true;
                }
            }

            // ... check other requirements

            if (!canAcess)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", area = "" }));
            }
        }
    }

}
