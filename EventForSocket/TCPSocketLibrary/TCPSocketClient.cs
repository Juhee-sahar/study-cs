using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCPSocket
{
    public class TCPSocketClient
    {
        // [A] 클라이언트에서, 서버 접속에 필요한 데이터를 준비합니다.(Private 필드, 맴버 변수)
        private IPAddress? _serverIPAddress = IPAddress.Parse("127.0.0.1");  //서버IP
        private int _serverPort;              //서버Port
        private TcpClient? _client;           //클라Socket

        // [B] getter 구현 (외부에서 변경 불가, 내부 메서드를 통해서만 변경)
        // (동일) // public IPAddress? ServerIPAddress { get { return _serverIPAddress; } }
        public IPAddress? ServerIPAddress => _serverIPAddress;
        public int ServerPort => _serverPort;
        public TcpClient? Client => _client;

        // [C] setter 구현 (IP 검증 및 설정)
        public bool SetServerIPAddress(string addressStr)
        {
            if (!IPAddress.TryParse(addressStr, out var parsed))
            {
                Console.WriteLine(" - 잘못된 서버 IP입니다.");
                return false;
            }

            _serverIPAddress = parsed;
            return true;
        }

        // [D] setter 구현 (포트 번호 검증 및 설정 메서드)
        public bool SetServerPort(string portStr)
        {
            int portNum;
            if (!int.TryParse(portStr, out portNum) || portNum <= 0 || portNum > 65535)
            {
                Console.WriteLine(" - 잘못된 Port입니다. (유효 범위: 1~65535)");
                return false;
            }
            _serverPort = portNum;
            return true;
        }

        // [E] 서버 접속 메서드
        public async Task ConnectToServerAsync()
        {
            // [E.1] 서버가 연결되어 있지 않으면, 
            if (_client == null) _client = new TcpClient();

            try
            {   // [E.2] 검증한 IP, Port 를 기반으로 서버 연결 시도
                await _client.ConnectAsync(_serverIPAddress, _serverPort);
                Console.WriteLine(string.Format("서버 접속 IP/Port: {0}/{1}", _serverIPAddress, _serverPort));

                // [F] & [E.3] 서버로부터 데이터 수신 대기 시작 (실제 비지니스 로직)
                ReadDataAsync(_client);
            }
            catch (Exception ex)
            {   // [E.3] 예외 발생시 상태 출력
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        // [F] 서버로부터 데이터 수신 대기 메서드
        private async void ReadDataAsync(TcpClient client)
        {
            try
            {
                // [F.1] 서버로부터 수신된 데이터를 읽기 위한 준비 (StreamReader, Buffer 등)
                StreamReader clntStreamReader = new StreamReader(client.GetStream());
                char[] buffer = new char[1024];
                int readByteCount = 0;

                // [F.2] 무한 루프를 돌면서, 서버로부터 수신된 데이터를 계속 읽음
                while (true)
                {
                    readByteCount = await clntStreamReader.ReadAsync(buffer, 0, buffer.Length);
                    if (readByteCount == 0)
                    {
                        Console.WriteLine("서버 연결 끊김");
                        client.Close();
                        break;
                    }

                    // [F.3] 수신된 데이터 출력 (실제 비지니스 로직 처리 부분)
                    Console.WriteLine(string.Format("전달받은 바이트:{0} - Message: {1}", readByteCount, new string(buffer)));
                    Array.Clear(buffer, 0, readByteCount);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        // [G] 서버로 데이터 전송 메서드
        public async Task SendData(string userInput)
        {
            if(string.IsNullOrEmpty(userInput) || _client == null || !_client.Connected)
            {
                Console.WriteLine(" - 서버에 연결되어 있지 않거나, 전송할 데이터가 없습니다.");
                return;
            }
            else
            {
                try
                {
                    // [G.1] 서버로 데이터를 전송하기 위한 준비 (StreamWriter 등)
                    StreamWriter clntStreamWriter = new StreamWriter(_client.GetStream());
                    clntStreamWriter.AutoFlush = true;
                    // [G.2] 사용자 입력 데이터를 서버로 전송
                    await clntStreamWriter.WriteAsync(userInput);
                    Console.WriteLine($"서버로 전송한 메시지: {userInput}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }
    }
}
