using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new System.Net.Sockets.TcpClient("127.0.0.1", 8888);
            var buffer = new byte[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            var socket = c.Client;
            while (buffer[0] != 255)
            {
                socket.Send(buffer);
                socket.Receive(buffer);
            }
        }
    }
}
