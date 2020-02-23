using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatSample.Hubs
{
    public class ChatHub : Hub
    {
        /// <summary>
        /// 客户端向服务端发送数据的方法
        /// 客户端可以通过方法名称直接调用
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        public async void SendMessage(string user, string message)
        {
            //服务端向客户端发送数据
            //也是直接调用客户端的方法，将数据作为参数传递
            await Clients.All.SendAsync("ReceiveMessage", user, DateTime.Now + "---" + message);
        }

        public async void SendMessageToCaller(string message)
        {
            //回发，向自身发消息
            await Clients.Caller.SendAsync("ReceiverMessage", message);
        }

        public async void SendMessageToGroup(string message)
        {
            var groups = new List<string>() { "group1", "group2" };
            //组的概念是基于连接的，不是基于用户，用户不同设备登陆的连接，可以不在同一个组
            //向多个组发送消息
            await Clients.Groups(groups).SendAsync(message);
            //向指定的组发送消息
            //await Clients.Group("group1").SendAsync(message);
        }

        /// <summary>
        /// 连接建立的时候的事件
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            //Groups是全局的变量，用于存储组别信息
            //Context是当前连接的上下文，相当于Http中的连接上下文，可以拿到当前连接的信息
            await Groups.AddToGroupAsync(Context.ConnectionId, "group1");
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// 连接关闭时的事件
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //从group1中移除
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "group1");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task Send(string message)
        {
            //可以在连接建立的时候，将connectionId保存起来
            //排除掉特定的连接，向其余的所有连接发送消息
            await Clients.AllExcept("").SendAsync(message);
            //发送给特定的连接
            await Clients.Client("").SendAsync(message);
            //向指定的连接发送消息
            var clients = new List<string>() { "", "" };
            await Clients.Clients(clients).SendAsync(message);
            //排除特定的组，向其他组发送消息
            //await Clients.GroupExcept("").SendAsync(message);
            //发送给指定组以外的其他组
            await Clients.OthersInGroup("group1").SendAsync(message);
            //给指定的用户发送消息，用户的多个连接都能收到
            await Clients.User("user1").SendAsync(message);
            //除了当前连接的所有连接都能收到
            await Clients.Others.SendAsync(message);
        }
    }
}
