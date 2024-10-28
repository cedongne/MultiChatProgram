using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace MultiChatServer
{
    internal partial class MultiClientServer
    {
        private static MultiClientServer _instance = new MultiClientServer();
        public static MultiClientServer Instance => _instance;

        // 통신할 IP 주소, 포트 번호를 설정한다.
        // 127.0.0.1은 localhost의 IP 주소로, 현재 사용 중인 기기인 자기 자신을 가리킨다. 로컬에서 프로그램을 개발하고 테스트하는 용도로 사용된다.
        // 포트 번호는 용도가 겹치지 않도록 사용 중이지 않은 포트를 개방해야 하는데, 아래를 참고하면 좋다.
        // https://ko.wikipedia.org/wiki/TCP/UDP%EC%9D%98_%ED%8F%AC%ED%8A%B8_%EB%AA%A9%EB%A1%9D
        public TcpListener Server { get; private set; } = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
            //new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public const Int32 BUFSIZE = 10;


        public static void Main()
        {
            // 서버 소켓에 다른 소켓의 접속 요청을 허용하기 시작
            Console.WriteLine("Start server... Listening port 9999...");

            Instance.Start();

            // 도달할 수 없는 위치긴 하지만, Dipose 호출은 설정해놓기.
            //Instance.Server.Stop();
        }
    }
}
