using ChatSocket;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        private readonly TCPSocketClient mClient;

        public Form1()
        {
            InitializeComponent();

            mClient = new TCPSocketClient();

            // 이벤트 구독: 수신 메시지, 연결 끊김
            mClient.MessageReceived += MClient_MessageReceived;
            mClient.Disconnected += MClient_Disconnected;

            // 초기 상태 UI 설정
            UpdateUiConnectedState(false);
        }

        // 이벤트 콜백
        private void MClient_MessageReceived(string message)
        {
            // MessageReceived는 백그라운드 스레드에서 호출될 수 있으므로 UI 업데이트는 Invoke로
            if (labelChatLog.InvokeRequired)
            {
                labelChatLog.BeginInvoke(new Action(() => AppendChatLog(message)));
            }
            else
            {
                AppendChatLog(message);
            }
        }

        private void MClient_Disconnected()
        {
            // 연결 끊김 시 UI 상태 업데이트
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => UpdateUiConnectedState(false)));
            }
            else
            {
                UpdateUiConnectedState(false);
            }
        }

        private void AppendChatLog(string message)
        {
            // label에 누적 출력 (label은 기본적으로 줄바꿈을 지원함)
            // 만약 너무 길어지면 적절히 자르거나 스크롤 가능한 컨트롤로 교체 권장
            var previous = labelChatLog.Text;
            var builder = new StringBuilder(previous ?? string.Empty);

            if (builder.Length > 0)
            {
                builder.Append(Environment.NewLine);
            }

            builder.Append(message.TrimEnd('\r', '\n'));
            labelChatLog.Text = builder.ToString();
        }

        private void UpdateUiConnectedState(bool connected)
        {
            BtnServerConnect.Enabled = !connected;
            BtnServerDisconnect.Enabled = connected;
            BtnSendChatMassage.Enabled = connected;
            textBoxIP.Enabled = !connected;
            textBoxPortNum.Enabled = !connected;
        }


        // 서버 연결
        private async void BtnServerConnect_Click(object sender, EventArgs e)
        {
            // 입력값 읽기
            string ip = (textBoxIP.Text ?? string.Empty).Trim();
            string port = (textBoxPortNum.Text ?? string.Empty).Trim();

            // IP / Port 검증
            if (!mClient.SetServerIPAddress(ip) || !mClient.SetServerPort(port))
            {
                MessageBox.Show("잘못된 IP 또는 Port입니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 시도: 연결 실패 시 단순 팝업(요청사항)
            try
            {
                await mClient.ConnectToServerAsync();
                UpdateUiConnectedState(true);
                MessageBox.Show("서버에 연결되었습니다.", "연결 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                // 연결 실패하면 "연결 실패" 팝업만 띄움 (프로그램 종료 X)
                MessageBox.Show("연결 실패", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 서버 연결 해제
        private void BtnServerDisconnect_Click(object sender, EventArgs e)
        {
            // 단순히 연결만 해제
            mClient.Disconnect();
            UpdateUiConnectedState(false);
        }


        // 메세지 전송
        private async void BtnSendChatMassage_Click(object sender, EventArgs e)
        {
            string userInput = (textBox1.Text ?? string.Empty);
            if (string.IsNullOrEmpty(userInput))
            {
                return;
            }

            if (mClient.Client == null || !mClient.Client.Connected)
            {
                MessageBox.Show("서버에 연결되어 있지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await mClient.SendData(userInput);
                // 보낸 메시지는 필요하면 채팅 로그에 추가 가능 (설계에 따라 다름)
                AppendChatLog($"(나) {userInput}");
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"메시지 전송 실패: {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
