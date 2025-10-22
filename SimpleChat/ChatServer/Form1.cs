using ChatSocket;

namespace ChatServer
{
    public partial class Form1 : Form
    {

        TCPSocketServer mServer;

        public Form1()
        {
            InitializeComponent();

            mServer = new TCPSocketServer();

            // �̺�Ʈ ����
            mServer.ClientConnected += OnClientConnected;
            mServer.ClientDisconnected += OnClientDisconnected;
        }


        // ���� ��� ��ư Ŭ��
        private async void BtnAcceptIncoming_Click(object sender, System.EventArgs e)
        {

            await mServer.StartServerListeningAsync();
        }

        // ���α׷� ���� ��ư Ŭ�� _ ���� ���Ḹ ����.
        private void BtnDisconnectServer_Click(object sender, EventArgs e)
        {
            mServer.StopServer();
            AppendChatLog("���� ������.");
        }


        // Ŭ���̾�Ʈ ����
        private void OnClientConnected(string ip)
        {
            this.Invoke(new Action(() =>
            {
                AppendClientLog($"[���� ����] {ip}"); 
            }));
        }


        // Ŭ���̾�Ʈ ���� ����
        private void OnClientDisconnected(string ip)
        {
            this.Invoke(new Action(() =>
            {
                AppendClientLog($"[���� ����] {ip}");
            }));
        }



        private void AppendClientLog(string text)
        {
            labelClintList.Text += text + Environment.NewLine;
        }


        private void AppendChatLog(string text)
        {
            labelChatLog.Text += text + Environment.NewLine;    
        }
    }
}
