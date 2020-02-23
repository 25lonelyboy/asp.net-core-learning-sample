using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChatSample.Hubs;

namespace SignalRChatSample.Controllers
{
    public class SendController : Controller
    {
        private readonly IHubContext<ChatHub> hubContext;
        public SendController(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send(string userName, string message)
        {
            hubContext.Clients.All.SendAsync("ReceiveMessage", userName, message);
            return View();
        }
    }
}