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

namespace NiuX.LogPanel.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class _layout : NiuX.LogPanel.Views.RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n\r\n");


WriteLiteral(@"
<!doctype html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"">
    <meta http-equiv=""X-UA-Compatible"" content=""ie=edge"">
    <title>日志面板</title>
    <link href=""");


            
            #line 12 "..\..\Views\_layout.cshtml"
           Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/css.simple-line-icons.css\" rel=\"stylesheet\">\r\n    <link href=\"https://cdn.bootcd" +
"n.net/ajax/libs/twitter-bootstrap/4.6.0/css/bootstrap.min.css\" rel=\"stylesheet\">" +
"\r\n    ");



WriteLiteral("\r\n    ");



WriteLiteral("\r\n    <link href=\"");


            
            #line 16 "..\..\Views\_layout.cshtml"
           Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/css.font-awesome.min.css\" rel=\"stylesheet\">\r\n    <link href=\"");


            
            #line 17 "..\..\Views\_layout.cshtml"
           Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/css.tempusdominus-bootstrap-4.min.css\" rel=\"stylesheet\">\r\n    <link rel=\"stylesh" +
"eet\" href=\"");


            
            #line 18 "..\..\Views\_layout.cshtml"
                            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral(@"/css.styles.css"">
</head>
<body class=""sidebar-fixed header-fixed"">
<div class=""page-wrapper"">
    <nav class=""navbar page-header"">
        <a href=""#"" class=""btn btn-link sidebar-mobile-toggle d-md-none mr-auto"">
            <i class=""fa fa-bars""></i>
        </a>
        <a class=""navbar-brand"" href=""#"" target=""_blank"">
            <h2>");


            
            #line 27 "..\..\Views\_layout.cshtml"
           Write(Context.Options.Brand);

            
            #line default
            #line hidden
WriteLiteral(@"</h2>
        </a>
        <a href=""#"" class=""btn btn-link sidebar-toggle d-md-down-none"">
            <i class=""fa fa-bars""></i>
        </a>
        <ul class=""navbar-nav ml-auto"">
            <li class=""nav-item d-md-down-none"">
                <a href=""/"">
                    <i class=""fa fa-reply-all""></i>

                </a>
            </li>
        </ul>
    </nav>
    <div class=""main-container"">
        <div class=""sidebar"">
            <nav class=""sidebar-nav"">
                <ul class=""nav"">
                    <li class=""nav-title"">菜单</li>
                    <li class=""nav-item"">
                        <a id=""mapPath"" href=""");


            
            #line 47 "..\..\Views\_layout.cshtml"
                                         Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("\" class=\"nav-link ");


            
            #line 47 "..\..\Views\_layout.cshtml"
                                                                                     Write(ViewData["panelNav"]);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <i class=\"icon icon-speedometer\"></i> 首页\r\n       " +
"                 </a>\r\n                    </li>\r\n                    <li class=" +
"\"nav-item\">\r\n                        <a href=\"");


            
            #line 52 "..\..\Views\_layout.cshtml"
                            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/home/basic\" class=\"nav-link ");


            
            #line 52 "..\..\Views\_layout.cshtml"
                                                                                   Write(ViewData["basicLogNav"]);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <i class=\"icon icon-target\"></i> 日志（所有）\r\n        " +
"                </a>\r\n                    </li>\r\n                    <li class=\"" +
"nav-item\">\r\n                        <a href=\"");


            
            #line 57 "..\..\Views\_layout.cshtml"
                            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/home/basic?level=Trace\" class=\"nav-link ");


            
            #line 57 "..\..\Views\_layout.cshtml"
                                                                                               Write(ViewData["basicLogNav"]);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <i class=\"icon icon-target\"></i> Trace\r\n         " +
"               </a>\r\n                    </li>\r\n                    <li class=\"n" +
"av-item\">\r\n                        <a href=\"");


            
            #line 62 "..\..\Views\_layout.cshtml"
                            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/home/basic?level=Debug\" class=\"nav-link ");


            
            #line 62 "..\..\Views\_layout.cshtml"
                                                                                               Write(ViewData["basicLogNav"]);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <i class=\"icon icon-target\"></i> Debug\r\n         " +
"               </a>\r\n                    </li>\r\n                    <li class=\"n" +
"av-item\">\r\n                        <a href=\"");


            
            #line 67 "..\..\Views\_layout.cshtml"
                            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/home/basic?level=Info\" class=\"nav-link ");


            
            #line 67 "..\..\Views\_layout.cshtml"
                                                                                              Write(ViewData["basicLogNav"]);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <i class=\"icon icon-target\"></i> Info\r\n          " +
"              </a>\r\n                    </li>\r\n                    <li class=\"na" +
"v-item\">\r\n                        <a href=\"");


            
            #line 72 "..\..\Views\_layout.cshtml"
                            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/home/basic?level=Warn\" class=\"nav-link ");


            
            #line 72 "..\..\Views\_layout.cshtml"
                                                                                              Write(ViewData["basicLogNav"]);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <i class=\"icon icon-target\"></i> Warn\r\n          " +
"              </a>\r\n                    </li>\r\n                    <li class=\"na" +
"v-item\">\r\n                        <a href=\"");


            
            #line 77 "..\..\Views\_layout.cshtml"
                            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/home/basic?level=Error\" class=\"nav-link ");


            
            #line 77 "..\..\Views\_layout.cshtml"
                                                                                               Write(ViewData["basicLogNav"]);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <i class=\"icon icon-target\"></i> Error\r\n         " +
"               </a>\r\n                    </li>\r\n                    <li class=\"n" +
"av-item\">\r\n                        <a href=\"");


            
            #line 82 "..\..\Views\_layout.cshtml"
                            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/home/basic?level=Fatal\" class=\"nav-link ");


            
            #line 82 "..\..\Views\_layout.cshtml"
                                                                                               Write(ViewData["basicLogNav"]);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <i class=\"icon icon-target\"></i> Fatal\r\n         " +
"               </a>\r\n                    </li>\r\n                </ul>\r\n         " +
"   </nav>\r\n        </div>\r\n        <div class=\"content\" id=\"content\">\r\n         " +
"   ");


            
            #line 90 "..\..\Views\_layout.cshtml"
       Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<script src=\"https://cdn.bootcdn.net/ajax/l" +
"ibs/jquery/3.6.0/jquery.min.js\"></script>\r\n");



WriteLiteral("\r\n<script src=\"https://cdn.bootcdn.net/ajax/libs/twitter-bootstrap/4.6.0/js/boots" +
"trap.min.js\"></script>\r\n    ");



WriteLiteral("\r\n    ");



WriteLiteral("\r\n    <script src=\"");


            
            #line 99 "..\..\Views\_layout.cshtml"
            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/js.Chart.min.js\"></script>\r\n    ");



WriteLiteral("\r\n    <script src=\"");


            
            #line 101 "..\..\Views\_layout.cshtml"
            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/js.moment.min.js\"></script>\r\n    <script src=\"");


            
            #line 102 "..\..\Views\_layout.cshtml"
            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/js.tempusdominus-bootstrap-4.js\"></script>\r\n    <script src=\"");


            
            #line 103 "..\..\Views\_layout.cshtml"
            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/js.spin.min.js\"></script>\r\n    <script src=\"");


            
            #line 104 "..\..\Views\_layout.cshtml"
            Write(Context.Options.PathMatch);

            
            #line default
            #line hidden
WriteLiteral("/js.log.js\"></script>\r\n    ");


            
            #line 105 "..\..\Views\_layout.cshtml"
Write(RenderSection("Scripts"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</body>\r\n</html>\r\n");


        }
    }
}
#pragma warning restore 1591
