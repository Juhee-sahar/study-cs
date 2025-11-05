using System.Windows.Forms;
using TCPSocket;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        TCPSocketServer mServer;

        public Form1()
        {
            InitializeComponent();
            mServer = new TCPSocketServer();

            // 폼이 로드될 때 이벤트 핸들러를 등록합니다.
            mServer.ClientConnectedEvent += HandleClientConnect;
        }

        private async void BtnAcceptIncomingAsync_Click(object sender, System.EventArgs e)
        {
            await mServer.StartServerListeningAsync();
        }

        // 기다리지 않아도 된다면 async를 생략해도 됩니다.
        private void BtnSendAll_Click(object sender, System.EventArgs e)
        {
            // _는 Discard(버림값) 리턴값이 필요 없는 모든 상황에서 값을 사용하지 않을 의도 명시
            _ = mServer.SendToAll(textBox1.Text.Trim());
        }

        private void BtnStopServer_Click(object sender, System.EventArgs e)
        {
            mServer.StopServer();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mServer.StopServer();
        }

        // 폼이 로드될 때 이벤트 핸들러를 등록합니다.
        void HandleClientConnect(object? sender, CustomEventArgs e)
        {
            //MessageBox.Show($"클라이언트가 접속했습니다. {e.NewClientInfo}");
            textBox2.AppendText($"클라이언트가 접속했습니다. " +
                $"{e.NewClientInfo}{System.Environment.NewLine}" );
        }
    }
}
