﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Json;
using Microsoft.Owin;
using System.Diagnostics;

namespace Microsoft.AspNet.SignalR.Owin.Middleware
{
    public class HubDispatcherMiddleware : OwinMiddleware
    {
        private readonly HubConfiguration _configuration;

        public HubDispatcherMiddleware(OwinMiddleware next, HubConfiguration configuration)
            : base(next)
        {
            _configuration = configuration;
        }

        public override Task Invoke(IOwinContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (JsonUtility.TryRejectJSONPRequest(_configuration, context))
            {
                return TaskAsyncHelper.Empty;
            }

            var dispatcher = new HubDispatcher(_configuration);

            dispatcher.Initialize(_configuration.Resolver);

            Debug.WriteLine(context.Request.Uri.ToString());

            return dispatcher.ProcessRequest(context.Environment);
        }
    }
}
