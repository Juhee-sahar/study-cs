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
    }
}
