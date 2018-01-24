using System.Collections.Generic;

namespace Obd2NetCore.InfrastructureContracts
{
    public interface IStatus
    {
        int DTCCount { get; set; }
        string IgnitionType { get; set; }
        bool Mil { get; set; }
        List<ITest> Tests { get; set; }
    }
}