using CoAP.Server.Resources;

namespace Server.Resources
{
    class MessageResource : CoAP.Server.Resources.Resource
    {

        // Set the URL path
        public MessageResource() : base("message")
        {
            // set a friendly title
            Attributes.Title = "GET a friendly greeting!";
        }

        // override this method to handle GET requests
        protected override void DoGet(CoapExchange exchange)
        {
            // now we get a request, respond it
            exchange.Respond("Hello client, I received your message: \"" + exchange.Request.PayloadString + "\"");
        }

    }
}
