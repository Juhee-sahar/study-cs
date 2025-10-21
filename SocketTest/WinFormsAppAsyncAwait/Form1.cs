using System.Net;
using System.Net.Sockets;

namespace WinFormsAppAsyncAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public async Task AcceptIncomingSocket()
        {
            // 소켓 생성
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // IP 및 포트 설정
            IPAddress ipaddr = IPAddress.Any;
            IPEndPoint ipep = new IPEndPoint(ipaddr, 23000);

            // 소켓 바인딩
            listenerSocket.Bind(ipep);

            // 연결 요청 대기 상태로 전환
            listenerSocket.Listen(5);
            Console.WriteLine("클라이언트 연결을 대기 중입니다...");

            // 클라이언트 연결 수락
            Socket client = await listenerSocket.AcceptAsync();
            Console.WriteLine($"클라이언트가 연결되었습니다 : {client.RemoteEndPoint}");





        }

        private async void BtnListenAsync_Click(object sender, System.EventArgs e)
        {
            await AcceptIncomingSocket();   
        }
    }
}
