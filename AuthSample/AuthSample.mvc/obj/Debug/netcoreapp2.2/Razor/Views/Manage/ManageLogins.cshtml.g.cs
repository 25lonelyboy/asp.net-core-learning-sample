#pragma checksum "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b50ecbe059c0f76a81c04082cf628cbf08dea7d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manage_ManageLogins), @"mvc.1.0.view", @"/Views/Manage/ManageLogins.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Manage/ManageLogins.cshtml", typeof(AspNetCore.Views_Manage_ManageLogins))]
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
#line 1 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
using AuthSample.mvc.Models.ManageViewModels;

#line default
#line hidden
#line 3 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b50ecbe059c0f76a81c04082cf628cbf08dea7d1", @"/Views/Manage/ManageLogins.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e77d20d43ac996cd630d7df84c2464ec11f74d82", @"/Views/_ViewImports.cshtml")]
    public class Views_Manage_ManageLogins : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ManageLoginsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "LoginProvider", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "ProviderKey", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveLogin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "LinkLogin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
  
    ViewData["Title"] = "Manage your external logins";

#line default
#line hidden
            BeginContext(184, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(191, 17, false);
#line 8 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(208, 34, true);
            WriteLiteral(".</h1>\r\n\r\n<p class=\"text-success\">");
            EndContext();
            BeginContext(243, 25, false);
#line 10 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
                   Write(ViewData["StatusMessage"]);

#line default
#line hidden
            EndContext();
            BeginContext(268, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 11 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
 if (Model.CurrentLogins.Count > 0)
{

#line default
#line hidden
            BeginContext(314, 76, true);
            WriteLiteral("    <h4>Registered Logins</h4>\r\n    <table class=\"table\">\r\n        <tbody>\r\n");
            EndContext();
#line 16 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
             for (var index = 0; index < Model.CurrentLogins.Count; index++)
            {

#line default
#line hidden
            BeginContext(483, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(530, 46, false);
#line 19 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
                   Write(Model.CurrentLogins[index].ProviderDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(576, 33, true);
            WriteLiteral("</td>\r\n                    <td>\r\n");
            EndContext();
#line 21 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
                         if ((bool)ViewData["ShowRemoveButton"])
                        {

#line default
#line hidden
            BeginContext(702, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(730, 677, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b50ecbe059c0f76a81c04082cf628cbf08dea7d19192", async() => {
                BeginContext(835, 77, true);
                WriteLiteral("\r\n                                <div>\r\n                                    ");
                EndContext();
                BeginContext(912, 96, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b50ecbe059c0f76a81c04082cf628cbf08dea7d19651", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 25 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.CurrentLogins[index].LoginProvider);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1008, 38, true);
                WriteLiteral("\r\n                                    ");
                EndContext();
                BeginContext(1046, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b50ecbe059c0f76a81c04082cf628cbf08dea7d111755", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 26 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.CurrentLogins[index].ProviderKey);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1138, 97, true);
                WriteLiteral("\r\n                                    <input type=\"submit\" class=\"btn btn-default\" value=\"Remove\"");
                EndContext();
                BeginWriteAttribute("title", " title=\"", 1235, "\"", 1326, 7);
                WriteAttributeValue("", 1243, "Remove", 1243, 6, true);
                WriteAttributeValue(" ", 1249, "this", 1250, 5, true);
#line 27 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
WriteAttributeValue(" ", 1254, Model.CurrentLogins[index].ProviderDisplayName, 1255, 47, false);

#line default
#line hidden
                WriteAttributeValue(" ", 1302, "login", 1303, 6, true);
                WriteAttributeValue(" ", 1308, "from", 1309, 5, true);
                WriteAttributeValue(" ", 1313, "your", 1314, 5, true);
                WriteAttributeValue(" ", 1318, "account", 1319, 8, true);
                EndWriteAttribute();
                BeginContext(1327, 73, true);
                WriteLiteral(" />\r\n                                </div>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1407, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 30 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1493, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1523, 9, true);
            WriteLiteral(" &nbsp;\r\n");
            EndContext();
#line 34 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
                        }

#line default
#line hidden
            BeginContext(1559, 50, true);
            WriteLiteral("                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 37 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
            }

#line default
#line hidden
            BeginContext(1624, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 40 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
}

#line default
#line hidden
#line 41 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
 if (Model.OtherLogins.Count > 0)
{

#line default
#line hidden
            BeginContext(1697, 61, true);
            WriteLiteral("    <h4>Add another service to log in.</h4>\r\n    <hr />\r\n    ");
            EndContext();
            BeginContext(1758, 489, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b50ecbe059c0f76a81c04082cf628cbf08dea7d118296", async() => {
                BeginContext(1861, 55, true);
                WriteLiteral("\r\n        <div id=\"socialLoginList\">\r\n            <p>\r\n");
                EndContext();
#line 48 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
                 foreach (var provider in Model.OtherLogins)
                {

#line default
#line hidden
                BeginContext(1997, 81, true);
                WriteLiteral("                    <button type=\"submit\" class=\"btn btn-default\" name=\"provider\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2078, "\"", 2100, 1);
#line 50 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
WriteAttributeValue("", 2086, provider.Name, 2086, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("title", " title=\"", 2101, "\"", 2149, 6);
                WriteAttributeValue("", 2109, "Log", 2109, 3, true);
                WriteAttributeValue(" ", 2112, "in", 2113, 3, true);
                WriteAttributeValue(" ", 2115, "using", 2116, 6, true);
                WriteAttributeValue(" ", 2121, "your", 2122, 5, true);
#line 50 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
WriteAttributeValue(" ", 2126, provider.Name, 2127, 14, false);

#line default
#line hidden
                WriteAttributeValue(" ", 2141, "account", 2142, 8, true);
                EndWriteAttribute();
                BeginContext(2150, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(2152, 20, false);
#line 50 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
                                                                                                                                                     Write(provider.DisplayName);

#line default
#line hidden
                EndContext();
                BeginContext(2172, 11, true);
                WriteLiteral("</button>\r\n");
                EndContext();
#line 51 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
                }

#line default
#line hidden
                BeginContext(2202, 38, true);
                WriteLiteral("            </p>\r\n        </div>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2247, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 55 "E:\WorkSpace\repos\AspNetCoreSample\AuthSample\AuthSample.mvc\Views\Manage\ManageLogins.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ManageLoginsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
