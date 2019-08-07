using System.Collections.Generic;
using System.Threading;

namespace ExampleSimpleWebserver
{
    class Dispatcher
    {
        private ContextQueue _contextQueue;
        private DomainLookUp _domainLookUp;
        public Dispatcher(DomainLookUp domainLookUp,ContextQueue contextQueue)
        {
            _contextQueue = contextQueue;
            _domainLookUp = domainLookUp;
        }
        public void GetResposeToRequest()
        {
            while (true)
            {
                FileHandler fileHandler = new FileHandler();
                if (!_contextQueue.IsEmpty())
                {
                    var context = _contextQueue.Dequeue();
                    if(context!=null)
                    {
                        var domainName = context.Request.Url.Authority;
                        var fileName = context.Request.RawUrl;
                        fileName = fileName.Remove(0, 1);
                        if (fileName!="favicon.ico")
                        {
                            var domainPath = _domainLookUp.GetDomainPath(domainName);
                            byte[] buffer = fileHandler.ConvertFileTOStream(domainPath + fileName);

                            context.Response.ContentLength64 = buffer.Length;
                            System.IO.Stream output = context.Response.OutputStream;
                            output.Write(buffer, 0, buffer.Length);
                            output.Close();
                        }
                        
                    }
                }
            }
            
        }
        public void Start()
        {
            Thread dispatcheraThread = new Thread(() => GetResposeToRequest());
            dispatcheraThread.Start();
        }
    }
}