using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace SimpleWebserver
{
    class ApiHandler
    {
        private HttpListenerContext _context;
        private string _apiName;
        public ApiHandler(HttpListenerContext context,string apiName)
        {
            _context = context;
            _apiName = apiName;
        }
        public string GetApi(string filePath)
        {



            return filePath;
        }

        public byte[] ConvertFileTOStream(string apiPath)
        {
            byte[] buffer;
            try
            {
                string nameSpace = "SimpleWebserver.";
                var methodInfo = Type.GetType(nameSpace + apiPath);
                ConstructorInfo classConstructor = methodInfo.GetConstructor(Type.EmptyTypes);
                object ClassObject = classConstructor.Invoke(new object[] { });

                var reader = new StreamReader(_context.Request.InputStream, _context.Request.ContentEncoding);

                string input = reader.ReadToEnd();
                JObject jObject = JObject.Parse(input);

                var value = methodInfo.GetMethod(_apiName).Invoke(ClassObject, new object[] { jObject });
                buffer = Encoding.ASCII.GetBytes(value.ToString());
            }
            catch 
            {

                string page = "API NOT FOUND";
                _context.Response.StatusCode = 404;
                buffer = Encoding.ASCII.GetBytes(page);
            }
            return buffer;
        }
    }
}