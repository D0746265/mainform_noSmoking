#pragma checksum "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "173b567aa39ac2f4769f776f644225d0e2154441"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Grading__GradingPartial), @"mvc.1.0.view", @"/Views/Grading/_GradingPartial.cshtml")]
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
#nullable restore
#line 1 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\_ViewImports.cshtml"
using mainform_noSmoking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\_ViewImports.cshtml"
using mainform_noSmoking.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml"
using mainform_noSmoking.Models.Grading;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"173b567aa39ac2f4769f776f644225d0e2154441", @"/Views/Grading/_GradingPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adb5652dff9a1fd0ef3b2a29973d55aacc127529", @"/Views/_ViewImports.cshtml")]
    public class Views_Grading__GradingPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<mainform_noSmoking.Models.Grading.GradingModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "5", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<table>\r\n    <thead>\r\n        <tr>\r\n            <th>作品編碼</th>\r\n            <th>照片預覽</th>\r\n            <th>\r\n                <select name=\"Student_grade\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "173b567aa39ac2f4769f776f644225d0e21544414828", async() => {
                WriteLiteral("全部年級");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "173b567aa39ac2f4769f776f644225d0e21544416316", async() => {
                WriteLiteral("低年級");
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
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "173b567aa39ac2f4769f776f644225d0e21544417492", async() => {
                WriteLiteral("中年級");
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
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "173b567aa39ac2f4769f776f644225d0e21544418668", async() => {
                WriteLiteral("高年級");
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
            WriteLiteral("\r\n                </select>\r\n            </th>\r\n            <th>投稿時間</th>\r\n            <th>審核狀態</th>\r\n        </tr>\r\n    </thead>\r\n    <!--GradingTable-->\r\n    <tbody>\r\n");
#nullable restore
#line 23 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml"
         foreach (WorkViewModel info in Model.ShareModel.ViewModels)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("id", " id=\"", 735, "\"", 768, 1);
#nullable restore
#line 25 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml"
WriteAttributeValue("", 740, info.StudentInfo.Student_id, 740, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"StudentAndWork\">\r\n                <td>");
#nullable restore
#line 26 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml"
               Write(info.FileInfo.File_Image_id.ToString("0000"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <img");
            BeginWriteAttribute("src", " src=", 912, "", 945, 1);
#nullable restore
#line 28 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml"
WriteAttributeValue("", 917, info.FileInfo.File_location, 917, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                </td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml"
               Write(info.StudentInfo.Student_grade);

#line default
#line hidden
#nullable disable
            WriteLiteral(" 年級</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml"
               Write(info.FileInfo.Upload_time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml"
                Write((info.StudentInfo.Pass_or_Not == 0)?"未審核":null);

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml"
                                                                 Write((info.StudentInfo.Pass_or_Not == 1)?"已通過":null);

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml"
                                                                                                                  Write((info.StudentInfo.Pass_or_Not == 2)?"未通過":null);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 35 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\Grading\_GradingPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<mainform_noSmoking.Models.Grading.GradingModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
