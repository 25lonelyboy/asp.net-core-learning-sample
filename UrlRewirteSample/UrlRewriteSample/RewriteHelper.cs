using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlRewriteSample
{
    public class RewriteHelper
    {
        /// <summary>
        /// 重定向
        /// </summary>
        /// <param name="context"></param>
        public static void RedirectUrl(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            //避免死循环
            if (request.Path.StartsWithSegments(new PathString("/xmlFile")))
            {
                return;
            }
            
            if (request.Path.Value.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            {
                var response = context.HttpContext.Response;
                context.Result = RuleResult.EndResponse;
                //使用微软已定义的枚举类型
                response.StatusCode = StatusCodes.Status301MovedPermanently;
                response.Headers[HeaderNames.Location] = "/xmlFile" + request.Path + request.QueryString;
            }

        }

        /// <summary>
        ///  重写
        /// </summary>
        /// <param name="context"></param>
        public static void RewriteUrl(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            if(request.Path.Value.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                //将请求传递給下一个中间件，继续执行
                context.Result = RuleResult.SkipRemainingRules;
                //修改请求路径，使请求对应到其他的路径，即是重写
                //重写中间件应该在前面，直接拦截请求，不请求原来的地址，使其请求其他地址
                request.Path = "/flie.txt";
            }
        }
    }
}
