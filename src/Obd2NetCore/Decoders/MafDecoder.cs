﻿using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public sealed class MafDecoder : IDecoder<decimal>
    {
        public IOBDResponse<decimal> Execute(params IMessage[] messages)
        {
            var d = messages[0].Data;
            var v = Utils.BytesToInt(d) / 100m;
            return new OBDResponse<decimal>(v, Unit.Gps);
        }
    }
}