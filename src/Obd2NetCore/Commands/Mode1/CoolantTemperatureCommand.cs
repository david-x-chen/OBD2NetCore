using Obd2NetCore.Decoders;
using Obd2NetCore.InfrastructureContracts.Enums;

namespace Obd2NetCore.Commands.Mode1
{
    internal class CoolantTemperatureCommand : OBDCommandBase<TemperatureDecoder, int>
    {
        public CoolantTemperatureCommand(TemperatureDecoder decoder) :
            base(decoder, Mode.Mode1, "COOLANT_TEMP", "Engine Coolant Temperature", "0105", 1, ECU.Engine, true)
        {
        }
    }
}