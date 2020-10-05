using Altkom.DotnetCore.Fakers;
using Altkom.DotnetCore.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.SenderConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string url = "http://localhost:5000/signalr/customers";


            Console.WriteLine("Hello Signal-R Sender!");

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            Console.WriteLine("Connectig...");
            await connection.StartAsync();
            Console.WriteLine("Connected!");

            CustomerFaker customerFaker = new CustomerFaker();
            Customer customer = customerFaker.Generate();

            Console.WriteLine($"Sending {customer.FirstName} {customer.LastName}");
            await connection.SendAsync("AddedCustomer", customer);
            Console.WriteLine("Customer send");
            Console.ReadKey();
        }
    }
}
