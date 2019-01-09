using System.Threading;
using Server.Resources;

namespace Server
{
    class Program
    {

        static void Main(string[] args)
        {
            // .NET Core 2.x project
            // Uses JSON.NET and CoAP.NET.Core Nuget packages (restore them with solution context menu option)
            // For standard .NET, use CoAP.NET


            // Start server with specified ports
            // The IP is set to local host here
            var server = new CoAP.Server.CoapServer(5683);

            // Add the resource classes.
            // These will handle the incoming requests of specific devices, sensors, actuators or whatever thing.
            server.Add(new HelloWorldResource() );
            server.Add(new JsonObjectResource() );
            server.Add(new MessageResource() );

            // Start up the server
            server.Start();


            Thread.Sleep(-1); // Freeze thread
        }

    }
}
