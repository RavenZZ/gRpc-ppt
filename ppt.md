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

# 封面样式
## h1是作为封面用的，内部的都用h2
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


# 友情链接

[使用 Protocol Buffers 代替 JSON 的五个原因 ](http://www.oschina.net/translate/choose-protocol-buffers)
