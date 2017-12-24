using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRSourceCodeDebug
{
    public class MyHub1 : Hub
    {
        public void Hello(string hello, IProgress<int> progress)
        {
            for (int i = 0; i < 10; ++i)
            {
                progress.Report(i * 100);
            }
            Clients.All.Hello("haha");
        }

        public void Hello(string hello)
        {
          
            Clients.All.Hello("hahaxxxx");
        }

        public void Hello(int hello)
        {
            Clients.All.Hello("hahaxxxxxxxjjjjj");
            
        }
    }
}