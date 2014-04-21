using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new TcpListener(IPAddress.Any, 9999);
            listener.Start();
            try
            {
                // While the Running bool is true, the listener is not null and there is no cancellation requested
                    using (var client = listener.AcceptTcpClient())
                    using (var s = client.GetStream())
                    {
                        while (true)
                        {
                            var buffer = new byte[10];
                            s.Read(buffer, 0, 10);
                            for (var i = 0; i < 10; i++)
                            {
                                buffer[i]++;
                            }
                            s.Write(buffer, 0, 10);

/*
                            for (var i = 0; i < 10; i++)
                            {
                                s.Read(buffer, i, 1);
                                buffer[i]++;
                                s.Write(buffer, i, 1);
                            }
*/
                            s.Flush();
                        }
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            listener.Stop();
        }
    }
}
