using System.Threading.Tasks;
using TCPSocketAsync; // 클래스 라이브러리 명

namespace WinFormsAppTCPSocketServer
{
    public partial class Form1 : Form
    {
        // 클래스 라이브러리 클래스 명
        TCPSocketServer mServer;

        public Form1()
        {
            InitializeComponent();
            mServer = new TCPSocketServer();

        }

        private async void BtnAcceptIncomingAsync_Click(object sender, System.EventArgs e)
        {
            await mServer.StartServerListeningAsync();
        }

        // 기다리지 않아도 된다면 async 생략 가능
        private void BtnSendAll_Click(object sender, System.EventArgs e)
        {
            // _ 는 Discard(버림값) 리턴값이 필요 없는 모든 상황에서 값을 사용하지 않을 의도 명시
            _ = mServer.SendToAll(textBox1.Text.Trim());
        }
    }
}