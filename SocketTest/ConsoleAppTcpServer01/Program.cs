using System.Net;
using System.Net.Sockets;

namespace ConsoleAppTcpServer01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 서버의 Listen 동작 바로 실행 가능
            IPEndPoint ipt = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);
            TcpListener listener = new TcpListener(ipt);    

            // 클라이언트의 접속 요청을 대기
            listener.Start();

            byte[] receiverBuff = new byte[2048];

            while (true)
            {
                // 대기중인 서버 소켓이 Accept() 를 실행하고, 서버는 클라이언트와 연결이 성공된 소켓을 하나 더 만듦
                TcpClient Connected_TCPClient = listener.AcceptTcpClient(); 

                // TcpClient 객체에서 TCP 네트워크 스트림을 가져와서 사용하도록 함
                NetworkStream stream = Connected_TCPClient.GetStream();

                // 데이터 수신
                int nbytes;
                while ((nbytes = stream.Read(receiverBuff, 0, receiverBuff.Length)) > 0)
                {
                    // 데이터 송신, 에코
                    stream.Write(receiverBuff, 0, nbytes);  
                }

                // 소켓 닫기
                stream.Close(); 
                Connected_TCPClient.Close();
            }
            
        }
    }
}
