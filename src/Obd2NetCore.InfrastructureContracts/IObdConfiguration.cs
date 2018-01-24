using System;

namespace Obd2NetCore.InfrastructureContracts
{
    public interface IOBDConfiguration
    {
        int Baudrate { get; }
        string Portname { get; }
        bool Fast { get; }
        TimeSpan Timeout { get; }
    }
}