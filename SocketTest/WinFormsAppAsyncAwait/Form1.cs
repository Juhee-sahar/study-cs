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
            // ���� ����
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // IP �� ��Ʈ ����
            IPAddress ipaddr = IPAddress.Any;
            IPEndPoint ipep = new IPEndPoint(ipaddr, 23000);

            // ���� ���ε�
            listenerSocket.Bind(ipep);

            // ���� ��û ��� ���·� ��ȯ
            listenerSocket.Listen(5);
            Console.WriteLine("Ŭ���̾�Ʈ ������ ��� ���Դϴ�...");

            // Ŭ���̾�Ʈ ���� ����
            Socket client = await listenerSocket.AcceptAsync();
            Console.WriteLine($"Ŭ���̾�Ʈ�� ����Ǿ����ϴ� : {client.RemoteEndPoint}");





        }

        private async void BtnListenAsync_Click(object sender, System.EventArgs e)
        {
            await AcceptIncomingSocket();   
        }
    }
}
