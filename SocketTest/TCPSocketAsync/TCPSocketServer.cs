using System.Net;
using System.Net.Sockets;

namespace TCPSocketAsync
{
    public class TCPSocketServer
    {
        IPAddress? mIP;
        int mPort;
        TcpListener? mTCPListener;

        public bool KeepRunning { get; set; } = false;

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

            try
            {
                //(2)
                mTCPListener.Start();
                Console.WriteLine($"Server started on {mIP.ToString()}:{mPort}");

                KeepRunning = true;

                while (KeepRunning)
                {
                    //(3)
                    TcpClient client = await mTCPListener.AcceptTcpClientAsync();
                    Console.WriteLine("Client connected. : {client.Client.RemoteEndPoint}"); 

                    ManageClient(client);


                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Socket error: {ex.Message}");
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Listener stopped manually.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                if (mTCPListener != null)
                {
                    mTCPListener.Stop();
                    Console.WriteLine("Server stopped.");
                }

                KeepRunning = false;
            }
        }

        private async void ManageClient(TcpClient client)
        {
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
                        break; // Client disconnected
                    string receivedData = new string(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {receivedData}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
