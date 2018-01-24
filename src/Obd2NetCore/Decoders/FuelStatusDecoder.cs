using System;
using Obd2NetCore.Extensions;
using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public sealed class FuelStatusDecoder : IDecoder<string>
    {
        public IOBDResponse<string> Execute(params IMessage[] messages)
        {
            var d = messages[0].Data;
            var f1 = (int)d[0]; // Single Fuel System in byte 1

            if (f1 <= 0 || !Enum.IsDefined(typeof(FuelStatus), f1))
                return new OBDResponse<string>(null, Unit.None);

            return new OBDResponse<string>(((FuelStatus)f1).GetDescription(), Unit.None);
        }
    }
}