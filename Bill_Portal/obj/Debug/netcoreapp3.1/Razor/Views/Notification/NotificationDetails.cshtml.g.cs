#pragma checksum "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c98b59243ca7bef4df453e13afa44c62377e2489"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notification_NotificationDetails), @"mvc.1.0.view", @"/Views/Notification/NotificationDetails.cshtml")]
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
#line 1 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\_ViewImports.cshtml"
using Bill_Portal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\_ViewImports.cshtml"
using Bill_Portal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\_ViewImports.cshtml"
using Bill_Portal.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c98b59243ca7bef4df453e13afa44c62377e2489", @"/Views/Notification/NotificationDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7caf9533722535a95df5d64de893ecba9e79fc69", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Notification_NotificationDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Bill_Portal.Models.notification>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "notifications_list", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Notification", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light text-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditNotification", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
  
    ViewData["Title"] = "Notification Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div>
    

    <div class=""row "">
        <div class="" col-5 bg-light shadow-lg"" >
            <div class=""card-header"">
                <h4>Notification Details</h4>
            </div>
            <div class=""card-body "">
            <dl class=""mt-2 row"">
                <dt class=""col-3"">
                    ");
#nullable restore
#line 20 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
               Write(Html.DisplayNameFor(model => model.notification_serial));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-9\">\r\n                    ");
#nullable restore
#line 23 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
               Write(Html.DisplayFor(model => model.notification_serial));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-3\">\r\n                    ");
#nullable restore
#line 26 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
               Write(Html.DisplayNameFor(model => model.notification_title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-9\">\r\n                    ");
#nullable restore
#line 29 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
               Write(Html.DisplayFor(model => model.notification_title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-4\">\r\n                    ");
#nullable restore
#line 32 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
               Write(Html.DisplayNameFor(model => model.description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-8\">\r\n                    ");
#nullable restore
#line 35 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
               Write(Html.DisplayFor(model => model.description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-3\">\r\n                    ");
#nullable restore
#line 38 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
               Write(Html.DisplayNameFor(model => model.date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-9\">\r\n                    ");
#nullable restore
#line 41 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
               Write(Html.DisplayFor(model => model.date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n          \r\n            <div style=\"margin-top:450px\">\r\n\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c98b59243ca7bef4df453e13afa44c62377e24898938", async() => {
                WriteLiteral("<i class=\"fa fa-arrow-left\" aria-hidden=\"true\"></i>&nbsp;All Notifications");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <div class=\"float-right\">\r\n");
#nullable restore
#line 49 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
                     if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c98b59243ca7bef4df453e13afa44c62377e248910844", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
                                                                                             WriteLiteral(Model.notification_id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 52 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
                     if (_signInManager.IsSignedIn(User) && User.IsInRole("Manager"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c98b59243ca7bef4df453e13afa44c62377e248913710", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
                                                                                             WriteLiteral(Model.notification_id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 56 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n            </div>\r\n        </div>\r\n        <div class=\" col-7 shadow-lg\">\r\n            <dl>\r\n            <dt class=\"card-header\">\r\n                <h4>");
#nullable restore
#line 64 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
               Write(Html.DisplayNameFor(model => model.notification_document));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            </dt>\r\n            <dd class=\"card-body col-sm-10\">\r\n");
            WriteLiteral("                    <img");
            BeginWriteAttribute("src", " src=\"", 2797, "\"", 2846, 2);
            WriteAttributeValue("", 2803, "/", 2803, 1, true);
#nullable restore
#line 68 "C:\Users\Asim RaJPuT\Desktop\Bill_Portal\Bill_Portal\Views\Notification\NotificationDetails.cshtml"
WriteAttributeValue("", 2804, Url.Content(@Model.notification_document), 2804, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </dd>\r\n            </dl>\r\n        </div>\r\n    </div>             \r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Identity.SignInManager<BillUsers> _signInManager { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Bill_Portal.Models.notification> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
