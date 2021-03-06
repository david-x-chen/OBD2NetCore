using System;
using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public sealed class SpeedDecoder : IDecoder<uint>
    {
        public IOBDResponse<uint> Execute(params IMessage[] messages)
        {
            var d = messages[0].Data;
            var v = Convert.ToUInt32(Utils.BytesToInt(d));
            return new OBDResponse<uint>(v, Unit.Kph);
        }
    }
}