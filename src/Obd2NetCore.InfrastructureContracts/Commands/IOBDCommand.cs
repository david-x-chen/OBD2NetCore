using System;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.InfrastructureContracts.Commands
{
    public interface IOBDCommand<T> : IOBDCommand
    {
        Func<IMessage[], IOBDResponse<T>> Decoder { get; }
    }

    public interface IOBDCommand
    {
        string Name { get; }
        //string Description { get; }
        string Command { get; }
        int Bytes { get; }
        ECU Ecu { get; }
        bool Fast { get; }
        int Mode { get; }
        int Pid { get; }
    }
}