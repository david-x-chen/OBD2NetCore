using Obd2NetCore.InfrastructureContracts.Commands;

namespace Obd2NetCore.Extensions
{
    internal static class OBDCommandExtensions
    {
        public static int Pid(this IOBDCommand obdCommand)
        {
            return Utils.Unhex(obdCommand.Command, 2);
        }

    }
}
