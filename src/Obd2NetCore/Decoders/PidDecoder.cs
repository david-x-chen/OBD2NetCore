using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public sealed class PidDecoder : IDecoder<string>
    {
        public IOBDResponse<string> Execute(params IMessage[] messages)
        {
            var d = messages[0].Data;
            return new OBDResponse<string>(Utils.BytesToBits(d), Unit.None);
        }
    }
}
