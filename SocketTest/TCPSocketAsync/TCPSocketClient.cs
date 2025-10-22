using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPSocketAsync
{
    public class TCPSocketClient
    {
        // 서버 접속에 필요한 데이터 준비
        private IPAddress? _serverIPAddress = IPAddress.Parse("127.0.0.1");
        private int _serverPort;
        private TcpClient? _client;

        // getter 구현 (외부에서 변경 불가, 내부 메서드를 통해서만 변경)
        public IPAddress? ServerIPAddress => _serverIPAddress;
        public int ServerPort => _serverPort;
        public TcpClient? Client => _client;

        // setter 구현 (IP 검증 및 설정)
        public bool SetServerIPAddress(string addressStr)
        {
            if (!IPAddress.TryParse(addressStr, out var parsed))
            {
                Console.WriteLine(" 잘못된 서버 IP입니다.");
                return false;   
            }

            _serverIPAddress = parsed;
            return true;
        }

        // setter 구현 (포트 번호 검증 및 설정 메서드)
        public bool SetServerPort(string portStr)
        {
            int portNum;
            if (!int.TryParse(portStr, out portNum) || portNum <= 0 || portNum > 65535)
            {
                Console.WriteLine(" 잘못된 Port입니다. (유효 범위 : 1~65535)");
                return false;   
            }

            _serverPort = portNum;  
            return true;    
        }

        // 서버 접속 메서드
        public async Task ConnectToServerAsync()
        {
            // 서버가 연결되어 있지 않으면
            if (_client == null) _client = new TcpClient();

            try
            {
                await _client.ConnectAsync(_serverIPAddress, _serverPort);
                Console.WriteLine(string.Format("서버 접속 IP/Port : {0}/{1}", _serverIPAddress, _serverPort));


                // 서버로부터 데이터 수신 대기 시작 (실제 비즈니스 로직)
                ReadDataAsync(_client);


            }
            catch (Exception e)
            {
                Console.WriteLine($"서버 접속 에러 : {e.ToString()}");
                throw;
            }
        }

        // 서버로부터 데이터 수신 대기 메서드
        private async void ReadDataAsync(TcpClient client)
        {
            try
            {
                // 서버로부터 수신된 데이터를 읽기 위한 준비 (StreamReader, Buffer 등)
                StreamReader clntStreamReader = new StreamReader(client.GetStream());
                char[] buffer = new char[1024];
                int readByteCount = 0;

                // 서버로부터 수신된 데이터 읽기
                while (true)
                {
                    readByteCount = await clntStreamReader.ReadAsync(buffer, 0, buffer.Length);    

                    if (readByteCount == 0)
                    {
                        Console.WriteLine("서버 연결 끊김");
                        client.Close();
                        break;
                    }

                    Console.WriteLine(string.Format("전달받은 바이트 : {0} , Message : {1}", readByteCount, new string(buffer)));
                    Array.Clear(buffer, 0, readByteCount);  
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());    
                throw;
            }
        }
    }
}
