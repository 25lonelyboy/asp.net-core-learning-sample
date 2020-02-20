using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceAuthorizeSample.Extensions
{
    /// <summary>
    /// 定义授权条件，授权机制是以条件和处理程序为核心的
    /// 通过这两者进行权限的判断，我们也是通过自定义这两者尽快自己的授权业务扩展
    /// </summary>
    public class OperationAuthorizationRequirement : IAuthorizationRequirement
    {
        public string Name { get; set; }

    }
}
