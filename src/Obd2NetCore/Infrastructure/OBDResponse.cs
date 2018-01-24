using System;
using Obd2NetCore.Extensions;
using Obd2NetCore.InfrastructureContracts.Commands;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;

namespace Obd2NetCore.Infrastructure
{
    public sealed class OBDResponse<T> : IOBDResponse<T>
    {
        internal static IOBDResponse<T> Empty { get; } = new OBDResponse<T>(default(T), Unit.None);

        public OBDResponse(T value, Unit unit)
        {
            Value = value;
            Unit = unit;
        }

        public IOBDCommand Command { get; set; }
        public IMessage[] Messages { get; set; }
        public T Value { get; set; }
        public Unit Unit { get; set; }
        public DateTime Time { get; set; }
        public object Raw => Value;

        public override string ToString()
        {
            return $"{Command?.Name ?? "Empty"}: {Value} {Unit.GetDescription()}";
        }
    }
}