namespace ExampleSimpleWebserver
{
    class RunServer
    {
        public RunServer()
        {
            ContextQueue contextQueue = new ContextQueue();
            DomainLookUp domainLookUp = new DomainLookUp();
            domainLookUp.AddDomainPath("localhost:8080", @"C:\Users\vmattapalli\source\repos\WebServerApp\WebServerApp\bin\Debug\netcoreapp2.2\localhost1/");
            domainLookUp.AddDomainPath("localhost:3000", @"C:\Users\vmattapalli\source\repos\WebServerApp\WebServerApp\bin\Debug\netcoreapp2.2\localhost2/");


            Listener listener = new Listener(contextQueue, domainLookUp);
            listener.AddPrefix();
            listener.Start();
            
            Dispatcher dispatcher = new Dispatcher(domainLookUp, contextQueue);
            dispatcher.Start();
        }
    }
}