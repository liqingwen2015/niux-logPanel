﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NiuX.LogPanel.Views.Home
{
    using System;
    
    #line 5 "..\..\Views\Home\Index.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    #line 6 "..\..\Views\Home\Index.cshtml"
    using NiuX.Extensions;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Views\Home\Index.cshtml"
    using NiuX.LogPanel.Models;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Views\Home\Index.cshtml"
    using NiuX.LogPanel.Views;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class Index : NiuX.LogPanel.Views.RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n\r\n");


WriteLiteral("\r\n");






            
            #line 9 "..\..\Views\Home\Index.cshtml"
  
    Layout = new _layout { Context = Context, Section = { ["Scripts"] = $"<script> var output = JSON.parse('{Raw(ViewData["ChartData"])}');</script> <script src='{Context.Options.PathMatch}/js.home.js'></script>" }, ViewData = ViewData };
    var logs = (IEnumerable<ILogModel>)ViewData["Model"];


            
            #line default
            #line hidden
WriteLiteral("<script type=\"text/javascript\">\r\n\r\n    var logs = ");


            
            #line 15 "..\..\Views\Home\Index.cshtml"
          Write(ViewData["Model"].ToJsonString());

            
            #line default
            #line hidden
WriteLiteral(";\r\n\r\n</script>\r\n\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <" +
"div class=\"col-md-3\" style=\"cursor:pointer;\" onclick=\"(window.location.href=\'");


            
            #line 21 "..\..\Views\Home\Index.cshtml"
                                                                                 Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/home/basic?All=true\')\">\r\n            <div class=\"card p-4\">\r\n                <di" +
"v class=\"card-body d-flex justify-content-between align-items-center\">\r\n        " +
"            <div>\r\n                        <span class=\"h4 d-block font-weight-n" +
"ormal mb-2\">");


            
            #line 25 "..\..\Views\Home\Index.cshtml"
                                                                    Write(ViewData["allCount"].ToString());

            
            #line default
            #line hidden
WriteLiteral(@"</span>
                        <span class=""font-weight-light"">所有日志</span>
                    </div>
                    <div class=""h2 text-muted"">
                        <i class=""fa fa-reply-all""></i>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-md-3"" style=""cursor:pointer;"" onclick=""(window.location.href='");


            
            #line 34 "..\..\Views\Home\Index.cshtml"
                                                                                 Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral(@"/home/basic?Unique=true')"">
            <div class=""card p-4"">
                <div class=""card-body d-flex justify-content-between align-items-center"">
                    <div>
                        <span class=""h4 d-block font-weight-normal mb-2"">");


            
            #line 38 "..\..\Views\Home\Index.cshtml"
                                                                    Write(ViewData["unique"].ToString());

            
            #line default
            #line hidden
WriteLiteral(@"</span>
                        <span class=""font-weight-light"">不重复的日志</span>
                    </div>
                    <div class=""h2 text-muted"">
                        <i class=""fa fa-question""></i>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-md-3"" style=""cursor:pointer;"" onclick=""(window.location.href='");


            
            #line 47 "..\..\Views\Home\Index.cshtml"
                                                                                 Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/home/basic?ToDay=true\')\">\r\n            <div class=\"card p-4\">\r\n                <" +
"div class=\"card-body d-flex justify-content-between align-items-center\">\r\n      " +
"              <div>\r\n                        <span class=\"h4 d-block font-weight" +
"-normal mb-2\">");


            
            #line 51 "..\..\Views\Home\Index.cshtml"
                                                                    Write(ViewData["todayCount"].ToString());

            
            #line default
            #line hidden
WriteLiteral(@"</span>
                        <span class=""font-weight-light"">今天的日志</span>
                    </div>
                    <div class=""h2 text-muted"">
                        <i class=""fa fa-external-link-square""></i>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-md-3"" style=""cursor:pointer;"" onclick=""(window.location.href='");


            
            #line 60 "..\..\Views\Home\Index.cshtml"
                                                                                 Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/home/basic?Hour=true\')\">\r\n            <div class=\"card p-4\">\r\n                <d" +
"iv class=\"card-body d-flex justify-content-between align-items-center\">\r\n       " +
"             <div>\r\n                        <span class=\"h4 d-block font-weight-" +
"normal mb-2\">");


            
            #line 64 "..\..\Views\Home\Index.cshtml"
                                                                    Write(ViewData["hourCount"].ToString());

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                        <span class=\"font-weight-light\">一小时之内</span>\r\n  " +
"                  </div>\r\n                    <div class=\"h2 text-muted\">\r\n     " +
"                   <i class=\"icon icon-clock\"></i>\r\n                    </div>\r\n" +
"                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div" +
" class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <ul class=\"nav nav-t" +
"abs\" role=\"tablist\">\r\n                <li class=\"nav-item\">\r\n                   " +
" <a class=\"nav-link active\" data-toggle=\"tab\" href=\"#hourChartPanel\" onclick=\"ge" +
"tLogChart(1)\" role=\"tab\" aria-controls=\"overview\" aria-selected=\"true\">小时</a>\r\n " +
"               </li>\r\n                <li class=\"nav-item\">\r\n                   " +
" <a class=\"nav-link\" data-toggle=\"tab\" href=\"#dayChartPanel\" onclick=\"getLogChar" +
"t(2)\" role=\"tab\" aria-controls=\"environment\" aria-selected=\"false\">天</a>\r\n      " +
"          </li>\r\n                <li class=\"nav-item\">\r\n                    <a c" +
"lass=\"nav-link\" data-toggle=\"tab\" href=\"#weekChartPanel\" onclick=\"getLogChart(3)" +
"\" role=\"tab\" aria-controls=\"environment\" aria-selected=\"false\">周</a>\r\n          " +
"      </li>\r\n                <li class=\"nav-item\">\r\n                    <a class" +
"=\"nav-link\" data-toggle=\"tab\" href=\"#monthChartPanel\" onclick=\"getLogChart(4)\" r" +
"ole=\"tab\" aria-controls=\"environment\" aria-selected=\"false\">月</a>\r\n             " +
"   </li>\r\n            </ul>\r\n\r\n            <div class=\"tab-content\">\r\n          " +
"      <div class=\"tab-pane active\" id=\"hourChartPanel\" role=\"tabpanel\">\r\n       " +
"             <div class=\"table-responsive\">\r\n                        <canvas id=" +
"\"hourChart\" width=\"100%\" height=\"20\"></canvas>\r\n                    </div>\r\n    " +
"            </div>\r\n                <div class=\"tab-pane\" id=\"dayChartPanel\" rol" +
"e=\"tabpanel\">\r\n                    <div class=\"table-responsive\">\r\n             " +
"           <canvas id=\"dayChart\" width=\"100%\" height=\"20\"></canvas>\r\n           " +
"         </div>\r\n                </div>\r\n                <div class=\"tab-pane\" i" +
"d=\"weekChartPanel\" role=\"tabpanel\">\r\n                    <div class=\"table-respo" +
"nsive\">\r\n                        <canvas id=\"weekChart\" width=\"100%\" height=\"20\"" +
"></canvas>\r\n                    </div>\r\n                </div>\r\n                " +
"<div class=\"tab-pane\" id=\"monthChartPanel\" role=\"tabpanel\">\r\n                   " +
" <div class=\"table-responsive\">\r\n                        <canvas id=\"monthChart\"" +
" width=\"100%\" height=\"20\"></canvas>\r\n                    </div>\r\n               " +
" </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"c" +
"ard\" style=\"margin-top: 3%\">\r\n    <div class=\"card-header bg-light\">\r\n        最近" +
"十条\r\n        <i class=\"fa fa-refresh\" onclick=\"loadList(1,10)\" style=\"float: righ" +
"t\"></i>\r\n    </div>\r\n    <div class=\"card-body\" id=\"LogList\">\r\n        <div clas" +
"s=\"table-responsive\">\r\n            <table class=\"table row mx-0\">\r\n             " +
"   <thead class=\"w-100\">\r\n                    <tr class=\"row mx-0\">\r\n           " +
"             <th class=\"col-1\">Id</th>\r\n                        <th class=\"col-3" +
"\">Logger</th>\r\n                        <th class=\"col-1\">级别</th>\r\n              " +
"          <th class=\"col-4\">消息</th>\r\n                        <th class=\"col-2\">时" +
"间</th>\r\n                        <th class=\"col-1\">详情</th>\r\n                    <" +
"/tr>\r\n                </thead>\r\n                <tbody class=\"w-100\">\r\n");


            
            #line 136 "..\..\Views\Home\Index.cshtml"
                     foreach (var item in logs)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <tr class=\"row mx-0\">\r\n                            <td cl" +
"ass=\"col-1\"><a href=\"javascript:void(0);\" onclick=\"logInfo(\'");


            
            #line 139 "..\..\Views\Home\Index.cshtml"
                                                                                         Write(item.Id.ToString());

            
            #line default
            #line hidden
WriteLiteral("\')\">");


            
            #line 139 "..\..\Views\Home\Index.cshtml"
                                                                                                                Write(item.Id.ToString());

            
            #line default
            #line hidden
WriteLiteral("</a></td>\r\n                            <td class=\"col-3\">");


            
            #line 140 "..\..\Views\Home\Index.cshtml"
                                         Write(item.Logger);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td class=\"col-1\"><button class=\"btn btn-outli" +
"ne-");


            
            #line 141 "..\..\Views\Home\Index.cshtml"
                                                                        Write(item.Level.ToUpper());

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 141 "..\..\Views\Home\Index.cshtml"
                                                                                               Write(item.Level.ToUpper());

            
            #line default
            #line hidden
WriteLiteral("</button></td>\r\n                            <td class=\"col-4\" onclick=\"$(this).ne" +
"xt().show();$(this).css(\'display\', \'none\');\">\r\n");


            
            #line 143 "..\..\Views\Home\Index.cshtml"
                                  
                                    var message = item.Message;
                                    if (message.Length > 90)
                                    {
                                        message = message.Substring(0, 90) + "........";
                                    }
                                

            
            #line default
            #line hidden
WriteLiteral("                                ");


            
            #line 150 "..\..\Views\Home\Index.cshtml"
                           Write(message);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td class=\"col-4" +
"\" style=\"display: none;\" onclick=\"$(this).prev().show();$(this).css(\'display\', \'" +
"none\');\">");


            
            #line 152 "..\..\Views\Home\Index.cshtml"
                                                                                                                                Write(item.Message);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td class=\"col-2\">");


            
            #line 153 "..\..\Views\Home\Index.cshtml"
                                         Write(item.LongDate.ToString("yyyy-MM-dd HH:mm:ss"));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td class=\"col-1\"><a href=\"javascript:void(0);" +
"\" onclick=\"logInfo(\'");


            
            #line 154 "..\..\Views\Home\Index.cshtml"
                                                                                         Write(item.Id.ToString());

            
            #line default
            #line hidden
WriteLiteral("\', \'logInfoModal\', \'logInfoBody\')\">详情</a></td>\r\n                        </tr>\r\n");


            
            #line 156 "..\..\Views\Home\Index.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral(@"                </tbody>
            </table>
        </div>
        <div class=""modal fade show"" id=""logInfoModal"" tabindex=""-1"">
            <div class=""modal-dialog modal-lg"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"">日志详情</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">×</span>
                        </button>
                    </div>
                    <div class=""modal-body"" id=""logInfoBody"">

                    </div>
                </div>
            </div>
        </div>
    </div>
</div>");


        }
    }
}
#pragma warning restore 1591
