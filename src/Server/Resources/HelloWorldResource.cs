using CoAP.Server.Resources;

namespace Server.Resources
{
    class HelloWorldResource : CoAP.Server.Resources.Resource
    {

        // use "helloworld" as the path of this resource
        public HelloWorldResource() : base("helloworld")
        {
            // set a friendly title
            Attributes.Title = "GET a friendly greeting!";
        }

        // override this method to handle GET requests
        protected override void DoGet(CoapExchange exchange)
        {
            // now we get a request, respond it
            exchange.Respond("Hello World!");
        }


    }
}
