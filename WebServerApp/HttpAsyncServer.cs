//using System;
//using System.Net;
//using System.Text;
//using System.Threading;

//namespace ExampleSimpleWebserver
//{
//    class HttpAsyncServer
//    {
//        private string[] listenedAddresses;
//        private bool isWorked;
//        private HttpListener listener;

//        string[] prefixes = new string[2];
//        prefixes[0] = "http://localhost:3000/";
//            prefixes[1] = "http://localhost:8080/";
//            var server = new HttpAsyncServer(prefixes);
//        server.RunServer();
//            Thread.Sleep(30000);
//            server.stop();
//        public HttpAsyncServer(string[] listenedAddresses)
//        {
//            this.listenedAddresses = listenedAddresses;
//            isWorked = false;
//        }

//        private void HandleRequest(HttpListenerContext context)
//        {
//        }

//        private void work()
//        {
//            listener = new HttpListener();
//            foreach (var prefix in listenedAddresses)
//                listener.Prefixes.Add(prefix);

//            listener.Start();

//            while (isWorked)
//            {
//                try
//                {
//                    var context = listener.GetContext();
//                    string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
//                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);

//                    context.Response.ContentLength64 = buffer.Length;
//                    System.IO.Stream output = context.Response.OutputStream;
//                    output.Write(buffer, 0, buffer.Length);
//                    // You must close the output stream.
//                    output.Close();
//                }
//                catch (Exception)
//                {

//                }
//            }
//            stop();
//        }

//        public void stop()
//        {
//            isWorked = false;
//            listener.Stop();
//        }


//        public void RunServer()
//        {
//            if (isWorked)
//                throw new Exception("server alredy started");

//            isWorked = true;

//            Timer t = new Timer((thread) =>
//            {
//                work();
//            });
//            t.Change(1, Timeout.Infinite);
//            Thread.Sleep(10);
//        }

//    }
//}