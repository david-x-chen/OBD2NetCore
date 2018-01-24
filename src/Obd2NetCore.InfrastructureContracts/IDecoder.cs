using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.InfrastructureContracts
{
    public interface IDecoder { }
    public interface IDecoder<T> : IDecoder
    {
        IOBDResponse<T> Execute(params IMessage[] messages);
    }
}