using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace makeITconvenient.InitialConf
{
    public class RoleAuthorizationFilter : IAuthorizationFilter
    {
        private readonly string _role;

        public RoleAuthorizationFilter(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.IsInRole(_role))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "AccessDenied"
                }));
            }
        }
    }
}
