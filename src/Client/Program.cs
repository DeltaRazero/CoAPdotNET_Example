using Newtonsoft.Json;
using System;
using System.Threading;

namespace Client
{
    class Program
    {

        static void Main(string[] args)
        {
            // .NET Core 2.x project
            // Uses JSON.NET and CoAP.NET.Core Nuget packages (restore them with solution context menu option)
            // For standard .NET, use CoAP.NET


            // Setup sender
            var coap_sender = new CoAP.CoapClient();

            // You can set the the URL here or set it per request (see below)
            coap_sender.Uri = new Uri("coap://127.0.0.1/helloworld");

            // You can send a request with the Uri that is already set in the CoapClient object
            var response= coap_sender.Get();

            // The result's string (a.k.a. the payload string)
            Console.WriteLine(response.PayloadString);



            // You can also use a request object to send requests to the server.

            // Set the CoAP Method enum for which type of request you want to sent
            // See http://open.smeshlink.com/CoAP.NET/examples/client/#using-coap-request for available
            // methods that you can use in requests.
            CoAP.Request request = new CoAP.Request(CoAP.Method.GET);
            request.URI = new Uri("coap://127.0.0.1/message");

            // You can attach a payload (bytes) or payloadstring (obviously string) to a request obj
            request.SetPayload("This is a message from the sender");

            // Send the request
            request.Send();

            // Wait for a response until a timeout
            response = request.WaitForResponse();
            Console.WriteLine(response.PayloadString);



            // It's also possible to send or get an object, in the form of a JSON encoded string (or XML if you like that)
            request = new CoAP.Request(CoAP.Method.GET);
            request.URI = new Uri("coap://127.0.0.1/object_test");
            request.Send();
            response = request.WaitForResponse();

            // I use Newtonsoft's JSON.NET (available in the Nuget package manager) to convert between JSON and objects
            // For JSON converter docs, see: https://www.newtonsoft.com/json
            // The object to decode here is referenced from "Server" project.
            var decoded_obj = JsonConvert.DeserializeObject<Server.Resources.JsonObjectTest>(response.PayloadString);

            Console.WriteLine("Number: " + decoded_obj.Number.ToString() + "    String: " + decoded_obj.String);



            Thread.Sleep(new TimeSpan(0, 0, 6) );
        }

    }
}
