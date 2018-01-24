using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public sealed class SensorVoltageBigDecoder : IDecoder<decimal>
    {
        public IOBDResponse<decimal> Execute(params IMessage[] messages)
        {
            var d = messages[0].Data;
            var x = Utils.BytesToInt(d, 2, 4);
            var v = decimal.Round(x * 8 / 65535m, 1);
            return new OBDResponse<decimal>(v, Unit.Volt);
        }
    }
}