using System;
using System.Net;
using System.Threading;

namespace SimpleWebserver
{
    public class Listener
    {
        HttpListener httpListener = new HttpListener();
        private ContextQueue _contextQueue;
        private DomainLookUp _domainLookUp;
        public Listener(ContextQueue contextQueue, DomainLookUp domainLookUp)
        {
            this._contextQueue = contextQueue;
            this._domainLookUp = domainLookUp;
        }
        public void AddPrefix()
        {
            var domainPathDictionary = _domainLookUp.GetDomainPathDictionary();
            foreach (var prefix in domainPathDictionary.Keys)
            {
                httpListener.Prefixes.Add("http://"+prefix+"/");
            }
        }

        public void GetRequests()
        {
            Console.WriteLine("Listening...");
            while (true)
            {
                var context = httpListener.GetContext();
                if (context!=null)
                {
                    Console.WriteLine(context.Request.RawUrl);
                    _contextQueue.Enqueue(context);
                }
                //httpListener = new HttpListener();
                //AddPrefix();
                //httpListener.Start();
                
            }
        }
        public void Start()
        {

            httpListener.Start();
            Thread listenerThread = new Thread(() => GetRequests());
            listenerThread.Start();
        }
    }

}