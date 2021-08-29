using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    /// <summary>
    /// Client class to connect to the server
    /// </summary>
    public class Client : Network.Network
    {
        private event SendRequestEvent Notify;

        private TcpClient _client = new TcpClient();
        private IPAddress _address;
        private NetworkStream _ns;
        private Thread thread;

        public delegate string SendRequestEvent();

        public List<string> ClientHistory { get; private set; }
            = new List<string>();

        public ObservableCollection<string> ServerHistory { get; private set; }
            = new ObservableCollection<string>();


        /// <summary>
        /// Client constructor for class Client
        /// </summary>
        /// <param name="ip">Ip address of the server to connect to</param>
        /// <param name="port">Port of the server to connect to</param>
        public Client(string ip, int port) : base(ip, port)
        {
            _address = IPAddress.Parse(ip);
        }

        /// <summary>
        /// Subscribe to an event when receiving a answer from the server
        /// </summary>
        /// <param name="function">Delegate for the event</param>
        public void Subscribe(SendRequestEvent function) =>
            Notify += function;

        /// <summary>
        /// Unsubscribe to an event when receiving a anwser from the server
        /// </summary>
        /// <param name="function">Delegate for the event</param>
        public void Unsubscribe(SendRequestEvent function) =>
            Notify -= function;

        /// <summary>
        /// Connecting to server
        /// </summary>
        public void Connect()
        {
            _client.Connect(_address, Port);
            _ns = _client.GetStream();
        }

        /// <summary>
        /// Disconnect from server
        /// </summary>
        public void Disconnect()
        {
            if (thread.IsAlive) thread.Join();
        }
    }
}
