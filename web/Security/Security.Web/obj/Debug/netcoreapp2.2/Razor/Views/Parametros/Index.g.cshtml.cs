#pragma checksum "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Parametros\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46807ab4b0709eb42950fd1f2cabfa03911c4c9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Parametros_Index), @"mvc.1.0.view", @"/Views/Parametros/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Parametros/Index.cshtml", typeof(AspNetCore.Views_Parametros_Index))]
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
#line 1 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\_ViewImports.cshtml"
using Security.Web;

#line default
#line hidden
#line 2 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\_ViewImports.cshtml"
using Security.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46807ab4b0709eb42950fd1f2cabfa03911c4c9f", @"/Views/Parametros/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d468dd1e886cfa128ea5d6bdddad09f0f7b148c", @"/Views/_ViewImports.cshtml")]
    public class Views_Parametros_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Security.Web.Models.Configuration>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "300", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "200", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "100", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Parametros", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Change", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Parametros\Index.cshtml"
  
    ViewData["Title"] = "Parametros";

#line default
#line hidden
            BeginContext(90, 120, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"offset-3 col-6\">\r\n        <h2>Parametros Generales</h2>\r\n        <hr />\r\n\r\n        ");
            EndContext();
            BeginContext(210, 1702, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "46807ab4b0709eb42950fd1f2cabfa03911c4c9f6115", async() => {
                BeginContext(278, 163, true);
                WriteLiteral("\r\n            <div class=\"row\">\r\n                <label for=\"level\">Nivel</label>\r\n                <select name=\"level\" class=\"form-control\">\r\n                    ");
                EndContext();
                BeginContext(441, 33, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "46807ab4b0709eb42950fd1f2cabfa03911c4c9f6673", async() => {
                    BeginContext(461, 4, true);
                    WriteLiteral("Alta");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(474, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(496, 34, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "46807ab4b0709eb42950fd1f2cabfa03911c4c9f8153", async() => {
                    BeginContext(516, 5, true);
                    WriteLiteral("Media");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(530, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(552, 33, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "46807ab4b0709eb42950fd1f2cabfa03911c4c9f9634", async() => {
                    BeginContext(572, 4, true);
                    WriteLiteral("Baja");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(585, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(607, 31, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "46807ab4b0709eb42950fd1f2cabfa03911c4c9f11114", async() => {
                    BeginContext(625, 4, true);
                    WriteLiteral("Baja");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(638, 156, true);
                WriteLiteral("\r\n                </select>\r\n\r\n                <label for=\"min_digits\">Numero Digitos</label>\r\n                <input class=\"form-control\" name=\"min_digits\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 794, "\"", 822, 1);
#line 23 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 802, Model.MinimumDigits, 802, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(823, 133, true);
                WriteLiteral(" />\r\n\r\n                <label for=\"min_letters\">Numero letras</label>\r\n                <input class=\"form-control\" name=\"min_letters\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 956, "\"", 985, 1);
#line 26 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 964, Model.MinimumLetters, 964, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(986, 139, true);
                WriteLiteral(" />\r\n\r\n                <label for=\"min_capitals\">Numero Mayusculas</label>\r\n                <input class=\"form-control\" name=\"min_capitals\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1125, "\"", 1161, 1);
#line 29 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 1133, Model.MinimumCapitalLetters, 1133, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1162, 137, true);
                WriteLiteral(" />\r\n\r\n                <label for=\"min_special\">Numero Mayusculas</label>\r\n                <input class=\"form-control\" name=\"min_special\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1299, "\"", 1337, 1);
#line 32 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 1307, Model.MinimumSpecialCharacter, 1307, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1338, 143, true);
                WriteLiteral(" />\r\n\r\n                <label for=\"longitud\">Longitud minima de contraseña</label>\r\n                <input class=\"form-control\" name=\"longitud\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1481, "\"", 1509, 1);
#line 35 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 1489, Model.MinimunLength, 1489, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1510, 153, true);
                WriteLiteral(" />\r\n\r\n                <label for=\"max_days\">Dias Maximos para cambiar la contraseña</label>\r\n                <input class=\"form-control\" name=\"max_days\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1663, "\"", 1704, 1);
#line 38 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 1671, Model.MaximumDaysChanguePassword, 1671, 33, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1705, 200, true);
                WriteLiteral(" />\r\n            </div>\r\n            <br />\r\n            <div class=\"row\">\r\n                <button type=\"submit\" class=\"btn btn-outline-primary col-12\">Save</button>\r\n            </div>\r\n\r\n\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1912, 22, true);
            WriteLiteral("\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Security.Web.Models.Configuration> Html { get; private set; }
    }
}
#pragma warning restore 1591