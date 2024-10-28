using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Client_TCPIP_SocketProgramming
{
    internal class Client
    {
        private static String _nickname = null;
        public static String Nickname { 
            get { return _nickname; } 
            set
            {
                if (_nickname == null)
                {
                    _nickname = value;
                }
            } }

        public static String DecideNickname()
        {
            var nickname = String.Empty;
            while (String.IsNullOrEmpty(nickname))
            {
                Console.Write("닉네임을 입력하세요: ");
                nickname = Console.ReadLine();
            }

            return nickname;
        }

        public static void Main()
        {
            var ipEp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ProtocolManager protocolManager = new ProtocolManager();

            try
            {
                client.Connect(ipEp);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Server is closed. " + e.Message);
                return;
            }

            Nickname = DecideNickname();

            Console.WriteLine($"{Nickname} (으)로 접속합니다...");

            while (true)
            {
                if (ConsoleCommand.HandleConsoleCommand(Console.ReadKey()).Equals(ConsoleCommandResultType.CloseProgram))
                    break; ;

                await protocolManager.SendAsync(client);
            }

            client.Close();

            Console.Write("Press any key to close program...");
            Console.ReadLine();

            return Task.CompletedTask;
        }
    }
}
