using CoAP.Server.Resources;
using Newtonsoft.Json;

namespace Server.Resources
{
    class JsonObjectResource : CoAP.Server.Resources.Resource
    {

        // URL path
        public JsonObjectResource() : base("object_test")
        {
            // set a friendly title
            Attributes.Title = "GET a friendly greeting!";
        }

        // override this method to handle GET requests
        protected override void DoGet(CoapExchange exchange)
        {

            var obj = new JsonObjectTest();
            obj.Number = 12345;
            obj.String = "This is a string from an object";

            // Convert to JSON string with JSON.NET
            var json = JsonConvert.SerializeObject(obj);

            // now we get a request, respond it
            exchange.Respond(json);
        }

    }
}
