using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace DotNetClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            HubConnection hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:55859/chatHub")
                .Build();
            //注册监听，监听消息接收事件
            hubConnection.On<string, string>("ReceiveMessage", (userName, message) =>
            {
                Console.WriteLine($"{userName}: {message}");
            });

            try
            {
                hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Random random = new Random(Guid.NewGuid().GetHashCode());
            while (true)
            {
                try
                {
                    hubConnection.InvokeAsync("SendMessage", "dotNetClient", random.NextDouble());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Task.Delay(TimeSpan.FromSeconds(2)).Wait();
            }
        }
    }
}
