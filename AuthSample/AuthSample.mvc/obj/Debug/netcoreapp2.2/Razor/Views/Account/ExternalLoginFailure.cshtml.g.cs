#pragma checksum "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Account\ExternalLoginFailure.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "038b3690aaa10c6b6681f253057a3be7d358a177"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ExternalLoginFailure), @"mvc.1.0.view", @"/Views/Account/ExternalLoginFailure.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/ExternalLoginFailure.cshtml", typeof(AspNetCore.Views_Account_ExternalLoginFailure))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\_ViewImports.cshtml"
using AuthSample.mvc;

#line default
#line hidden
#line 2 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\_ViewImports.cshtml"
using AuthSample.mvc.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"038b3690aaa10c6b6681f253057a3be7d358a177", @"/Views/Account/ExternalLoginFailure.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e77d20d43ac996cd630d7df84c2464ec11f74d82", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ExternalLoginFailure : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Account\ExternalLoginFailure.cshtml"
  
    ViewData["Title"] = "Login Failure";

#line default
#line hidden
            BeginContext(49, 20, true);
            WriteLiteral("\r\n<header>\r\n    <h1>");
            EndContext();
            BeginContext(70, 17, false);
#line 6 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Account\ExternalLoginFailure.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(87, 84, true);
            WriteLiteral(".</h1>\r\n    <p class=\"text-danger\">Unsuccessful login with service.</p>\r\n</header>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591