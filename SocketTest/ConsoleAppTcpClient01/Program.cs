using System;
using System.Net.Sockets;
using System.Text;

namespace ConsoleAppTcpClient01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 접속 할 서버의 IP, PORT 로 바로 연결
            TcpClient tc = new TcpClient("127.0.0.1", 7000);

            // 송신 문장
            string msg = "안녕하세요. TCPClient & TCPListener 사용 테스트입니다.";
            byte[] buff = Encoding.UTF8.GetBytes(msg);
            NetworkStream stream = tc.GetStream();

            stream.Write(buff, 0, buff.Length);

            byte[] receiverBuff = new byte[2048];
            int nbytes = stream.Read(receiverBuff, 0, receiverBuff.Length); 
            string output = Encoding.UTF8.GetString(receiverBuff, 0, nbytes);

            // 닫기
            stream.Close(); 
            tc.Close(); 

            Console.WriteLine($"{nbytes} bytes : {output}");



        }
    }
}
