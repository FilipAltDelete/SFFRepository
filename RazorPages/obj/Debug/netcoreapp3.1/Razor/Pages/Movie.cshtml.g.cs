#pragma checksum "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d96f6a317b6e073d4726395787d21f89bb996d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorPages.Pages.Pages_Movie), @"mvc.1.0.razor-page", @"/Pages/Movie.cshtml")]
namespace RazorPages.Pages
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
#line 1 "/Users/filipaltdelete/Code/RazorPages/Pages/_ViewImports.cshtml"
using RazorPages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d96f6a317b6e073d4726395787d21f89bb996d4", @"/Pages/Movie.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bb4d15e82bf516f895a84b5c4d83ae504087504", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Movie : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
  
    ViewData["Title"] = "Movie";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br><br><br>\r\n\r\n<div style=\"width: 30%; float:left;position: fixed\">\r\n    <br/>\r\n    <h1>");
#nullable restore
#line 11 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
   Write(Model.FetchedMovie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <h2>");
#nullable restore
#line 12 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
   Write(Model.FetchedMovie.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 261, "\"", 295, 1);
#nullable restore
#line 14 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
WriteAttributeValue("", 267, Model.FetchedMovie.ImageURL, 267, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></img>    \r\n<br/><br/>\r\n        <button class=\"triviaButton triviaButton2\"");
            BeginWriteAttribute("onclick", " onclick=\"", 371, "\"", 433, 3);
            WriteAttributeValue("", 381, "location.href=\'/AddTrivia?id=", 381, 29, true);
#nullable restore
#line 16 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
WriteAttributeValue("", 410, Model.FetchedMovie.Id, 410, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 432, "\'", 432, 1, true);
            EndWriteAttribute();
            WriteLiteral(" id=\"triviaButtonId\" name=\"triviaButtonId\">Add Trivia</button>\r\n<br/><br/> \r\n        <button class=\"reviewButton reviewButton2\"");
            BeginWriteAttribute("onclick", " onclick=\"", 561, "\"", 625, 3);
            WriteAttributeValue("", 571, "location.href=\'/ReviewMovie?id=", 571, 31, true);
#nullable restore
#line 18 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
WriteAttributeValue("", 602, Model.FetchedMovie.Id, 602, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 624, "\'", 624, 1, true);
            EndWriteAttribute();
            WriteLiteral(" id=\"reviewButtonId\" name=\"reviewButtonId\" >Review Movie</button>\r\n<br/><br/>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8d96f6a317b6e073d4726395787d21f89bb996d45877", async() => {
                WriteLiteral("\r\n            <button class=\"deleteButton deleteButton2\" id=\"buttonId\" name=\"buttonId\"");
                BeginWriteAttribute("value", " value=\"", 845, "\"", 875, 1);
#nullable restore
#line 21 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
WriteAttributeValue("", 853, Model.FetchedMovie.Id, 853, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Delete Movie</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <br/>\r\n</div>\r\n\r\n<br/><br/><br/><br/><br/><br/><br/>\r\n\r\n<div style=\"width: 70%; float:right\">\r\n    <div style=\"width: 50%; float:left\">\r\n        <h3>Reviews: </h3> <br/>\r\n\r\n");
#nullable restore
#line 32 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
         foreach (var review in Model.Reviews)
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>\r\n                <h5>Grade: </h5>\r\n                <p>");
#nullable restore
#line 37 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
              Write(review.Grade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <div>\r\n                <h5>Comment: </h5>\r\n                <p>");
#nullable restore
#line 41 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
              Write(review.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                \r\n");
#nullable restore
#line 43 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
                 foreach (var studio in @Model.StudiosRelatedToReveiewsSorted)
                {
                    if(studio.Id == review.StudioId){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h5>Studio: </h5>\r\n                        <p>");
#nullable restore
#line 47 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
                      Write(studio.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 48 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \r\n            </div>\r\n            <br/>\r\n            <p>_______________________________</p>\r\n            <br/>\r\n");
#nullable restore
#line 55 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div style=\"width: 50%; float:right\">\r\n        <h3>Trivias: </h3> <br/>\r\n");
#nullable restore
#line 60 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
         foreach (var item in Model.Trivias)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>\r\n                <p>");
#nullable restore
#line 63 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
              Write(item.TriviaString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n");
#nullable restore
#line 65 "/Users/filipaltdelete/Code/RazorPages/Pages/Movie.cshtml"
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    
</div>

<style>

.triviaButton {
  background-color: #c49c20; /* Gold */
  border: none;
  color: white;
  width: 170px;
  height: 54px;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  -webkit-transition-duration: 0.4s;
  transition-duration: 0.4s;
}
.triviaButton2:hover {
  box-shadow: 0 12px 16px 0 rgb(255,255,102),0 17px 50px 0 rgba(255,255,102);
}

.reviewButton {
  background-color: #1095c2; /* Blue */
  border: none;
  color: white;
  width: 170px;
  height: 54px;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  -webkit-transition-duration: 0.4s;
  transition-duration: 0.7s;
}
.reviewButton2:hover {
  box-shadow: 0 12px 16px 0 rgb(0,250,250),0 17px 50px 0 rgba(0,250,250);
}

.deleteButton {
  background-color: rgb(128,0,0); /* Red */
 ");
            WriteLiteral(@" border: none;
  color: white;
  width: 170px;
  height: 54px;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  -webkit-transition-duration: 0.4s;
  transition-duration: 0.4s;
}

.deleteButton1 {
  box-shadow: 0 8px 16px 0 rgb(128,0,0), 0 6px 20px 0 rgba(128,0,0);
}

.deleteButton2:hover {
  box-shadow: 0 12px 16px 0 rgb(220,20,60),0 17px 50px 0 rgba(220,20,60);
}

</style>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorPages.Pages.MovieModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorPages.Pages.MovieModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorPages.Pages.MovieModel>)PageContext?.ViewData;
        public RazorPages.Pages.MovieModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
