using System.Linq;
using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Decoders
{
    public sealed class RawStringDecoder : IDecoder<string>
    {
        public IOBDResponse<string> Execute(params IMessage[] messages)
        {
            return new OBDResponse<string>(string.Join("\n", messages.Select(m => m.Raw).ToArray()), Unit.None);
        }
    }
}