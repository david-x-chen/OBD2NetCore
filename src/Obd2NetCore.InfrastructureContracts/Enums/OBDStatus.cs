using System.ComponentModel;

namespace Obd2NetCore.InfrastructureContracts.Enums
{
    public enum OBDStatus
    {
        [Description("Not Connected")]
        NotConnected,
        [Description("ELM Connected")]
        ElmConnected,
        [Description("Car Connected")]
        CarConnected
    }
}