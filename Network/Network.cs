namespace Network
{
    /// <summary>
    /// Basic class for network element
    /// </summary>
    public abstract class Network
    {
        public string Ip { get; private set; }
        public int Port { get; private set; }
        /// <summary>
        /// Setting the ip and port of the network element
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public Network(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }
    }
}
