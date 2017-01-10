using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using grpc_server.Impl;
using Grpc.Core;

namespace grpc_server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { Minglogger.LogService.BindService(new LoggerImpl()) },
                Ports = { new ServerPort("localhost", 50001, ServerCredentials.Insecure) }
            };
            server.Start();
        }
    }
}
