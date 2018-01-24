using System;
using System.Collections.Generic;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;

namespace Obd2NetCore.InfrastructureContracts
{
    public interface IPort
    {
        IOBDConfiguration Config { get; }
        OBDStatus Status { get; }
        IProtocol Protocol { get; }
        IEnumerable<ECU> Ecus { get; }
        void Close();
        IMessage[] SendAndParse(string cmd);
        string[] Send(string cmd, TimeSpan? delay = null);
        bool Connect();
    }
}