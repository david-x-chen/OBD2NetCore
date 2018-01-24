using Obd2NetCore.Configuration;
using Obd2NetCore.InfrastructureContracts.Response;
using Obd2NetCore.Logging;
using Obd2NetCore.Ports;
using Obd2NetCore.Protocols.Can;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Obd2NetCore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new ConsoleLogger();
            var protocol = new ISO_15765_4_29bit_500k();
            var config = new OBDConfiguration("COM3", 9600, TimeSpan.FromMilliseconds(500), true);
            var elm = new Elm327(log, protocol, config);

            var obd = new Obd(new NullLogger(), elm);

            var subject = new Subject<IOBDResponse>();

            Observable
                .Interval(TimeSpan.FromMilliseconds(100))
                .Subscribe(x => subject.OnNext(obd.Query(OldCommands.Mode1.Speed)));

            //Observable
            //    .Interval(TimeSpan.FromMilliseconds(5))
            //    .Subscribe(x => subject.OnNext(obd.Query<,>(fuelPressureCmd, true)));

            subject.DistinctUntilChanged(x => x).Subscribe(System.Console.WriteLine);

            System.Console.ReadKey();
        }
    }
}
