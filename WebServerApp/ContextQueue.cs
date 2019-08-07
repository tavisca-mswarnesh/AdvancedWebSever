using System.Collections.Generic;
using System.Net;

namespace ExampleSimpleWebserver
{
    public class ContextQueue
    {

        List<HttpListenerContext> _contextQueue = new List<HttpListenerContext>();
        public bool IsEmpty()
        {
            if (_contextQueue.Count == 0)
                return true;
            return false;
        }
        public void Enqueue(HttpListenerContext httpListener)
        {
            _contextQueue.Add(httpListener);
        }
        public HttpListenerContext Dequeue()
        {
            if (_contextQueue.Count == 0)
                return null;
            HttpListenerContext context= _contextQueue[0];
            _contextQueue.RemoveAt(0);
            return context;
        }
    }
}