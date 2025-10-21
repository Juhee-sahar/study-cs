using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPSocketAsync
{
    public class TCPSocketServer
    {
        IPAddress? mIP;
        int mPort;
        TcpListener? mTCPListener;

        List<TcpClient> mClients;   

        public TCPSocketServer()
        {
            mClients = new List<TcpClient>();   
        }

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

                    // 연결될 때마다 서버-클라이언트 동작해야 할 로직
                    mClients.Add(client);
                    Console.WriteLine(
                        string.Format("클라이언트 연결 완료 (총 연결 수: {0}) - 원격 주소: {1}",
                        mClients.Count, client.Client.RemoteEndPoint)
                        );

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
                    {
                        RemoveClient(client);
                        Console.WriteLine("disconnected client");
                        break; // Client disconnected
                    }

                    string receivedData = new string(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {receivedData}");

                    _ = SendToAll(receivedData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"클라이언트 처리 중 오류 : {ex.Message}");
                RemoveClient(client);
            }
        }

        private void RemoveClient(TcpClient client)
        {
            if (mClients.Contains(client))
            {
                mClients.Remove(client);
                Debug.WriteLine(String.Format("클라이언트 연결 종료, 총 연결 수: {0}", mClients.Count));
            }
        }

        public async Task SendToAll(string Msg)
        {
            if (string.IsNullOrEmpty(Msg))
            {
                return;
            }

            try
            {
                byte[] buffMessage = Encoding.ASCII.GetBytes(Msg);

                foreach (TcpClient clnt in mClients)
                {
                    await clnt.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
    }
}
