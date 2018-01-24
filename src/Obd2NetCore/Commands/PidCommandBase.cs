using Obd2NetCore.Decoders;
using Obd2NetCore.InfrastructureContracts.Enums;

namespace Obd2NetCore.Commands
{
    public abstract class PidCommandBase : OBDCommandBase<PidDecoder, string>
    {
        protected PidCommandBase(PidDecoder decoder, Mode mode, string name, string description, string command, int bytes, ECU ecu, bool fast) : base(decoder, mode, name, description, command, bytes, ecu, fast)
        {
        }
    }
}