using Obd2NetCore.Decoders;
using Obd2NetCore.InfrastructureContracts.Enums;

namespace Obd2NetCore.Commands.Mode1
{
    internal class FreezeDtcCommand : OBDCommandBase<DropDecoder, string>
    {
        public FreezeDtcCommand(DropDecoder decoder) :
            base(decoder, Mode.Mode1, "FREEZE_DTC", "Freeze DTC", "0102", 2, ECU.Engine, true)
        {
        }
    }
}