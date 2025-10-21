using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleAppServer01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket servSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipaddr = IPAddress.Any;
            IPEndPoint ipep = new IPEndPoint(ipaddr, 23000);

            // binding
            servSocket.Bind(ipep);

            // listening
            // Listen(대기큐 수)
            servSocket.Listen(5);
            Console.WriteLine("Server listening on : " + servSocket.LocalEndPoint?.ToString());
            Console.WriteLine("Waiting for incoming connection...");

            // accept
            Socket connSocket = servSocket.Accept();
            Console.WriteLine("Client connected. " + connSocket.ToString() + " - IP End Point : " + connSocket.RemoteEndPoint?.ToString());

            byte[] buff = new byte[128];
            int numberOfReceivedBytes = 0;

            // 서버에 문자 하나 보내기
            //numberOfReceivedBytes = connSocket.Receive(buff);
            //Console.WriteLine("Number of received bytes: " + numberOfReceivedBytes);
            //Console.WriteLine("Data sent by client is: " + buff);
            //string receivedText = Encoding.ASCII.GetString(buff, 0, numberOfReceivedBytes);
            //Console.WriteLine("Data sent by client is : " + receivedText);

            // 에코 서버
            while (true)
            {
                numberOfReceivedBytes = connSocket.Receive(buff);

                Console.WriteLine("Number of received bytes : " + numberOfReceivedBytes);
                Console.WriteLine("Data sent by client is : " + buff);

                string receivedText = Encoding.ASCII.GetString(buff, 0, numberOfReceivedBytes);
                Console.WriteLine("Data sent by client is : " + receivedText);

                connSocket.Send(buff);

                if (receivedText == "x")
                {
                    break;
                }

                Array.Clear(buff, 0, buff.Length);
                numberOfReceivedBytes = 0;
            }

        }
    }
}
