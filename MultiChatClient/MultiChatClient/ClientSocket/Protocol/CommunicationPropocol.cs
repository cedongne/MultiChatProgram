using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using MultiChatAppProtocol;

namespace MultiChatClient.ClientSocket.Protocol
{
    public partial class NetworkManager
    {
        public class ChatClient
        {
            public ChatClientInfo ClientInfo { get; }
            public String Id { get; } = "cedongne";
            public String NickName { get; } = "세동네";

            public Socket ClientSocket { get; }
            public NetworkStream NetworkStream { get; }
            public StreamReader Reader { get; }
            public StreamWriter Writer { get; }

            public ChatClient(Socket clientSocket)
            {
                ClientInfo = new ChatClientInfo
                {
                    Id = "cedongne",
                    NickName = "세동네"
                };
                ClientSocket = clientSocket;
                NetworkStream = new NetworkStream(clientSocket);
                Reader = new StreamReader(NetworkStream, Encoding.GetEncoding("utf-8"));
                Writer = new StreamWriter(NetworkStream, Encoding.GetEncoding("utf-8")) { AutoFlush = true };
            }
        }

        public void SendMessage(String message)
        {
            var serializedDataForm = JsonSerializer.Serialize(new MessageDataForm{ 
                ChatClientInfo = Client.ClientInfo,
                Message = message,
                MessageCreatedTime = DateTime.UtcNow,
            });

            Client.Writer.WriteLine(message);
        }

        public void ReceiveMessage()
        {
            String serializedDataForm;

            while (Client.ClientSocket.Connected)
            {
                try
                {
                    var deserializedMessage = Client.Reader.ReadLine() ?? String.Empty;
                    //serializedDataForm = Client.Reader.ReadLine() ?? String.Empty;
                    //var deserializedMessage = JsonSerializer.Deserialize<MessageDataForm>(serializedDataForm);

                    if(deserializedMessage == null)
                    {
                        continue;
                    }

                    if (ChatView.GetChatBox.InvokeRequired)
                    {
                        ChatView.GetChatBox.Invoke((MethodInvoker)(() =>
                        {
                            ChatView.GetChatBox.AppendText(deserializedMessage);
                            ChatView.GetChatBox.AppendText(Environment.NewLine);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    if (_clientSocket.Connected == false)
                    {
                    }

                    break;
                };
            }
        }
    }
}
