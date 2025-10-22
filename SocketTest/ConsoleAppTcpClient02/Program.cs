using TCPSocketAsync;

namespace ConsoleAppTcpClient02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TCPSocketClient client = new TCPSocketClient();

            Console.WriteLine("*** 소켓 클라이언트 예제 ***");

            Console.WriteLine("서버 IP 입력 : ");
            string strIPAddress = (Console.ReadLine() ?? string.Empty).Trim();

            Console.WriteLine("포트 번호(1~65535)를 입력하세요 : ");
            string strPortInput = (Console.ReadLine() ?? string.Empty).Trim();  

            // IP 나 Port 가 잘못된 경우
            if (!client.SetServerIPAddress(strIPAddress) || !client.SetServerPort(strPortInput))
            {
                Console.WriteLine($" 잘못된 IP 또는 Port. IP : {strIPAddress}, Port : {strPortInput}");
                Console.WriteLine("아무 키나 누르면 종료합니다.");
                Console.ReadKey();
                return;
            }

            // 서버에 비동기 접속 시도
            _ = client.ConnectToServerAsync();

            // 클라이언트 메세지 입력
            string? userInput = null;
            Console.WriteLine("메시지를 입력하세요. (종료하려면 <EXIT> 입력 후 Enter");
            do
            {
                if(userInput != null && userInput.Trim() != "<EXIT>" && client.Client != null && client.Client.Connected)
                {
                    // 서버로 메세지 전송
                    _ = client.SendData(userInput);
                }


                userInput = Console.ReadLine() ?? string.Empty;
            } while (userInput != "<EXIT>");

            Console.WriteLine("클라이언트 프로그램을 종료합니다.");
        }
    }
}
