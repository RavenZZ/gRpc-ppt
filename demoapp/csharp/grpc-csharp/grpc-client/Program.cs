using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Minglogger;

namespace grpc_client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50001", ChannelCredentials.Insecure);
            var client = new LogService.LogServiceClient(channel);
            var log = new MingLog();
            ExecuteResult result = client.WriteLog(log);
            Console.ReadKey();
        }
    }
}
