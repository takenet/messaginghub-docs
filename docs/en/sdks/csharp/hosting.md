### Hosting

Chatbots created using SDK template must be hosted in a particular user server.

When application is started a *TCP* connection is established with BLiP MessagingHub server using the port 55321. All communication is made using [Lime](http://limeprotocol.org/) protocol.

#### Hosting on IIS

The `Takenet.MessagingHub.Client.WebTemplate` package enable to create a chatbot as a ASP.NET aplication and than host it on **IIS**. In fact this package is a **OWIN** *wrapper* to start the BLiP client but without use **HTTP** connection. For this reason you must configure the IIS *application pool* to keep your application alive and not be automatically recycled.

In order to use this histing option is necessary create a empty web project. On Visual Studio, click on **File > New > Project...** and then **Visual C#**, choice **ASP.NET Web Application** and use a .NET Framework version **4.6.1** or above. On template window choice a **Empty** option and unmark all options on **Add folders and core references** section.

A empty project will be created only with *Web.config* file. Now you must install the `Takenet.MessagingHub.Client.WebTemplate` package on **Package Manager Console** using the following command:

```
Install-Package Takenet.MessagingHub.Client.WebTemplate
```

After install the package you can create your chatbot and configure the `application.json` file normally. Locally tests can be done using Visual Studio *Debug* (run F5). Can be necessary access the application URL to the application be starter on the first time.

#### Hosting as a Windows service

It's possible use `mmh.exe` (installed with `Takenet.MessagingHub.Client.Host` package) tool as a Windows service. Thus, your chatbot can continuously run without any user session.

In order to host your chatbot as a server use the following command:
```
mhh.exe install -serviceName ServiceName
```

In order to start a previosly created service use the Windows `services.msc` tool with `sc` command:
```
sc start ServiceName
```

In order to uninstall the service use the following command:
```
mhh.exe uninstall -serviceName ServiceName
```
