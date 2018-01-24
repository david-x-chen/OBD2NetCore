using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public sealed class EvapPressureAltDecoder : IDecoder<int>
    {
        public IOBDResponse<int> Execute(params IMessage[] messages)
        {
            var d = messages[0].Data;
            var v = Utils.BytesToInt(d) - 32767;

            return new OBDResponse<int>(v, Unit.Pa);
        }
    }
}