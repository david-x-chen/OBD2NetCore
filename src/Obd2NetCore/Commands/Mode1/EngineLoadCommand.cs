using Obd2NetCore.Decoders;
using Obd2NetCore.InfrastructureContracts.Enums;

namespace Obd2NetCore.Commands.Mode1
{
    internal class EngineLoadCommand : OBDCommandBase<PercentDecoder, decimal>
    {
        public EngineLoadCommand(PercentDecoder decoder) :
            base(decoder, Mode.Mode1, "ENGINE_LOAD", "Calculated Engine Load", "0104", 1, ECU.Engine, true)
        {
        }
    }
}