#pragma checksum "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05e1b4cf5556eb4d33ac86cb8381e997728cf2af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_UpdatePassword), @"mvc.1.0.view", @"/Views/Login/UpdatePassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Login/UpdatePassword.cshtml", typeof(AspNetCore.Views_Login_UpdatePassword))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05e1b4cf5556eb4d33ac86cb8381e997728cf2af", @"/Views/Login/UpdatePassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d468dd1e886cfa128ea5d6bdddad09f0f7b148c", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_UpdatePassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdatePass", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
  
    ViewData["Title"] = "Update Password";
    string why = ViewBag.why == 1 ? "sido regenerada" : "caducado";
    List<int> codigos = ViewBag.codigos;

#line default
#line hidden
            BeginContext(164, 172, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-12\">\r\n        <h2>Update Password</h2>\r\n        <hr />\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"offset-2 col-8\">\r\n");
            EndContext();
#line 17 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
         if (ViewBag.why != null && ViewBag.why != 0)
        {

#line default
#line hidden
            BeginContext(402, 179, true);
            WriteLiteral("            <div class=\"col-12\">\r\n                <div class=\"alert alert-warning alert-dismissible fade show\" role=\"alert\">\r\n                    <strong>Update Password</strong> ");
            EndContext();
            BeginContext(582, 80, false);
#line 21 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
                                                Write(string.Format("La contraseña ha {0} por favor actualicela inmediatamente.", why));

#line default
#line hidden
            EndContext();
            BeginContext(662, 240, true);
            WriteLiteral("\r\n                    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n                        <span aria-hidden=\"true\">&times;</span>\r\n                    </button>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 27 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
        }

#line default
#line hidden
            BeginContext(913, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(921, 1025, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05e1b4cf5556eb4d33ac86cb8381e997728cf2af6520", async() => {
                BeginContext(988, 62, true);
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"usuario\" id=\"usuario\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1050, "\"", 1074, 1);
#line 29 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
WriteAttributeValue("", 1058, ViewBag.usuario, 1058, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1075, 864, true);
                WriteLiteral(@" />

            <label for=""document"">Document</label>
            <input id=""document"" name=""document"" type=""text"" class=""form-control"" />


            <label for=""current_password"">Current Password</label>
            <input id=""current_password"" name=""current_password"" type=""password"" class=""form-control"" />

            <label for=""new_password"">New Password</label>
            <input id=""new_password"" name=""new_password"" type=""password"" class=""form-control"" />

            <label for=""validate_password"">Repeat Password</label>
            <input id=""validate_password"" name=""validate_password"" type=""password"" class=""form-control"" />
            <br />

            <div class=""col-12"">
                <button type=""submit"" class=""btn btn-outline-primary col-12"">Recover</button>
                <hr />
            </div>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1946, 48, true);
            WriteLiteral("\r\n        <br />\r\n        <div class=\"col-12\">\r\n");
            EndContext();
#line 52 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
             if (codigos != null)
            {
                foreach (var codigo in codigos)
                {
                    switch (codigo)
                    {
                        case 1:

#line default
#line hidden
            BeginContext(2205, 113, true);
            WriteLiteral("                            <label class=\"text-danger\">La contraseña no cumple con los digitos minimos.</label>\r\n");
            EndContext();
#line 60 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
                            break;
                        case 2:

#line default
#line hidden
            BeginContext(2387, 123, true);
            WriteLiteral("                            <label class=\"text-danger\">La contraseña no cumple con la cantidad de letras minimas.</label>\r\n");
            EndContext();
#line 63 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
                            break;
                        case 3:

#line default
#line hidden
            BeginContext(2579, 127, true);
            WriteLiteral("                            <label class=\"text-danger\">La contraseña no cumple con la cantidad de mayusculas minimas.</label>\r\n");
            EndContext();
#line 66 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
                            break;
                        case 4:

#line default
#line hidden
            BeginContext(2775, 123, true);
            WriteLiteral("                            <label class=\"text-danger\">La contraseña no cumple con la cantidad de simbolos minima</label>\r\n");
            EndContext();
#line 69 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
                            break;
                        case 5:

#line default
#line hidden
            BeginContext(2967, 131, true);
            WriteLiteral("                            <label class=\"text-danger\">La contraseña no cumple con el no uso de datos basicos del usuario</label>\r\n");
            EndContext();
#line 72 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
                            break;
                        case 6:

#line default
#line hidden
            BeginContext(3167, 128, true);
            WriteLiteral("                            <label class=\"text-danger\">La contraseña no cumple con el no uso de contraseñas anteriores</label>\r\n");
            EndContext();
#line 75 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
                            break;
                        case 7:

#line default
#line hidden
            BeginContext(3364, 146, true);
            WriteLiteral("                            <label class=\"text-danger\">La contraseña no cumple con el no uso de las palabras prohibidas para contraseñas</label>\r\n");
            EndContext();
#line 78 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
                            break;
                        case 8:

#line default
#line hidden
            BeginContext(3579, 129, true);
            WriteLiteral("                            <label class=\"text-danger\">La contraseña no cumple con el no uso del login en la contraseña</label>\r\n");
            EndContext();
#line 81 "D:\Workspace\go\src\github.com\rdavidnota\mis.soe.mod13\web\Security\Security.Web\Views\Login\UpdatePassword.cshtml"
                            break;
                    }
                }
            }

#line default
#line hidden
            BeginContext(3801, 36, true);
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n</div>");
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
