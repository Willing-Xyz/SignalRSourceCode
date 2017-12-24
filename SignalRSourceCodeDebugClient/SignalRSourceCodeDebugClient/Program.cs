using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRSourceCodeDebugClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = new HubConnection("http://localhost:10084/signalr");

            var proxy = conn.CreateHubProxy("MyHub1");
            conn.Start(new LongPollingTransport()).Wait();
            //conn.Start().Wait();
            //conn.Start(new WebSocketTransport()).Wait();

            proxy.On("Hello", (s) => {
                Console.WriteLine(s);
            });

            proxy.Invoke<int>("Hello", (a) => {
                Console.WriteLine("progress..." + a);
            }, "test").Wait();

            // Main(args);

            Console.ReadKey();
        }
    }
}
