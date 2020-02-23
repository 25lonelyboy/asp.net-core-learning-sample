using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatSample.Hubs
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        /// <summary>
        /// 用于获取当前连接的用户信息
        /// 可通过认证机制，最后返回一个唯一的用户Id
        /// 用户Id一致的连接，都会被认识是同一个用户的连接
        /// </summary>
        /// <param name="connection">当前连接</param>
        /// <returns></returns>
        public string GetUserId(HubConnectionContext connection)
        {
            //获取当前连接的用户标识
            //不同连接的用户标识可能一样，属于同一个用户
            return connection.GetHttpContext().Request.Query["userid"];
        }
    }
}
