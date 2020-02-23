using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetClientSample
{
    class Program
    {
        static void Main(string[] args)
        {

            HubConnection hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:57634/chatHub")
                .Build();

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine($"{user}:{message}");
            });

            try
            {
                hubConnection.StartAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Random random = new Random(Guid.NewGuid().GetHashCode());

            while (true)
            {
                try
                {
                    hubConnection.InvokeAsync("SendMessage", "dotnetclient", random.NextDouble());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Task.Delay(TimeSpan.FromSeconds(2)).Wait();
            }
        }
    }
}
