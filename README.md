# LogPanel

> NuGet：https://www.nuget.org/packages/NiuX.LogPanel/

 LogPanel 是在 Github 上开源的 NetStandard 项目, 它旨在帮助开发人员排查项目运行中出现错误时快速查看日志排查问题，适用于小型或初期项目进行快速过渡。

在 .NET 平台上，通常我们会在项目中使用 NLog、Log4Net 和 Serilog 等日志组件,它们用于记录日志的功能非常强大和完整,常见情况会将日志写到 `txt` 或 `数据库` 中, 但通过记事本和 sql 查看日志并不简单方便.  LogPanel 提供了一个可以简单快速查看日志的面板。

LogPanel 适用于 aspnetcore 2.x - aspnetcore5.x 项目, 采用 aspnetcore`中间件` 技术开发，轻量快速。

前端主要采用 Bootstrap（4.6）和 jQuery（3.6）。

# 快速开始

> Install-Package NiuX.LogPanel

1. 配置服务

   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       // 新增方法
       services.AddLogPanel();
   }
   ```

2. 配置中间件

   ```csharp
   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
   {
   	// 新增方法
       app.UseLogPanel();
   }
   ```

3. 启动后导航到路径：`/logpanel`

## 日志组件配置示例（NLog）

这里假设第一次配置日志组件，如果已经接入请忽略。

1. 安装包

```
Install-Package NLog.Web.AspNetCore
```

2. 引入配置文件（目前只支持`||`分割符）

   ```xml
   <?xml version="1.0" encoding="utf-8" ?>
   <nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
         xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
         autoReload="true"
         throwExceptions="false"
         internalLogLevel="Off" internalLogFile="c:\temp\nlog-internal.log">
   
     <variable name="myvar" value="myvalue"/>
   
     <targets>
       <target xsi:type="file" name="File" fileName="${basedir}/logs/${shortdate}.log"
               layout="${longdate}||${level}||${logger}||${message}||${exception:format=ToString:innerFormat=ToString:maxInnerExceptionLevel=10:separator=\r\n}||end" />
     </targets>
   
     <rules>
       <logger name="*" minlevel="Debug" writeTo="file" />
     </rules>
   </nlog>
   ```

3. Program.cs 中配置启用

   ```csharp
   public class Program
   {
       public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
               	// 调用 UseNLog()
                   webBuilder.UseStartup<Startup>().UseNLog();
               });
   }
   ```

# 页面预览

## 首页

![image-20210516135603548](https://note-sh-1304201078.file.myqcloud.com/images/image-20210516135603548.png)

实时查看应用程序运行中产生的日志

* 日志聚合
* 趋势图表
* 最近 N 条日志

## 列表

![image-20210516135730473](https://note-sh-1304201078.file.myqcloud.com/images/image-20210516135730473.png)

## 详情

![image-20210516140508610](https://note-sh-1304201078.file.myqcloud.com/images/image-20210516140508610.png)

复合检索所有日志并查看详情等操作

# 特性

* 授权访问
* 自定义日志模型
* 日志追踪
* 堆栈查看

## 支持的组件

- 日志
  - NLog
  - Log4Net
  - Serilog

- 数据源
  - txt
  - 数据库

# 参考 & 感谢

[LogDashboard](https://github.com/realLiangshiwei/LogDashboard)

