using System;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;

namespace ConsoleAppClient01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                IPAddress? ipaddr = null;

                Console.WriteLine("*** 소켓 클라이언트 시작 예제에 오신 것을 환영합니다. ***");
                Console.WriteLine("서버의 IP 주소를 입력하고 Enter 키를 누르세요 : ");

                string? strIPAddress = Console.ReadLine();

                Console.WriteLine("유효한 포트 번호(0~65535)를 입력하고 Enter 키를 누르세요 : ");
                string? strPortInput = Console.ReadLine();
                int nPortInput = 0;

                if (strIPAddress == " ") strIPAddress = "127.0.0.1";
                if (strPortInput == " ") strPortInput = "23000";

                if (!IPAddress.TryParse(strIPAddress, out ipaddr))
                {
                    Console.WriteLine("잘못된 서버 IP가 입력되었습니다.");
                    return;
                }

                if (!int.TryParse(strPortInput?.Trim(), out nPortInput))
                {
                    Console.WriteLine("잘못된 포트 번호가 입력되었습니다. 프로그램을 종료합니다.");
                    return;
                }

                if (nPortInput <= 0 || nPortInput > 65535)
                {
                    Console.WriteLine("포트 번호는 0 이상 65535 이하의 값이어야 합니다.");
                    return;
                }

                Console.WriteLine($"서버 정보 >> IP 주소 : {ipaddr} / 포트 : {nPortInput}");

                sock.Connect(ipaddr, nPortInput);

                Console.WriteLine("서버에 연결되었습니다.");



                Console.WriteLine("텍스트를 입력 후 Enter 키를 누르면 전송됩니다.");
                Console.WriteLine("프로그램을 종료하려면 <EXIT> 를 입력하세요.");

                string inputCommand = string.Empty;

                while(true)
                {
                    inputCommand = Console.ReadLine() ?? string.Empty;

                    if (inputCommand.Equals("<EXIT>"))
                    {
                        break;
                    }

                    byte[] buffSend = Encoding.ASCII.GetBytes(inputCommand);

                    sock.Send(buffSend);

                    byte[] buffReceived = new byte[128];
                    int nRecv = sock.Receive(buffReceived);

                    Console.WriteLine("서버로부터 수신한 데이터 : {0}", Encoding.ASCII.GetString(buffReceived, 0, nRecv));


                }
            }
            catch (SocketException se) when (se.SocketErrorCode == SocketError.ConnectionRefused)
            {
                Console.WriteLine("⚠ 연결 거절: 해당 주소/포트에서 서버가 수신 중이 아닙니다.");
                Console.WriteLine("- 서버가 실행 중인지 확인");
            }
            catch (SocketException se)
            {
                Console.WriteLine($"소켓 예외: {se.SocketErrorCode} - {se.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"예상치 못한 오류: {ex}");
            }
            finally
            {
                //(5)
                if (sock != null)
                {
                    if (sock.Connected)
                        sock.Shutdown(SocketShutdown.Both);

                    sock.Dispose();// Close() 생략 가능 (Dispose가 Close 포함)
                }

                //string stop = Console.ReadLine();
            }

            Console.WriteLine("아무 키나 누르면 프로그램이 종료됩니다...");
            Console.ReadKey();


        }
    }
}
