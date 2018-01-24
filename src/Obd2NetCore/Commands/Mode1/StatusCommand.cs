using Obd2NetCore.Decoders;
using Obd2NetCore.InfrastructureContracts.Enums;

namespace Obd2NetCore.Commands.Mode1
{
    internal class StatusCommand : OBDCommandBase<StatusDecoder, string>
    {
        public StatusCommand(StatusDecoder decoder) : 
            base(decoder, Mode.Mode1, "STATUS", "Status since DTCs cleared", "0101", 4, ECU.Engine, true)
        {
        }
    }
}
