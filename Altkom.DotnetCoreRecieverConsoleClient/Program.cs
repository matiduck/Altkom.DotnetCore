using Altkom.DotnetCore.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Altkom.DotnetCoreRecieverConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string url = "http://localhost:5000/signalr/customers";
            Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine("Hello Signal-R Client!");

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            Console.WriteLine("Connectig...");
            await connection.StartAsync();
            Console.WriteLine("Connected!");

            connection.On<Customer>("AddedCustomer", customer => Console.WriteLine($"Recieved {customer.FirstName} {customer.LastName}"));
            Console.ReadKey();
        }
    }
}
