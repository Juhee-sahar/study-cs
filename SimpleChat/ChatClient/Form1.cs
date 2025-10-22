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

            // �̺�Ʈ ����: ���� �޽���, ���� ����
            mClient.MessageReceived += MClient_MessageReceived;
            mClient.Disconnected += MClient_Disconnected;

            // �ʱ� ���� UI ����
            UpdateUiConnectedState(false);
        }

        // �̺�Ʈ �ݹ�
        private void MClient_MessageReceived(string message)
        {
            // MessageReceived�� ��׶��� �����忡�� ȣ��� �� �����Ƿ� UI ������Ʈ�� Invoke��
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
            // ���� ���� �� UI ���� ������Ʈ
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
            // label�� ���� ��� (label�� �⺻������ �ٹٲ��� ������)
            // ���� �ʹ� ������� ������ �ڸ��ų� ��ũ�� ������ ��Ʈ�ѷ� ��ü ����
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


        // ���� ����
        private async void BtnServerConnect_Click(object sender, EventArgs e)
        {
            // �Է°� �б�
            string ip = (textBoxIP.Text ?? string.Empty).Trim();
            string port = (textBoxPortNum.Text ?? string.Empty).Trim();

            // IP / Port ����
            if (!mClient.SetServerIPAddress(ip) || !mClient.SetServerPort(port))
            {
                MessageBox.Show("�߸��� IP �Ǵ� Port�Դϴ�.", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // �õ�: ���� ���� �� �ܼ� �˾�(��û����)
            try
            {
                await mClient.ConnectToServerAsync();
                UpdateUiConnectedState(true);
                MessageBox.Show("������ ����Ǿ����ϴ�.", "���� ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                // ���� �����ϸ� "���� ����" �˾��� ��� (���α׷� ���� X)
                MessageBox.Show("���� ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ���� ���� ����
        private void BtnServerDisconnect_Click(object sender, EventArgs e)
        {
            // �ܼ��� ���Ḹ ����
            mClient.Disconnect();
            UpdateUiConnectedState(false);
        }


        // �޼��� ����
        private async void BtnSendChatMassage_Click(object sender, EventArgs e)
        {
            string userInput = (textBox1.Text ?? string.Empty);
            if (string.IsNullOrEmpty(userInput))
            {
                return;
            }

            if (mClient.Client == null || !mClient.Client.Connected)
            {
                MessageBox.Show("������ ����Ǿ� ���� �ʽ��ϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await mClient.SendData(userInput);
                // ���� �޽����� �ʿ��ϸ� ä�� �α׿� �߰� ���� (���迡 ���� �ٸ�)
                AppendChatLog($"(��) {userInput}");
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�޽��� ���� ����: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
