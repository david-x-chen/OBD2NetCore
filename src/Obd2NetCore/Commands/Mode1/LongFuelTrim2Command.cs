using Obd2NetCore.Decoders;
using Obd2NetCore.InfrastructureContracts.Enums;

namespace Obd2NetCore.Commands.Mode1
{
    internal class LongFuelTrim2Command : OBDCommandBase<PercentCenteredDecoder, decimal>
    {
        public LongFuelTrim2Command(PercentCenteredDecoder decoder) :
            base(decoder, Mode.Mode1, "LONG_FUEL_TRIM_2", "Long Term Fuel Trim - Bank 2", "0109", 1, ECU.Engine, true)
        {
        }
    }
}