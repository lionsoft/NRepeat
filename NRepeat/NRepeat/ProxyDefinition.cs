using System;
using System.Net;

namespace NRepeat
{
    public class ProxyDefinition
    {
        public IPAddress ServerAddress { get; set; }
        public IPAddress ClientAddress { get; set; }
        public Int16 ServerPort { get; set; }
        public Int16 ClientPort { get; set; }
    }
}
