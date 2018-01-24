using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public sealed class EvapPressureDecoder : IDecoder<decimal>
    {
        public IOBDResponse<decimal> Execute(params IMessage[] messages)
        {
            var d = messages[0].Data;
            var a = Utils.TwosComp(d[0], 8);
            var b = Utils.TwosComp(d[1], 8);
            var v = (a * 256.0m + b) / 4.0m;
            return new OBDResponse<decimal>(v, Unit.Pa);
        }
    }
}