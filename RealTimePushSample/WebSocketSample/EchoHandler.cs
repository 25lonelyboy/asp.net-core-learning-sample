using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketSample
{
    public static class EchoHandler
    {
        public static async Task Echo(WebSocket webSocket)
        {
            //webSocket数据传输基于流，这里使用buffer作为数据的缓冲
            var buffer = new byte[1024 * 4];
            //使用字节片段进行数据的接收和传输
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            //循环接收,保持长连接
            while(!result.CloseStatus.HasValue)
            {
                string message = Encoding.Default.GetString(buffer);
                message += "---" + DateTime.Now;
                byte[] bufferResponse = Encoding.Default.GetBytes(message);
                await webSocket.SendAsync(new ArraySegment<byte>(bufferResponse, 0, bufferResponse.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            //服务端和客户端都得关闭,当监测到客户端已经断开后，服务端也将连接关闭
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
