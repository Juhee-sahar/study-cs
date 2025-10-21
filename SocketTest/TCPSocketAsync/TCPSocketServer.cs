using System.Net;
using System.Net.Sockets;

namespace TCPSocketAsync
{
    public class TCPSocketServer
    {
        IPAddress? mIP;
        int mPort;
        TcpListener? mTCPListener;

        public async Task StartServerListeningAsync(IPAddress? ipaddr = null, int port = 23000)
        {
            if (ipaddr == null)
                ipaddr = IPAddress.Loopback; // Default to localhost

            if (port <= 0 || mPort > 65535)
                port = 23000; // Default port

            mIP = ipaddr;
            mPort = port;

            //(1)
            mTCPListener = new TcpListener(mIP, mPort);

            //(2)
            mTCPListener.Start();
            Console.WriteLine($"Server started on {mIP.ToString()}:{mPort}");

            //(3)
            TcpClient client = await mTCPListener.AcceptTcpClientAsync();
            Console.WriteLine("Client connected.");
        }



    }
}
