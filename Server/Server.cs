using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class Server : Network.Network
    {
        private Thread _clientWait;

        public delegate void GetRequest(TcpClient client);

        private event GetRequest Notify;

        private int _clientCount = 1;
        private List<TcpClient> _clients = new List<TcpClient>();
        public TcpListener ServerSocket { get; private set; }

        /// <summary>
        /// Server constructor for class Server
        /// </summary>
        /// <param name="ip">Ip address of the server</param>
        /// <param name="port">Port of the server</param>
        public Server(string ip, int port) : base(ip, port)
        {
            IPAddress address = IPAddress.Parse(ip);
            ServerSocket = new TcpListener(address, port);
        }


        public void Subscribe(GetRequest request)
            => Notify += request;

        public void Unsubscribe(GetRequest request)
            => Notify -= request;


        /// <summary>
        /// Server startup
        /// </summary>
        public void Start()
        {

            ServerSocket.Start();
            _clientWait.Start();
        }

        /// <summary>
        /// Server stopping
        /// </summary>
        public void Stop()
        {
        }
    }
}
