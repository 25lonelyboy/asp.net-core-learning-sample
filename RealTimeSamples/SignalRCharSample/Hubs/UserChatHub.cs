using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRCharSample.Hubs
{
    [Authorize]
    public class UserChatHub: Hub
    {
        public async Task SendMessage(string toUserName, string message)
        {
            await Clients.User(toUserName).SendAsync("ReceiveMessage", $"{DateTime.Now}--{Context.UserIdentifier}--{message}");
        }
    }
}
