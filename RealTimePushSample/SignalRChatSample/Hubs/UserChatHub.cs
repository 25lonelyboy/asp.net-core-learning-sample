using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatSample.Hubs
{
    public class UserChatHub : Hub
    {
        public async Task SendMessage(string toUserName, string message)
        {
            await Clients.User(toUserName).SendAsync("ReceiveMessage", $"{DateTime.Now}--{Context.UserIdentifier}--{message}");
        }
    }
}
