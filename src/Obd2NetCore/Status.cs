using System.Collections.Generic;
using Obd2NetCore.InfrastructureContracts;

namespace Obd2NetCore
{
    public sealed class Status : IStatus
    {
        public Status()
        {
            Tests = new List<ITest>();
        }

        public bool Mil { get; set; }
        public int DTCCount { get; set; }
        public string IgnitionType { get; set; }
        public List<ITest> Tests { get; set; }
    }
}