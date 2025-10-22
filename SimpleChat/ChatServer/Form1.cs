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

            // 이벤트 연결
            mServer.ClientConnected += OnClientConnected;
            mServer.ClientDisconnected += OnClientDisconnected;
        }


        // 연결 대기 버튼 클릭
        private async void BtnAcceptIncoming_Click(object sender, System.EventArgs e)
        {

            await mServer.StartServerListeningAsync();
        }

        // 프로그램 종료 버튼 클릭 _ 서버 연결만 끊김.
        private void BtnDisconnectServer_Click(object sender, EventArgs e)
        {
            mServer.StopServer();
            AppendChatLog("서버 중지됨.");
        }


        // 클라이언트 연결
        private void OnClientConnected(string ip)
        {
            this.Invoke(new Action(() =>
            {
                AppendClientLog($"[연결 성공] {ip}"); 
            }));
        }


        // 클라이언트 연결 해제
        private void OnClientDisconnected(string ip)
        {
            this.Invoke(new Action(() =>
            {
                AppendClientLog($"[연결 해제] {ip}");
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
