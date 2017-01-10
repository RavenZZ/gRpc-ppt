title: gRPC ppt
speaker: RavenZZ
url: https://github.com/RavenZZ/gRpc-ppt
transition: slide3
files: 
theme: moon
usemathjax: yes

[slide style="background-image:url('/img/hero-bg.png')"]
# grpc & protobuf
[slide style="background-image:url('/img/hero-bg.png')"]
## 什么是RPC 
----
* 远程过程调用协议 {:&.fadeIn}
* RPC使得开发包括网络分布式多程序在内的应用程序更加容易

[slide style="background-image:url('/img/hero-bg.png')"]
# grpc 的优势
----
* Simple service definition (定义服务简单) {:&.fadeIn}
    * Define your service using Protocol Buffers, a powerful binary serialization toolset and language
* Works across languages and platforms (可以用在各种语言和平台上)
    * Automatically generate idiomatic client and server stubs for your service in a variety of languages and platforms
* Start quickly and scale (快速上手和可扩展)
    * Install runtime and dev environments with a single line and also scale to millions of RPCs per second with the framework
* Bi-directional streaming and integrated auth (双向流和集成身份验证)
    * Bi-directional streaming and fully integrated pluggable authentication with http/2 based transport
[slide style="background-image:url('/img/hero-bg.png')"]

# 什么是 Protocol Buffers
----
* Protocol buffers are a language-neutral(语言中立), platform-neutral(平台中立) extensible mechanism for serializing structured data

[slide style="background-image:url('/img/hero-bg.png')"]
## 性能对比1 序列化数据对比 
----
![序列化数据对比](/img/compare1.png) {:&.fadeIn}

[slide style="background-image:url('/img/hero-bg.png')"]
## 性能对比2 bytes字节数对比 
----
![bytes字节数对比](/img/compare2.png) {:&.fadeIn}

[slide style="background-image:url('/img/hero-bg.png')"]
## 具体数字
----
![bytes字节数对比](/img/compare3.png) {:&.fadeIn}

[slide style="background-image:url('/img/hero-bg.png')"]
# grpc 开发步骤

1. Defining the service (定义服务)
1. Generating client and server code (生成客户端和服务端代码)
1. Creating the server
1. Creating the client


[slide style="background-image:url('/img/hero-bg.png')"]

# 支持的语言

1. C++
1. C#
1. Go
1. java
1. Android Java
1. Nodejs
1. Objective-C
1. PHP
1. Python
1. Ruby

[slide style="background-image:url('/img/hero-bg.png')"]


# gRPC Example

### 定义服务
----

<pre><code class="proto3">

syntax = "proto3";

option java_multiple_files = true;
option java_package = "md.logservice";
option java_outer_classname = "Logger";
option objc_class_prefix = "LLL";

package minglogger;

// The log service definition.
service LogService {
  // Sends a greeting
  rpc WriteLog (MingLog) returns (ExecuteResult) {}
  // ...
}

</code></pre>


[slide style="background-image:url('/img/hero-bg.png')"]

# MingLog definition

<pre><code class="proto3">

// The request message containing the user's name.
message MingLog {
  // 时间戳 
  // example: 1483583631190
  int32 timeStamp = 1;
  //服务器主机名
  // example: cw_web,cw_meihua
  string hostName = 2;
  //服务类型
  // example : Master= 主站
  ServiceType serviceType = 3;
  // 日志记录者
  // example: Raven
  // 每个人一个id, 不要乱变
  string author = 4;
  // 服务Ip
  string  clientIp = 5;
  // 错误Stack信息
  string stack = 6;
  // 日志文本信息
  string message = 7;
  // 操作类型
  //example: "createtask","sendpush"
  string action = 8;
  // 当前用户accountid
  string accountId = 9;
  //当前用户projectid
  string projectId = 10;
  //其他有用的信息字典
  repeated Extras extras = 11;
}

</code></pre>

[slide style="background-image:url('/img/hero-bg.png')"]

# 枚举定义

<pre><code class="proto3">
// 其他有用的信息
message Extras {
	string key = 1;
    string value = 2;
}
// 操作执行结果
message ExecuteResult {
	// 操作是否执行成功
	bool isSuccess = 1;
	// 错误信息
    string error = 2;
}

// 日志级别
enum LogLevel{
	// 对调试应用程序是非常有帮助
	Debug = 0;
	// 突出强调应用程序的运行过程
	Info = 1;
	// 会出现潜在错误的情形
	Warn = 2;
	// 已出现的错误, 但不影响系统的继续运行
	Error = 3;
	// 严重的错误事件将会导致应用程序的退出
	Fatal = 4;
}

enum ServiceType {
	//未知
	Unknown = 0;
	//主站
	//mingdao.com
	//repo: MD_Public
	//folder: MHMD.Web
	Master = 1;
	//API
	//api.mingdao.com
	//repo: MD_Public
	//folder: MD.API
	API = 2;
	// 日程Push服务
	// Windows服务
	//repo: MD_Public
	//folder: MD.CalendarService
	CalendarService = 3;
	// 项目统计服务
	//repo: MD_Public
	//folder: FolderStatisticsService
	FolderStatistics = 4;
	//RabbitMQ Solor 消费端服务
	//repo: MD_Public
	//MD.RabbitMQConsumerService
	RabbitMQSolorConsumerService = 5;
	// 发送邮件服务
	//repo: MDServices-CSharp
	//folder: MD.Email.API
	EmailSenderService = 6;
	// 短信服务
	//repo: MDServices-CSharp
	//folder: MD.Sms.API
	SmsSenderService = 7;
	// WebHook 
	//repo: MDServices-CSharp
	//folder: MD.WebHook.API
	WebHook = 8;
	// Chat Socket 连接
	//repo: MDNode
	//folder: MD.Messager
	ChatSocket = 9;
	// Chat 内部API
	//repo: MDNode
	//folder: MD.Messager
	ChatApi = 10;
	// Chat HTTP 
	// chatmq.mingdao.com
	//repo: MDNode
	//folder: MD.Messager
	ChatHttp = 11;
	// Chat 群聊头像服务
	// avatar.mingdao.com
	//repo: MDNode
	//folder: MD.Messager
	ChatAvatar = 12;
	// Chat 队列服务
	//repo: MDNode
	//folder: MD.Messager
	ChatQueue = 13;
	// 邮件连接器
	//repo: MDNode 
	//folder: MD.Mail_v2
	MyMail = 14;
	// 邮件连接器 扫描本地文件上传服务
	//repo: MDNode
	//folder: uploadqiniu
	MyMailUploader = 15;
	// 邮件连接器 静态附件承载服务
	//repo: MDNode
	//folder: MD.MailFileserver
	MyMailFileService = 16;
	// 运维工具
	//repo: MDTools
	//folder: /
	OpTool = 17;
	// 三方账号联合登录服务
	//repo: MDServices
	//folder: MD.TPLogin
	TpLogin = 18;
	// 短链生成服务
	//repo: MDServices
	//folder: MD.UrlParser
	UrlParser = 19;
	// 微信公众号服务
	//repo: MDServices
	//folder: MD.Weixin
	WeixinMPService = 20;
	// 明道大使
	//repo: MDServices
	//folder: MD.LP
	LP=21;
	// OWA
	//repo: MDServices
	//folder: MD.OWA
	OwaService = 22;
	// 实体关联服务
	//repo: MDServices
	//folder: MD.Relation
	RelationService = 23;
	//计数服务(外网)
	//mq.mingdao.com
	//repo: MDNotification 
	//folder: MD.Notification
	Counting = 24;
	// 计数服务(内网)
	//repo: MDNotification 
	//folder: MD.Notification
	CountingInternal = 25;
	// App Push 服务
	//repo: MDNotification
	//folder: MD.PushMQ
	PushQueue = 26;
	// Push Server API 服务
	//repo: MDNotification
	//folder: MD.Pushserver
	PushServer = 27;
	// 会议室预定
	//repo: MDApps 
	//folder: MD.bookMeeting
	Meetingroom=28;
	// 开放平台
	//open.mingdao.com
	//repo: MDOpen
	//folder: MDOpen
	Open = 29;
	//Manage
	//manage.mingdao.com
	//repo: MDManage
	//folder: /
	MDManage = 30;
	// 审批
	//repo: MDPlus 
	//folder: /
	Approval = 31;
	// OA
	//repo: MDOA
	//folder: /
	OA = 32;
	// Mingdao内部 CRM
	//repo: MDCRM2.0 
	//folder: /
	MDCRM = 33;
}
</code></pre>
[slide style="background-image:url('/img/hero-bg.png')"]

# 生成C#代码

<pre><code class="bash">
setlocal

@rem enter this directory
cd /d %~dp0

set TOOLS_PATH=Tools\Grpc.Tools.0.15.0\tools\windows_x64

%TOOLS_PATH%\protoc.exe -I./protos --csharp_out MD.Logger  
    ./protos/minglog.proto --grpc_out MD.Logger 
    --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe

endlocal
</code></pre>

[slide style="background-image:url('/img/hero-bg.png')"]

# 实现C#服务端代码
<pre><code class="CSharp">
using System;
using Grpc.Core;
using Minglogger;

namespace MD.Logger.Impl
{
    public class LoggerImpl : LogService.LogServiceBase
    {
        public override Task<ExecuteResult> WriteLog(MingLog request, ServerCallContext context)
        {
            RedisProvider.LogStashRedisInstance.AddItemToList(RedisKeys.LogStashWebErrorMessageKey, request);

            return Task.FromResult(new ExecuteResult { Error = string.Empty, IsSuccess = true });
        }
    }
}
</code></pre>

<pre><code class="CSharp">
    Server server = new Server
    {
        Services = {Minglogger.LogService.BindService(new LoggerImpl())},
        Ports = {new ServerPort("localhost", 50001, ServerCredentials.Insecure)}
    };
    server.Start();

</code></pre>
[slide style="background-image:url('/img/hero-bg.png')"]

# C# 客户端调用方式
<pre><code class="CSharp">
    Channel channel = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure)
    logServiceClient = new LogService.LogServiceClient(channel);

    logServiceClient.WriteLog(minglogEntity);
    channel.ShutdownAsync().Wait();

</code></pre>


[slide style="background-image:url('/img/hero-bg.png')"]

# Nodejs 

[slide style="background-image:url('/img/hero-bg.png')"]

# nginx 水平扩展 + 负载均衡
<pre><code class="nginx">

stream {
    upstream stream_backend {
        server 127.0.0.1:50051;
        server 127.0.0.1:50052;
    }

    server {
        listen 8082 http2; #support http2
        proxy_pass stream_backend;
    }
}

</code></pre>

[slide style="background-image:url('/img/hero-bg.png')"]


# 友情链接

[使用 Protocol Buffers 代替 JSON 的五个原因 ](http://www.oschina.net/translate/choose-protocol-buffers)
