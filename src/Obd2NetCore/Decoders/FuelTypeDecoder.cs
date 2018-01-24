using System;
using Obd2NetCore.Extensions;
using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public  sealed class FuelTypeDecoder : IDecoder<string>
    {
        public IOBDResponse<string> Execute(params IMessage[] messages)
        {
            var d = messages[0].Data;
            var v = (int)d[0];

            if (v <= 0 || !Enum.IsDefined(typeof(FuelType), v))
                return new OBDResponse<string>("Error: Unknown fuel type response", Unit.None);

            return new OBDResponse<string>(((FuelType)v).GetDescription(), Unit.None);
        }
    }
}