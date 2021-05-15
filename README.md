## Jaroszek.PoC.SignalRChat ###

The project includes a server application and clients.
Server application prepared in net5 using pure architecture. In this case the domain and application layers are at the centre of the project - this is the core of the system. The domain layer contains logic and types specific for the problem the application solves, the application layer contains logic and business types. Using such a division allows the domain logic to be shared by many systems while the business logic will be used only in a particular system.

Core should not be dependent on data access and other infrastructure issues, these dependencies are reversed by adding interfaces or abstractions in Core that are implemented in by layers outside of Core.

All dependencies flow inwards, and Core is not dependent on any other layer.

The application has an implementation of SignalR, Hangfire - Controller Api accepts a request and delegates it for execution by returning OK (200) responses, Hangfire executes the corresponding request using MediatR after the request is executed a notification is generated on the commandHandler side which is propagated to clients via SignalR.

The first possibility to verify the operation of the application is Swagger, the next possibility is to display a web page:
```
https://localhost:5001/chat.html
```
It was prepared in html based on libman library.
The last way to test is to run WPF client application - this application was built based on Prism, unity - all communication was based on Events and communication with the server was placed in ShellBackgroundService.

To fully verify the solution you need to run the server and all clients.

Server part has tests, which are placed in tests directory, to run them go to directory:
```
server tests
```
and issue a command from the command line:
```
dotnet test
```

To start the server, go to the location from the command line:
```
srcJaroszek.PoC.SignalRChat.WebUI
```
and issue the command 
```
dotnet run
```

Translated with www.DeepL.com/Translator (free version)
