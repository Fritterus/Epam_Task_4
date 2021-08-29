using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Logger logger = new Logger();
            Server ser = new Server("127.0.0.1", 5000);

            ser.Start();
            ser.Stop();
        }
    }
}