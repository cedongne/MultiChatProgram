using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Reflection.PortableExecutable;

namespace Server_TCPIP_SocketProgramming
{
    internal partial class MultiClientServer
    {
        public void Start()
        {
            // 소켓의 접속을 기다린다.
            // 실제 소켓 접속 요청이 있을 때 다음 라인을 실행한다.
            Server.Start();

            var connectThread = new Thread(WaitClientConnect);
            connectThread.Start();
        }

        private void WaitClientConnect()
        {
            while (true)
            {
                try
                {
                    var acceptedClient = Server?.AcceptSocket();

                    if (acceptedClient == null)
                    {
                        continue;
                    }

                    var ip = acceptedClient.RemoteEndPoint as IPEndPoint;

                    if (ip != null)
                    {
                        Thread connectedClient = new(new ThreadStart(new ChatClient(acceptedClient).StartCommunication));  // 접속된 Client 의 객체를 생성 Thread 를 사용하여 동작 수행
                        connectedClient.Start();

                        Console.WriteLine($"Client {ip.Address} is connected");
                        //StartCommunication(acceptedClient);
                    }
                }
                catch { }
                {

                }
            }
        } 

        public class ChatClient
        {
            Socket ClientSocket { get; }
            NetworkStream NetworkStream { get; }
            StreamReader Reader { get; }
            StreamWriter Writer { get; }

            public ChatClient(Socket clientSocket)
            {
                ClientSocket = clientSocket;
                NetworkStream = new NetworkStream(clientSocket);
                Reader = new StreamReader(NetworkStream, Encoding.GetEncoding("utf-8"));
                Writer = new StreamWriter(NetworkStream, Encoding.GetEncoding("utf-8")) { AutoFlush = true };
            }

            public void StartCommunication()
            {
                String message = "Hello, Client! Welcome to cedongne's server! Please send me message!";
                Writer.WriteLine(message);

                String? temp;

                while (true)
                {
                    if (ClientSocket.Connected == false)
                    {
                        break;
                    }
                    try
                    {
                        temp = Reader?.ReadLine();

                        Console.WriteLine(temp);

                        Writer.WriteLine(temp);
                    }
                    catch(Exception ex)
                    {
                        ClientSocket.Close();
                    }
                }
                //소켓은 IDisposable 인터페이스를 구현하기 때문에 반드시 Dispose 해줘야 한다.
                // Socket.Close() 메서드는 내부에서 Dispose()를 호출해준다.
                ClientSocket.Close();
            }
        }
    }

    public class ClientHandle
    {
        private Socket socket;
        private NetworkStream? networkstream = null;
        private StreamReader? streamReader = null;
        private StreamWriter? streamWriter = null;
        //--------------------------------------------------------------------------------------------------------
        public ClientHandle(Socket client)
        {
            socket = client;
            networkstream = new NetworkStream(client);

            streamReader = new StreamReader(networkstream!, Encoding.GetEncoding("utf-8"));
            streamWriter = new StreamWriter(networkstream!, Encoding.GetEncoding("utf-8")) { AutoFlush = true };
        }
        //--------------------------------------------------------------------------------------------------------
        public void Run()
        {
            string? receiveData;        // 데이타 수신이 null 이 될수 있으므로 null 참조 가능으로 선언한다. 

            while (true)
            {
                receiveData = streamReader!.ReadLine();     // NetworkStream 으로 들어오는 데이타의 끝은 CR, LF 가 필요하다. 
                                                            // CR LF 가 없으면 버퍼가 overflow 될때 까지 함수 내부에서 빠져 나오지 못한다. 
                if (receiveData is null) break;             // Client 연결이 끊어지면 null 이 리턴된다. 

                Console.WriteLine($"{receiveData}");

                WriteClientData(receiveData);  // Echo 기능 입니다. 다은 특별한 동작이 필요하면 이코드를 삭제하고 구현하시면 됩니다. 
            }

            DisConnect();       // Client 연결과 관련된 부분을 모두 닫아 버린다. 
        }
        //--------------------------------------------------------------------------------------------------------
        public void DisConnect()
        {
            streamReader?.Close();
            streamWriter?.Close();
            networkstream?.Close();

            socket.Close();
        }
        //--------------------------------------------------------------------------------------------------------
        public void WriteClientData(string Message)
        {
            streamWriter?.WriteLine(Message);
        }
        //--------------------------------------------------------------------------------------------------------
    }
}
