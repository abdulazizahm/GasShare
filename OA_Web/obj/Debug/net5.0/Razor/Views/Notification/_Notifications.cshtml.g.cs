#pragma checksum "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d7bf2c738b60de63386afcb9ce65472635ce569"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notification__Notifications), @"mvc.1.0.view", @"/Views/Notification/_Notifications.cshtml")]
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
#line 1 "E:\GasShare\OA_Web\Views\_ViewImports.cshtml"
using OA_Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GasShare\OA_Web\Views\_ViewImports.cshtml"
using OA_Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d7bf2c738b60de63386afcb9ce65472635ce569", @"/Views/Notification/_Notifications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c75dc7522726cd42b8d4004b0d17bbd59d430de0", @"/Views/_ViewImports.cshtml")]
    public class Views_Notification__Notifications : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OA_Service.ViewModels.NotificationViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml"
 if (ViewBag.NoNew == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>Notifications - <span>");
#nullable restore
#line 5 "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml"
                         Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h2>\r\n");
#nullable restore
#line 6 "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>No New Notification</h2>\r\n");
#nullable restore
#line 10 "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 12 "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml"
 foreach (var noti in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a class=\"notifications-item text-decoration-none\"");
            BeginWriteAttribute("href", " href=\"", 295, "\"", 311, 1);
#nullable restore
#line 14 "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml"
WriteAttributeValue("", 302, noti.Url, 302, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >\r\n");
            WriteLiteral("        <div class=\"text\">\r\n            <h6>");
#nullable restore
#line 17 "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml"
           Write(noti.Created_at.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <p>");
#nullable restore
#line 18 "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml"
          Write(noti.Body);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 19 "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml"
             if (!noti.Seen) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div hidden>UnseenNotification</div>\r\n");
#nullable restore
#line 21 "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </a>\r\n");
#nullable restore
#line 24 "E:\GasShare\OA_Web\Views\Notification\_Notifications.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OA_Service.ViewModels.NotificationViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591