#pragma checksum "C:\Users\Joseph\source\repos\ImportExcel\ImportExcelDemo\Pages\DisplaySun\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd42808f5265b13790370d297e17fb33d4ea51ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ImportExcelDemo.Pages.DisplaySun.Pages_DisplaySun_Index), @"mvc.1.0.razor-page", @"/Pages/DisplaySun/Index.cshtml")]
namespace ImportExcelDemo.Pages.DisplaySun
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
#line 1 "C:\Users\Joseph\source\repos\ImportExcel\ImportExcelDemo\Pages\_ViewImports.cshtml"
using ImportExcelDemo;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd42808f5265b13790370d297e17fb33d4ea51ec", @"/Pages/DisplaySun/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37cb6702a91809367b8ca4a3d88a28c5cf9b8468", @"/Pages/_ViewImports.cshtml")]
    public class Pages_DisplaySun_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/dtSunflower.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Joseph\source\repos\ImportExcel\ImportExcelDemo\Pages\DisplaySun\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Data Table -->
<div class=""border backgroundWhite container"">
    <div class=""row"">
        <div class=""col-6"">
            <h2 class=""text-primary"">Sunflower List</h2>
        </div>
    </div>
    <br />
    <table id=""DT_load"" class=""display cell-border compact nowrap"" style=""width:100%"">
        <thead>
            <tr>
                <th>Sun ID</th>
                <th>Barcode #</th>
                <th>Status</th>
                <th>Official Name</th>
                <th>Manufacturer</th>
                <th>Model</th>
                <th>Model Name</th>
                <th>Serial Number</th>
                <th>Asset Value</th>
                <th>Effective Date</th>
                <th>Cust Area</th>
                <th>Bureau Or Region</th>
                <th>Property Contact</th>
                <th>Current User</th>
                <th>Fed Supply Group</th>
                <th>Utilization Code</th>
                <th>Asset Condition</th>
                <th>Co");
            WriteLiteral(@"ndition Description</th>
                <th>Physical Inventory Date</th>
                <th>Acquisition Date</th>
                <th>Responsibility Date</th>
                <th>Site</th>
                <th>Stlv 1</th>
                <th>Stlv 2</th>
                <th>Stlv 3</th>
                <th>MailStop</th>
                <th>Gps 1</th>
                <th>Gps 2</th>
                <th>Gps 3</th>
                <th>Resolution Date</th>
                <th>Resolution</th>
                <th>Final Event</th>
                <th>Date Time</th>
                <th>Final Event User Defined Label 01</th>
                <th>Final Event User Field 01</th>

            </tr>
        </thead>
    </table>
</div>




");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd42808f5265b13790370d297e17fb33d4ea51ec5474", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ImportExcelDemo.Pages.DisplaySun.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ImportExcelDemo.Pages.DisplaySun.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ImportExcelDemo.Pages.DisplaySun.IndexModel>)PageContext?.ViewData;
        public ImportExcelDemo.Pages.DisplaySun.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
