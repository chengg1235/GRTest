using Niusys.WebAPI.Common.Dependency;
using Niusys.WebAPI.Common.Security;
using Niusys.WebAPI.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;

namespace Niusys.WebAPI.Common.Filters
{
    public class SessionValidateAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public const string SessionKeyName = "SessionKey";
        public const string LogonUserName = "LogonUser";

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            var qs = HttpUtility.ParseQueryString(filterContext.Request.RequestUri.Query);
            string sessionKey = qs[SessionKeyName];

            if (string.IsNullOrEmpty(sessionKey))
            {
                throw new ApiException("Invalid Session.", "InvalidSession");
            }

            IAuthenticationService authenticationService = IocManager.Intance.Reslove<IAuthenticationService>();

            //validate user session
            var userSession = authenticationService.GetUserDevice(sessionKey);

            if (userSession == null)
            {
                throw new ApiException("sessionKey not found", "RequireParameter_sessionKey");
            }
            else
            {
                //todo: 加Session是否过期的判断
                if (userSession.ExpiredTime < DateTime.UtcNow)
                    throw new ApiException("session expired", "SessionTimeOut");

                var logonUser = authenticationService.GetUser(userSession.UserId);
                if (logonUser == null)
                {
                    throw new ApiException("User not found", "Invalid_User");
                }
                else
                {
                    filterContext.ControllerContext.RouteData.Values[LogonUserName] = logonUser;
                    SetPrincipal(new UserPrincipal<int>(logonUser));
                }

                userSession.ActiveTime = DateTime.UtcNow;
                userSession.ExpiredTime = DateTime.UtcNow.AddMinutes(60);
                authenticationService.UpdateUserDevice(userSession);
            }
        }

        private void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}