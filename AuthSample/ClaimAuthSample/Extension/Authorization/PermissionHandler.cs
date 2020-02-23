using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimAuthSample.Extension.Authorization
{
    public class PermissionHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            //一个Handler也可以处理多个条件
            //可通过context拿到条件集合
            var requirements = context.Requirements;
            foreach(var requirement in requirements)
            {
                //再做相应的处理
                if(requirement is MinimumAgeRequirement)
                {
                    //...
                }
            }
            return Task.CompletedTask;
        }
    }
}
