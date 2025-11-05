using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPSocket
{
    public class TCPSocketServer
    {
        IPAddress? mIP;
        int mPort;
        TcpListener? mTCPListener;

        List<TcpClient> mClients;

        public bool KeepRunning { get; set; } = false;

        public TCPSocketServer()
        {
            mClients = new List<TcpClient>();
        }



        // 이벤트 핸들러
        // - public: 외부에서도 이 이벤트에 구독 가능(+=, -= 가능)
        // - event: 외부에서 직접 실행(Invoke)은 불가능 (캡슐화)
        public event EventHandler<CustomEventArgs>? ClientConnectedEvent;

        // 이벤트 발생 메서드
        public void OnRaiseClientConnectedEvent(CustomEventArgs e)
        {
            // ?.Invoke() : 널 검사와 호출을 한 줄로 처리
            // (ClientConnectedEvent가 null이면 자동으로 아무 일도 하지 않음)
            ClientConnectedEvent?.Invoke(this, e);
        }


        // 이벤트 수신 이벤트
        public event EventHandler<TextReceivedEventArgs>? TextReceivedEvent;

        // 텍스트 수신 이벤트 발생 메서드
        public void OnRaiseTextReceivedEvent(TextReceivedEventArgs e)
        {
            // 이벤트 발생
            TextReceivedEvent?.Invoke(this, e); 
        }



        public async Task StartServerListeningAsync(IPAddress? ipaddr = null, int port = 23000)
        {
            if (ipaddr == null)
                ipaddr = IPAddress.Loopback; // 기본값: 로컬호스트

            if (port <= 0 || mPort > 65535)
                port = 23000; // 기본 포트

            mIP = ipaddr;
            mPort = port;

            //(1)
            mTCPListener = new TcpListener(mIP, mPort);

            try
            {
                //(2)
                mTCPListener.Start();
                Console.WriteLine($"서버가 시작되었습니다. 주소: {mIP.ToString()}:{mPort}");

                KeepRunning = true;

                while (KeepRunning)
                {
                    //(3)
                    Console.WriteLine("클라이언트 연결을 대기 중입니다...");
                    TcpClient client = await mTCPListener.AcceptTcpClientAsync();
                    Console.WriteLine("클라이언트가 연결되었습니다.");

                    //연결될 때마다 서버-클라 동작해야 할 로직
                    mClients.Add(client);
                    Console.WriteLine(
                        string.Format("클라이언트 연결 완료 (총 연결 수: {0}) - 원격 주소: {1}",
                        mClients.Count, client.Client.RemoteEndPoint)
                        );

                    ManageClient(client);

                    // [이벤트 발생 시 전달할 데이터 생성]
                    string clientInfo = client.Client.RemoteEndPoint?.ToString() ?? "Unknown";
                    CustomEventArgs eventArgs = new CustomEventArgs(clientInfo);

                    // [이벤트 발생 메서드 호출]
                    OnRaiseClientConnectedEvent(eventArgs);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"서버 실행 중 오류 발생: {ex.Message}");
            }
        }

        private async void ManageClient(TcpClient client)
        {
            //(4)
            NetworkStream? stream = null;
            StreamReader? reader = null;

            try
            {
                stream = client.GetStream();
                reader = new StreamReader(stream);

                char[] buffer = new char[1024];

                while (KeepRunning)
                {
                    //(5)
                    int bytesRead = await reader.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        RemoveClient(client);   
                        Console.WriteLine("클라이언트 연결이 종료되었습니다.");
                        break;
                    }
                    string receivedData = new string(buffer, 0, bytesRead);
                    Console.WriteLine($"수신한 데이터: {receivedData}");

                    //_ = SendToAll(receivedData);

                    // 이벤트 발생 시 전달할 데이터 생성
                    string clientInfo = client.Client.RemoteEndPoint?.ToString() ?? "Unknown";
                    TextReceivedEventArgs enentArgs = new TextReceivedEventArgs(clientInfo, receivedData);  

                    // 이벤트 발생 메서드 호출
                    OnRaiseTextReceivedEvent(enentArgs);    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"클라이언트 처리 중 오류 발생: {ex.Message}");
                RemoveClient(client);
            }
        }

        private void RemoveClient(TcpClient client)
        {
            if (mClients.Contains(client))
            {
                mClients.Remove(client);
                Console.WriteLine(
                    String.Format("클라이언트 연결 종료, 총 연결 수: {0}", mClients.Count));
            }
        }

        public async Task SendToAll(string Msg)
        {
            if (string.IsNullOrEmpty(Msg))
            { 
                return; 
            }

            try
            {
                byte[] buffMessage = Encoding.ASCII.GetBytes(Msg);

                foreach (TcpClient clnt in mClients)
                {
                    //(6)
                    await clnt.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                }
            }
            catch (Exception excp)
            {
                Console.WriteLine($"전송 중 오류 발생: {excp.Message}");
            }
        }

        public void StopServer()
        {
            try
            {
                if (mTCPListener != null)
                {
                    //(7)
                    mTCPListener.Stop();
                }

                foreach (TcpClient clnt in mClients)
                {
                    clnt.Close();
                }
                mClients.Clear();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
