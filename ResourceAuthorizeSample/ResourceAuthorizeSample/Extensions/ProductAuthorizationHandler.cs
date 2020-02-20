using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using ResourceAuthorizeSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceAuthorizeSample.Extensions
{
    /// <summary>
    /// 授权机制是以条件和处理程序为核心的
    /// 通过这两者进行权限的判断，我们也是通过自定义这两者尽快自己的授权业务扩展
    /// </summary>
    public class ProductAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Product>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Product resource)
        {
            if(context.User.IsInRole("admin"))
            {
                context.Succeed(requirement);
            }
            else 
            {
                //根据用户获取对于的操作权限
                //模拟根据用户、资源，从数据库获取对于的操作权限
                var requirements = new OperationAuthorizationRequirement[] { Operation.Create, Operation.Read, Operation.Delete };
                //判断当前操作是否有权限
                if (requirements.Contains(requirement))
                {
                    //不同的操作有不同的逻辑
                    if (requirement == Operation.Create && requirement == Operation.Read)
                    {
                        context.Succeed(requirement);
                    }
                    else
                    {
                        //删除、修改操作，需要是资源拥有者
                        if(context.User.Identity.Name == resource.Creator)
                        {
                            context.Succeed(requirement);
                        }
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
