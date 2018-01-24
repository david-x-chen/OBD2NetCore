using Obd2NetCore.Decoders;
using Obd2NetCore.InfrastructureContracts.Enums;

namespace Obd2NetCore.Commands.Mode1
{
    internal class FuelStatusCommand : OBDCommandBase<FuelStatusDecoder, string>
    {
        public FuelStatusCommand(FuelStatusDecoder decoder) :
            base(decoder, Mode.Mode1, "FUEL_STATUS", "Fuel System Status", "0103", 2, ECU.Engine, true)
        {
        }
    }
}