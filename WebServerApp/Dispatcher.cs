using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;

namespace SimpleWebserver
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
                
                
                if (!_contextQueue.IsEmpty())
                {
                    var context = _contextQueue.Dequeue();
                    if(context!=null)
                    {
                        byte[] buffer=new byte [100];
                        var domainName = context.Request.Url.Authority;
                        var fileName = context.Request.RawUrl;
                        fileName = fileName.Remove(0, 1);
                        
                        if (context.Request.HttpMethod == "POST")
                        {

                            #region Temporary code
                            //var nameSpace = "SimpleWebserver.";
                            //var apiPath = _domainLookUp.GetApiPath(domainName);
                            //var methodInfo = Type.GetType(nameSpace + apiPath);
                            //ConstructorInfo classConstructor = methodInfo.GetConstructor(Type.EmptyTypes);
                            //object ClassObject = classConstructor.Invoke(new object[] { });

                            //var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding);

                            //string input = reader.ReadToEnd();
                            //JObject jObject = JObject.Parse(input);

                            //var value = methodInfo.GetMethod(fileName).Invoke(ClassObject, new object[] { jObject });



                            //buffer = Encoding.ASCII.GetBytes(value.ToString());

                            #endregion
                            ApiHandler apiHandler = new ApiHandler(context,fileName);
                            var apiPath = _domainLookUp.GetApiPath(domainName);
                            buffer = apiHandler.ConvertFileTOStream(apiPath);

                        }
                        else
                        {
                            FileHandler fileHandler = new FileHandler();
                            var domainPath = _domainLookUp.GetDomainPath(domainName);

                            if (fileName != "favicon.ico")
                            {
                                
                                buffer = fileHandler.ConvertFileTOStream(domainPath + fileName);                                                      
                            }
                        }
                        context.Response.ContentLength64 = buffer.Length;
                        context.Response.ContentType = context.Request.ContentType;
                        System.IO.Stream output = context.Response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        output.Close();

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