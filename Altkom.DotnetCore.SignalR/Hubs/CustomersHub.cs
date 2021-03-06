﻿using Altkom.DotnetCore.Models;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.SignalR.Hubs
{
    public class CustomersHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Trace.WriteLine($"{Context.ConnectionId}");

            return base.OnConnectedAsync();
        }

        public async Task SendCustomerAdded(Customer customer)
        {
            // await Clients.All.SendAsync("AddedCustomer", customer);
            await Clients.Others.SendAsync("AddedCustomer", customer);
        }

        public async Task Ping(string message)
        {
            await Clients.Caller.SendAsync("Pong", message);
        }
    }
}
