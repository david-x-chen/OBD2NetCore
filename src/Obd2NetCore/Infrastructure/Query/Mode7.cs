using System.Collections.Generic;
using Obd2NetCore.InfrastructureContracts.Commands;
using Obd2NetCore.InfrastructureContracts.Enums;

namespace Obd2NetCore.Infrastructure.Query
{
    public class Mode7
    {
        public Mode7()
        {
            Commands = new List<IOBDCommand>
            {
                GetFreezeDtc
            };
        }
        public IEnumerable<IOBDCommand> Commands { get; private set; }

        public IOBDCommand<IDictionary<string, string>> GetFreezeDtc { get; } = new OBDCommand<IDictionary<string, string>>("GET_FREEZE_DTC", "Get Freeze DTCs", "07", 0, OldDecoders.DTC, ECU.All, false);
    }
}