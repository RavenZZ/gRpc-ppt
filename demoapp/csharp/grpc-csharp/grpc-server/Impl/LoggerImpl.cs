using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Minglogger;

namespace grpc_server.Impl
{
    public class LoggerImpl :LogService.LogServiceBase
    {
        public override Task<ExecuteResult> WriteLog(MingLog request, ServerCallContext context)
        {
            ////blah blah blah blah
            return base.WriteLog(request, context);
        }
    }
}
