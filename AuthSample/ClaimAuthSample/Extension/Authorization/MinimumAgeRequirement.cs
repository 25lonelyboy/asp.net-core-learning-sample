using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClaimAuthSample.Extension.Authorization
{
    public class MinimumAgeRequirement : AuthorizationHandler<MinimumAgeRequirement>, IAuthorizationRequirement
    {
        public int MinimumAge { get; set; }

        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            MinimumAgeRequirement requirement)
        {
            if (context.User != null)
            {
                if (context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "demo"))
                {
                    var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);
                    var caculateAge = DateTime.Today.Year - dateOfBirth.Year;
                    if (caculateAge >= requirement.MinimumAge)
                    {
                        //该方法无需返回值，通过context.Succeed()通知判断成功
                        context.Succeed(requirement);
                    }
                }
            }
            //通知context判断失败，若执行以下语句，则后续MinimumAgeRequirement相关的Handler不会再执行
            //若没有以下语句，则此Handler判断失败，其他Handler任会执行，当所有Handler都判断失败，才判断失败。
            //context.Fail();
            return Task.CompletedTask;
        }
    }
}
