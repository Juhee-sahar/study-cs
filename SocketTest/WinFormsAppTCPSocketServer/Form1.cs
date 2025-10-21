using System.Threading.Tasks;
using TCPSocketAsync; // Ŭ���� ���̺귯�� ��

namespace WinFormsAppTCPSocketServer
{
    public partial class Form1 : Form
    {
        // Ŭ���� ���̺귯�� Ŭ���� ��
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

        // ��ٸ��� �ʾƵ� �ȴٸ� async ���� ����
        private void BtnSendAll_Click(object sender, System.EventArgs e)
        {
            // _ �� Discard(������) ���ϰ��� �ʿ� ���� ��� ��Ȳ���� ���� ������� ���� �ǵ� ���
            _ = mServer.SendToAll(textBox1.Text.Trim());
        }
    }
}