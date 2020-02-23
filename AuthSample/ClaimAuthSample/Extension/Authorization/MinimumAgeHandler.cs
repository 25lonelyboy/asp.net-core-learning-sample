using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClaimAuthSample.Extension.Authorization
{
    [Obsolete("这个类已经废弃，合并到了 MinimumAgeRequirement 中")]
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            MinimumAgeRequirement requirement)
        {
            if (context.User != null)
            { 
                if(context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "demo"))
                {
                    var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);
                    var caculateAge = DateTime.Today.Year - dateOfBirth.Year;
                    if (caculateAge >= requirement.MinimumAge)
                    {
                        //该方法无需返回值，通过context.Succeed()表示条件判断成功
                        context.Succeed(requirement);
                    }
                }
            }
            //Handler通常不需要处理失败，因为同一个授权条件可能有多个Handler，这个Handler判断失败，其他的可能成功
            //可通过context.Fail()表示条件判断失败，若显式调用以下语句，则后续MinimumAgeRequirement相关的Handler不会再执行
            //若没有以下语句，则此Handler判断失败，其他Handler任会执行，当所有Handler都判断失败，才判断失败。
            //context.Fail();
            return Task.CompletedTask;
        }
    }
}
