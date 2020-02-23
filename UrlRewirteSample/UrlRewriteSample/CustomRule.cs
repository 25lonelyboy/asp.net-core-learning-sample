using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlRewriteSample
{
    public class CustomRule : IRule
    {
        public void ApplyRule(RewriteContext context)
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
    }
}
