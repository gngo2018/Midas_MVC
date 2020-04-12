#pragma checksum "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59c73680b4f7787ad2ea8f1115cdbbd676931f5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BudgetBoard_Details), @"mvc.1.0.view", @"/Views/BudgetBoard/Details.cshtml")]
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
#line 1 "C:\Projects\Midas\Midas_MVC\Midas\Views\_ViewImports.cshtml"
using Midas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\Midas\Midas_MVC\Midas\Views\_ViewImports.cshtml"
using Midas.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
using Midas_Models.BudgetBoard;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59c73680b4f7787ad2ea8f1115cdbbd676931f5a", @"/Views/BudgetBoard/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cad0772b077679b6dcb43119a70caafe78842bfb", @"/Views/_ViewImports.cshtml")]
    public class Views_BudgetBoard_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BudgetBoardDetailDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteMonthlyExpense", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/_AddMonthlyExpenseToBoard.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
  
    ViewData["Title"] = "Details";
    var expenseTotal = ViewBag.expenseTotal;
    var livingAmountLeft = Model.LivingAmount - expenseTotal;
    var leiserAmountLeft = Model.LeisureAmount;
    var savingsAmountLeft = Model.SavingsAmount;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div>\r\n        <h2>Board: ");
#nullable restore
#line 13 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
              Write(Model.BudgetBoardName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        <hr />\r\n        <div class=\"row\">\r\n            <dl class=\"row col-sm\">\r\n                <dt class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 18 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(Html.DisplayName("Living Amount"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 21 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(Html.DisplayFor(model => model.LivingAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 24 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(Html.DisplayName("Total After Expenses"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 27 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(string.Format("{0:C}", livingAmountLeft));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n            <dl class=\"row col-sm\">\r\n                <dt class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 32 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(Html.DisplayName("Savings Amount"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 35 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(Html.DisplayFor(model => model.SavingsAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 38 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(Html.DisplayName("Total After Expenses"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 41 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(string.Format("{0:C}", savingsAmountLeft));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n            <dl class=\"row col-sm\">\r\n                <dt class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 46 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(Html.DisplayName("Leisure Amount"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 49 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(Html.DisplayFor(model => model.LeisureAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 52 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(Html.DisplayName("Total After Expenses"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-6\">\r\n                    ");
#nullable restore
#line 55 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
               Write(string.Format("{0:C}", leiserAmountLeft));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n        </div>\r\n    </div>\r\n<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        <h3>Monthly Expenses Total: $");
#nullable restore
#line 62 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
                                Write(expenseTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div>\r\n    <div class=\"expense_table card-body\">\r\n");
#nullable restore
#line 65 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
         if (Model.MonthlyExpenses.Any())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table table-hover\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>\r\n                            ");
#nullable restore
#line 70 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
                       Write(Html.DisplayName("Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 73 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
                       Write(Html.DisplayName("Amount"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 79 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
                     foreach (var expense in Model.MonthlyExpenses)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 83 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
                           Write(expense.BillName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 86 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
                           Write(string.Format("{0:C}", expense.BillAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59c73680b4f7787ad2ea8f1115cdbbd676931f5a12475", async() => {
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 90 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
                               Write(Html.ActionLink("Edit", "Edit", new { id = expense.MonthlyExpenseId }));

#line default
#line hidden
#nullable disable
                WriteLiteral(" |\r\n                                    ");
#nullable restore
#line 91 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
                               Write(Html.ActionLink("Details", "ExpenseDetails", new { id = expense.MonthlyExpenseId }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@" |
                                    <button type=""submit"" class=""btn-link"" onclick=""return confirm('Are you sure you wish to delete this expense?'); "">
                                        Delete
                                    </button>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-expenseId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
                                                                                 WriteLiteral(expense.MonthlyExpenseId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["expenseId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-expenseId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["expenseId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
                                                                                                                                     WriteLiteral(Model.BudgetBoardId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["budgetBoardId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-budgetBoardId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["budgetBoardId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 98 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 101 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h5 class=\"card-title\">No Expenses Have Been Added To This Board</h5>\r\n");
#nullable restore
#line 105 "C:\Projects\Midas\Midas_MVC\Midas\Views\BudgetBoard\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"card-footer\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "59c73680b4f7787ad2ea8f1115cdbbd676931f5a17831", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59c73680b4f7787ad2ea8f1115cdbbd676931f5a18989", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BudgetBoardDetailDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
