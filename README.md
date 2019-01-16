# CoAP.NET Example
Example for CoAP.NET(.Core) library (http://open.smeshlink.com/CoAP.NET/).
This example is for .NET Core 2.x, but the usage of the libraries present should be almost, if not exactly, the same as with latest standard .NET.

Each project can have both a sender and receiver, but that has been left out for this example; one application only acts as a receiver, while the other will act as a sender only.


## Dependencies
This project is a Visual Studio 2017 project and requires .NET Core 2.x. The code used to demonstrate the CoAP and JSON converting should be compatible with latest standard .NET.

The project uses the following packages and can be restored through the Nuget package manager: 
* CoAP.NET.Core
* JSON.NET


## Build & Run
Build the release (or debug) binaries within Visual Studio.

You can run the binaries with the commands below. Run them in two unique instances of terminal/commandprompt:
```
dotnet server.dll
dotnet client.dll
```
Run the server first, otherwise the client will try to make requests to nothing.
