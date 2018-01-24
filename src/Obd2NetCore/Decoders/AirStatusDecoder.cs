using System;
using Obd2NetCore.Extensions;
using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public sealed class AirStatusDecoder : IDecoder<string>
    {
        public IOBDResponse<string> Execute(params IMessage[] messages)
        {
            var d = messages[0].Data;
            var v = (int)d[0];

            if (v <= 0 || !Enum.IsDefined(typeof(AirStatus), v))
                return new OBDResponse<string>(null, Unit.None);

            return new OBDResponse<string>(((AirStatus)v).GetDescription(), Unit.None);
        }
    }
}