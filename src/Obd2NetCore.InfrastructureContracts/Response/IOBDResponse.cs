using System;
using Obd2NetCore.InfrastructureContracts.Commands;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;

namespace Obd2NetCore.InfrastructureContracts.Response
{
    public interface IOBDResponse
    {
        DateTime Time { get; set; }
        IMessage[] Messages { get; set; }
        Unit Unit { get; set; }
        object Raw { get; }
        IOBDCommand Command { get; set; }
    }

    public interface IOBDResponse<T> : IOBDResponse
    {
        T Value { get; set; }
    }
}