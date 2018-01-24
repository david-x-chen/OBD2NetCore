namespace Obd2NetCore.InfrastructureContracts
{
    public interface ITest
    {
        bool Available { get; set; }
        bool Incomplete { get; set; }
        string Name { get; set; }
    }
}