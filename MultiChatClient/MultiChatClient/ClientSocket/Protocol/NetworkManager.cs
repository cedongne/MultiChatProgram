using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace MultiChatClient.ClientSocket.Protocol
{
    public partial class NetworkManager
    {
        private static NetworkManager _instance = new();
        public static NetworkManager Instance { get { return _instance; } }
        public ChatView ChatView { get; set; }


        private IPEndPoint _serverIPEP;

        private TcpClient _clientSocket;
        public ChatClient Client { get; private set; }

        private NetworkManager()
        {
            _serverIPEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            SetSocket();
        }

        private void SetSocket()
        {
            if (TryIssueAvailablePortNumber(out var portNumber))
            {
                _clientSocket = new TcpClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portNumber));
            }
            else
            {
                throw new SocketException();
            }

        }

        private Boolean TryIssueAvailablePortNumber(out Int32 portNumber)
        {
            var ipgp = IPGlobalProperties.GetIPGlobalProperties();

            for (portNumber = 1; portNumber <= 65576; portNumber++)
            {
                var activeTcpConnections = ipgp.GetActiveTcpConnections();
                foreach(var activeTcpConnection in activeTcpConnections)
                {
                    if (activeTcpConnection.LocalEndPoint.Port.Equals(portNumber))
                    {
                        continue;
                    }
                }

                var activeTcpListeners = ipgp.GetActiveTcpListeners();
                foreach (var activeTcpListener in activeTcpListeners)
                {
                    if (activeTcpListener.Port.Equals(portNumber))
                    {
                        continue;
                    }
                }

                return true;
            }

            portNumber = -1;
            return false;
        }

        public Boolean TryConnect()
        {
            try
            {
                _clientSocket.Connect(_serverIPEP);
            }
            catch (SocketException ex) {
                if (ex.SocketErrorCode.Equals(SocketError.ConnectionRefused))
                {
                    var connectFailMsgBoxOepration = MessageBox.Show(
                    "서버 연결에 실패했습니다. 다시 연결을 시도하시겠습니까?",
                    "서버 연결 실패",
                    MessageBoxButtons.YesNo);

                    if (connectFailMsgBoxOepration.Equals(DialogResult.Yes))
                    {
                        return TryConnect();
                    }
                    else if(connectFailMsgBoxOepration.Equals(DialogResult.No))
                    {
                        Application.Exit();
                        return false;
                    }
                }
            }

            return true;
        }

        public void Disconnect()
        {
            _clientSocket.Close();
        }

        public void Start()
        {
            if (_clientSocket.Connected)
            {
                Client = new ChatClient(_clientSocket.Client);

                var receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start();
            }
            else
            {
                Disconnect();
                TryConnect();
            }
        }
    }
}
