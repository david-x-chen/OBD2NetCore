using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public sealed class ElmVoltageDecoder : IDecoder<decimal?>
    {
        public IOBDResponse<decimal?> Execute(params IMessage[] messages)
        {
            decimal v;
            if (decimal.TryParse(messages[0].Frames[0].Raw, out v))
                return new OBDResponse<decimal?>(v, Unit.Volt);

            return new OBDResponse<decimal?>(null, Unit.None);
        }
    }
}