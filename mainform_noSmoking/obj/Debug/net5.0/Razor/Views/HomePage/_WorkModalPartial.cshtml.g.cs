#pragma checksum "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\HomePage\_WorkModalPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c52b43fc9e4231a4120982e1ff01a0c7651640c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HomePage__WorkModalPartial), @"mvc.1.0.view", @"/Views/HomePage/_WorkModalPartial.cshtml")]
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
#line 1 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\HomePage\_WorkModalPartial.cshtml"
using mainform_noSmoking.Models.Grading;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c52b43fc9e4231a4120982e1ff01a0c7651640c", @"/Views/HomePage/_WorkModalPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adb5652dff9a1fd0ef3b2a29973d55aacc127529", @"/Views/_ViewImports.cshtml")]
    public class Views_HomePage__WorkModalPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<mainform_noSmoking.Models.Home.HomeModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<span class=\"close\" data-dismiss=\"modal\">&times;</span>\r\n<div class=\"pop_content\">\r\n    <div class=\"pop_image_wrapper\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 226, "\"", 282, 1);
#nullable restore
#line 7 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\HomePage\_WorkModalPartial.cshtml"
WriteAttributeValue("", 232, Model.ShareModel.ViewModel.FileInfo.File_location, 232, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    </div>\r\n    <div class=\"pop_text_wrapper\">\r\n        <p>\r\n            <b>");
#nullable restore
#line 11 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\HomePage\_WorkModalPartial.cshtml"
          Write(Model.ShareModel.ViewModel.SchuleInfo.Schule_name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 11 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\HomePage\_WorkModalPartial.cshtml"
                                                             Write(Model.ShareModel.ViewModel.StudentInfo.Student_grade);

#line default
#line hidden
#nullable disable
            WriteLiteral(" 年級 ");
#nullable restore
#line 11 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\HomePage\_WorkModalPartial.cshtml"
                                                                                                                      Write(Model.ShareModel.ViewModel.StudentInfo.Student_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n        </p>\r\n        <p>\r\n            作品理念:\r\n            <br>");
#nullable restore
#line 15 "C:\Users\paul7\source\repos\mainform_noSmoking\mainform_noSmoking\Views\HomePage\_WorkModalPartial.cshtml"
           Write(Model.ShareModel.ViewModel.FileInfo.Work_concept);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<mainform_noSmoking.Models.Home.HomeModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
