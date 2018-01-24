using System;
using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public sealed class InjectTimingDecoder : IDecoder<int>
    {
        public IOBDResponse<int> Execute(params IMessage[] messages)
        {
            var d = messages[0].Data;
            var v = (Utils.BytesToInt(d) - 26880) / 128.0m;

            return new OBDResponse<int>(Convert.ToInt32(v), Unit.Degrees);
        }
    }
}