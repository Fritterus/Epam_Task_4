﻿using System;
using System.Threading;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("127.0.0.1", 5000);

            client.Connect();
            client.Disconnect();
        }
    }
}
