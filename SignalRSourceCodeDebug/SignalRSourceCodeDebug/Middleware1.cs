using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalRSourceCodeDebug
{
    public class Middleware1 : IHubPipelineModule
    {
        public Func<HubDescriptor, IRequest, bool> BuildAuthorizeConnect(Func<HubDescriptor, IRequest, bool> authorizeConnect)
        {
            return authorizeConnect;
        }

        public Func<IHub, Task> BuildConnect(Func<IHub, Task> connect)
        {
            return connect;
        }

        public Func<IHub, bool, Task> BuildDisconnect(Func<IHub, bool, Task> disconnect)
        {
            return disconnect;
        }

        public Func<IHubIncomingInvokerContext, Task<object>> BuildIncoming(Func<IHubIncomingInvokerContext, Task<object>> invoke)
        {
            return invoke;
        }

        public Func<IHubOutgoingInvokerContext, Task> BuildOutgoing(Func<IHubOutgoingInvokerContext, Task> send)
        {
            return send;
        }

        public Func<IHub, Task> BuildReconnect(Func<IHub, Task> reconnect)
        {
            return reconnect;
        }

        public Func<HubDescriptor, IRequest, IList<string>, IList<string>> BuildRejoiningGroups(Func<HubDescriptor, IRequest, IList<string>, IList<string>> rejoiningGroups)
        {
            return rejoiningGroups;
        }
    }
}