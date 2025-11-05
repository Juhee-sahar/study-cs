using System;
using TCPSocket;

namespace TCPClient_ConsoleEx01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // [A] TCPSocketClient 인스턴스 생성
            TCPSocketClient client = new TCPSocketClient();


            // 텍스트 수신 이벤트 핸들러 등록
            client.TextReceivedEvent += Client_TextReceivedEvent;




            // [B] 사용자로부터 서버 IP 주소와 포트 번호 입력 받고, 설정
            Console.WriteLine("*** 소켓 클라이언트 예제 ***");

            Console.Write("서버 IP를 입력하세요: ");
            string strIPAddress = (Console.ReadLine() ?? "").Trim();

            Console.Write("포트 번호(1~65535)를 입력하세요: ");
            string strPortInput = (Console.ReadLine() ?? "").Trim();

            // [C] IP 또는 Port가 잘못된 경우 프로그램 종료
            if (!client.SetServerIPAddress(strIPAddress) || !client.SetServerPort(strPortInput))
            {
                Console.WriteLine($" - 잘못된 IP 또는 포트 (IP: {strIPAddress}, Port: {strPortInput})");
                Console.WriteLine("아무 키나 누르면 종료합니다...");
                Console.ReadKey();
                return;
            }

            // [D] 서버에 비동기 접속 시도
            _ = client.ConnectToServerAsync();

            // [E] 사용자로부터 메시지 입력 받기 (종료하려면 <EXIT> 입력)
            string? userInput = null;
            Console.WriteLine("메시지를 입력하세요. (종료하려면 <EXIT> 입력 후 Enter)");
            do
            {
                userInput = Console.ReadLine() ?? string.Empty;
                if (userInput != null && userInput.Trim() != "<EXIT>" && client.Client != null && client.Client.Connected)
                {
                    // [F] 서버로 메시지 전송
                    _ = client.SendData(userInput);
                }
            } while (userInput != "<EXIT>");

            Console.WriteLine("클라이언트 프로그램을 종료합니다.");
        }


        private static void Client_TextReceivedEvent(object? sender, CustomEventArgs e)
        {
            // 수신된 텍스트 출력
            Console.WriteLine($"[서버로부터 수신된 메시지]: {e.NewClientInfo}");
        }
    }
}
