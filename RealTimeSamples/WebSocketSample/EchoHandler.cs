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
            var buffer = new byte[1024 * 4];

            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                string message = Encoding.Default.GetString(buffer);

                message += "--" + DateTime.Now;

                byte[] bufferReponse = Encoding.Default.GetBytes(message);

                await webSocket.SendAsync(new ArraySegment<byte>(bufferReponse, 0, bufferReponse.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
