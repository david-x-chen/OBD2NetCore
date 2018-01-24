using Obd2NetCore.Decoders;
using Obd2NetCore.InfrastructureContracts.Enums;

namespace Obd2NetCore.Commands.Mode1
{
    internal class ShortFuelTrim2Command : OBDCommandBase<PercentCenteredDecoder, decimal>
    {
        public ShortFuelTrim2Command(PercentCenteredDecoder decoder) :
            base(decoder, Mode.Mode1, "SHORT_FUEL_TRIM_2", "Short Term Fuel Trim - Bank 2", "0108", 1, ECU.Engine, true)
        {
        }
    }
}