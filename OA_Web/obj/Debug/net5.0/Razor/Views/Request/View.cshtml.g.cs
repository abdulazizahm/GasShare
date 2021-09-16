#pragma checksum "E:\GasShare\OA_Web\Views\Request\View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9295c3d1a4cf1a8d4ec235b3dee064873819b03f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Request_View), @"mvc.1.0.view", @"/Views/Request/View.cshtml")]
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
#nullable restore
#line 2 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
using OA_DAL.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9295c3d1a4cf1a8d4ec235b3dee064873819b03f", @"/Views/Request/View.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c75dc7522726cd42b8d4004b0d17bbd59d430de0", @"/Views/_ViewImports.cshtml")]
    public class Views_Request_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OA_Service.ViewModels.RequestViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Approve", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration-none text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Id", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("DeclineRequest(event)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
  
    ViewData["Title"] = "Request";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral(@"
    <style>

        #multiple-file-preview {
            border-top: 1px solid rgba(0, 0, 0, 0.11);
            margin-top: 10px;
            padding: 10px;
        }

        #sortable {
            list-style-type: none;
            margin: 0;
            padding: 0;
            min-height: 100px;
        }

            #sortable li {
                margin: 3px 3px 3px 0;
                float: left;
                width: 200px;
                text-align: center;
                position: relative;
                background-color: #FFFFFF;
            }

                #sortable li, #sortable li img {
                    -webkit-border-radius: 4px;
                    -moz-border-radius: 4px;
                    border-radius: 4px;
                }

                    #sortable li div.order-number {
                        position: absolute;
                        top: 2px;
                        right: 2px;
                        width: 15px;
               ");
                WriteLiteral(@"         height: 15px;
                        background-color: #2B91E3;
                        color: #FFFFFF;
                        font-size: 12px;
                        -webkit-border-radius: 20px;
                        -moz-border-radius: 20px;
                        border-radius: 20px;
                    }

        .modalImg {
            border-radius: 5px;
            cursor: pointer;
            transition: 0.3s;
            width: 100%;
        }

        /* Add Animation */
        .modal-content, #caption {
            -webkit-animation-name: zoom;
            -webkit-animation-duration: 0.25s;
            animation-name: zoom;
            animation-duration: 0.25s;
        }

        ");
                WriteLiteral("@-webkit-keyframes zoom {\r\n            from {\r\n                -webkit-transform: scale(0.8)\r\n            }\r\n\r\n            to {\r\n                -webkit-transform: scale(1)\r\n            }\r\n        }\r\n\r\n        ");
                WriteLiteral(@"@keyframes zoom {
            from {
                transform: scale(0.8)
            }

            to {
                transform: scale(1)
            }
        }

        .modalImg:hover {
            opacity: 0.7;
        }

        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
        }

        /* Modal Content (image) */
        .modal-content {
            margin: auto;
            display: block;
            width: 80%;
        }

        /* Caption of Mod");
                WriteLiteral(@"al Image */
        #caption {
            margin: auto;
            display: block;
            width: 80%;
            max-width: 700px;
            text-align: center;
            color: #ccc;
            padding: 10px 0;
            height: 150px;
        }

        #img01 {
            width: auto;
            max-height: 90%;
            max-width: 90%;
        }

        /* The Close Button */
        #closeBtn {
            position: absolute;
            top: 20px;
            right: 23px;
            color: #f1f1f1;
            font-size: 40px;
            font-weight: bold;
            transition: 0.3s;
            z-index: 100;
        }

        .profileImg {
            object-fit: cover;
            width: 60px;
            height: 60px;
        }

        #closeBtn:hover,
        #closeBtn:focus {
            color: #bbb;
            text-decoration: none;
            cursor: pointer;
        }

        .userName {
            display: inline-block;");
                WriteLiteral("\n            margin-bottom: auto;\r\n            padding-top: 15px;\r\n            margin-left: 16px;\r\n        }\r\n\r\n        /* 100% Image Width on Smaller Screens */\r\n        ");
                WriteLiteral(@"@media only screen and (max-width: 700px) {
        }

        textarea {
            transition: background 0.3s;
        }

        .modal-backdrop {
            z-index: 0;
        }

        .invalid {
            background: rgba(209, 111, 111, 0.56);
        }
    </style>
");
            }
            );
            WriteLiteral("\r\n");
#nullable restore
#line 183 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
  
    var Reson1ToDisable = Model.Status == OA_DAL.Models.Request_Status.Approved || Model.Status == OA_DAL.Models.Request_Status.Cancelled || Model.Status == OA_DAL.Models.Request_Status.Rejected;
    var Reson2ToDisable = (Model.Journey.Passengers_Number < Model.Seats) ;

    var DisableApprove = Reson2ToDisable || Reson1ToDisable ? "disabled" : "";
    var DisableDecline = Reson1ToDisable ? "disabled" : "";


    var Approved = Model.Status == Request_Status.Approved ;
    var ReJected = Model.Status == Request_Status.Rejected || Model.Status == Request_Status.Cancelled;
    var tab = "";
    if (Approved)
    {
        tab = "Approved";
    }
    else if (ReJected)
    {
        tab = "Rejected";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n    <div class=\"d-flex flex-md-row flex-column my-2\">\r\n        <h1>Request Details</h1>\r\n        <div class=\"ml-3\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9295c3d1a4cf1a8d4ec235b3dee064873819b03f11919", async() => {
                WriteLiteral("back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-tab", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 209 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
                                     WriteLiteral(tab);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["tab"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-tab", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["tab"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9295c3d1a4cf1a8d4ec235b3dee064873819b03f14126", async() => {
                WriteLiteral("Approve");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 210 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
                                      WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5721, "btn", 5721, 3, true);
            AddHtmlAttributeValue(" ", 5724, "btn-secondary", 5725, 14, true);
#nullable restore
#line 210 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
AddHtmlAttributeValue(" ", 5738, Html.Raw(DisableApprove), 5739, 25, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <a href=\"#\"");
            BeginWriteAttribute("class", " class=\"", 5802, "\"", 5853, 3);
            WriteAttributeValue("", 5810, "btn", 5810, 3, true);
            WriteAttributeValue(" ", 5813, "btn-secondary", 5814, 14, true);
#nullable restore
#line 211 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
WriteAttributeValue(" ", 5827, Html.Raw(DisableDecline), 5828, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=\"#basicModal\">Decline</a>\r\n        </div>\r\n    </div>\r\n\r\n    <div>\r\n        <div>\r\n            <div class=\"comment-meta d-flex align-items-baseline\">\r\n                <img");
            BeginWriteAttribute("src", " src=", 6058, "", 6094, 2);
            WriteAttributeValue("", 6063, "/images/Users/", 6063, 14, true);
#nullable restore
#line 218 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
WriteAttributeValue("", 6077, Model.User.Photo, 6077, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rounded-circle profileImg\">\r\n                <h5 class=\"userName\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9295c3d1a4cf1a8d4ec235b3dee064873819b03f18056", async() => {
#nullable restore
#line 219 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
                                                                                                                                                 Write(Model.User.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 219 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
                                                                                                                                                                       Write(Model.User.LastName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 219 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
                                                                                                                          WriteLiteral(Model.User.Id);

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
            WriteLiteral("</h5>\r\n            </div>\r\n            <div>\r\n                <h4 class=\"my-3\">Wants to book ");
#nullable restore
#line 222 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
                                          Write(Model.Seats);

#line default
#line hidden
#nullable disable
            WriteLiteral(" seats in your ride</h4>\r\n            </div>\r\n        </div>\r\n        <ul id=\"sortable\" class=\"d-flex flex-column flex-md-row\">\r\n");
#nullable restore
#line 226 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
             if (Model.IncludeUser == true)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"ui-state-default\">\r\n                    <img class=\"modalImg\" onclick=\"OpenModal(this)\"");
            BeginWriteAttribute("src", " src=\"", 6735, "\"", 6791, 2);
            WriteAttributeValue("", 6741, "/images/UserPhotos/", 6741, 19, true);
#nullable restore
#line 229 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
WriteAttributeValue("", 6760, Model.User.UserPhoto.SSN_Photo, 6760, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100%;\">\r\n                </li>\r\n");
#nullable restore
#line 231 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 234 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
             foreach (var item in Model.Photos)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"ui-state-default\">\r\n                    <img class=\"modalImg\" onclick=\"OpenModal(this)\"");
            BeginWriteAttribute("src", " src=\"", 7035, "\"", 7069, 2);
            WriteAttributeValue("", 7041, "/images/Requests/", 7041, 17, true);
#nullable restore
#line 237 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
WriteAttributeValue("", 7058, item.Photo, 7058, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100%;\">\r\n                </li>\r\n");
#nullable restore
#line 239 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""clear-both""></div>
        </ul>
    </div>


</div>

<!-- The Modal -->
<div id=""myModal"" class=""modal"" onclick=""closeModal()"">
    <span id=""closeBtn"" onclick=""closeModal()"">&times;</span>
    <img class=""modal-content"" onclick=""imageClick(event)"" id=""img01"">
</div>




<!-- basic modal -->
<div class=""modal fade"" id=""basicModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""basicModal"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""myModalLabel"">Reason For Decline ?</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9295c3d1a4cf1a8d4ec235b3dee064873819b03f24563", async() => {
                WriteLiteral("\r\n                    <input type=\"text\" name=\"Id\" hidden");
                BeginWriteAttribute("value", " value=\"", 8130, "\"", 8147, 1);
#nullable restore
#line 268 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
WriteAttributeValue("", 8138, Model.Id, 8138, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />

                    <div class=""custom-control custom-radio"">
                        <input type=""radio"" name=""declineReason"" id=""customRadio1"" value=""Has no seats left"" class=""custom-control-input"" checked>
                        <label class=""custom-control-label"" for=""customRadio1"">Has no seats left</label>
                    </div>
                    <div class=""custom-control custom-radio"">
                        <input type=""radio"" name=""declineReason"" id=""customRadio2"" class=""custom-control-input"" value=""Id's Photos were not clear"">
                        <label class=""custom-control-label"" for=""customRadio2"">Id's Photos were not clear</label>
                    </div>
                    <div class=""custom-control custom-radio"">
                        <input type=""radio"" name=""declineReason"" id=""customRadio3"" class=""custom-control-input"" value=""Someone booked with me off GasShare"">
                        <label class=""custom-control-label"" for=""customRadio3"">Someone booked wi");
                WriteLiteral(@"th me off GasShare</label>
                    </div>
                    <div class=""custom-control custom-radio"">
                        <input type=""radio"" name=""declineReason"" id=""customRadio4"" class=""custom-control-input"" value=""Other"">
                        <label class=""custom-control-label"" for=""customRadio4"">Other</label>
                    </div>
                    <div class=""custom-control mr-4"">
                        <textarea id=""reasonText"" class=""form-control "" placeholder=""Enter reason here""></textarea>
                    </div>
                    <br />
                    <button type=""submit"" class=""btn btn-primary"" >Send</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"modal-footer\">\r\n                <button type=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">Cancel</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        // Get the modal
        var modal = document.getElementById(""myModal"");

        // Get the image and insert it inside the modal - use its ""alt"" text as a caption
        var modalImg = document.getElementById(""img01"");
        var captionText = document.getElementById(""caption"");


        function OpenModal(img) {
            modal.style.display = ""block"";
            modalImg.src = img.src;
        }


        // Get the <span> element that closes the modal
        var span = document.getElementById(""closeBtn"");

        // When the user clicks on <span> (x), close the modal
        function closeModal() {
            modal.style.display = ""none"";
        }

        function imageClick(event) {
            event.stopPropagation();
        }


        function DeclineRequest(e) {
            e.preventDefault()
            var selectionVal = document.querySelector('form input[name=declineReason]:checked').value;
            var id = document.querySelecto");
                WriteLiteral("r(\'form input[name=Id]\').value;\r\n            if (selectionVal != \"Other\") {\r\n                window.location.href = \'");
#nullable restore
#line 336 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
                                   Write(Url.Action("Decline", "Request"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/' + id + '?reason=' + selectionVal;
            }
            else
            {
                var reason = document.getElementById('reasonText').value;
                if (reason == null || reason == """") {
                    document.getElementById('reasonText').classList.add('invalid');
                }
                else {
                    console.log(reason);
                    window.location.href = '");
#nullable restore
#line 346 "E:\GasShare\OA_Web\Views\Request\View.cshtml"
                                       Write(Url.Action("Decline", "Request"));

#line default
#line hidden
#nullable disable
                WriteLiteral("/\' + id + \'?reason=\' + reason;\r\n                }\r\n            }\r\n        }\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OA_Service.ViewModels.RequestViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
