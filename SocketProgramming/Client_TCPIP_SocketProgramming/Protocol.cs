using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client_TCPIP_SocketProgramming
{
    internal static class SocketExtension
    {
        public static String ReceiveMessageAsString(this Socket serverSocket)
        {
            var message = Array.Empty<Byte>();
            serverSocket.Receive(message);

            return Encoding.Default.GetString(message);
        }

        public static async Task SendAsyncMessage(this Socket serverSocket, String message)
        {
            await serverSocket.SendAsync(Encoding.Default.GetBytes(message));
        }
    }

    public class ProtocolManager
    {
        public async Task SendAsync(Socket serverSocket)
        {
            await serverSocket.SendAsyncMessage(Console.ReadLine());
        }
    }
}
