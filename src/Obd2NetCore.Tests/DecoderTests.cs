using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Obd2NetCore.Decoders;
using Obd2NetCore.Infrastructure;
using Obd2NetCore.InfrastructureContracts;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;
using Obd2NetCore.InfrastructureContracts.Response;
using Obd2NetCore.Protocols;
using Xunit;

namespace Obd2NetCore.Tests
{
    public class DecoderTests
    {
        private T Decoder<T>() where T : class, IDecoder, new()
        {
            return new T();
        }
        
        [Theory]
        [InlineData("00000000", "00000000000000000000000000000000", Unit.None)]
        [InlineData("F00AA00F", "11110000000010101010000000001111", Unit.None)]
        [InlineData("11", "00010001", Unit.None)]
        public void PidTest(string hex, string result, Unit unit)
        {
            Decoder<PidDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<string>(result, unit));
        }

        
        [Fact(Skip = "TODO")]
        public void EvapPressureTest()
        {
            true.Should().BeFalse();
        }

        [Fact(Skip = "TODO")]
        public void ObdComplianceTest()
        {
            true.Should().BeFalse();
        }

        [Fact(Skip = "TODO")]
        public void StatusTest()
        {
            true.Should().BeFalse();
        }

        [Theory]
        [InlineData("00", 0, Unit.Count)]
        [InlineData("0F", 15, Unit.Count)]
        [InlineData("03E8", 1000, Unit.Count)]
        public void CountTest(string hex, int result, Unit unit)
        {
            Decoder<CountDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<int>(result, unit));
        }

        [Theory]
        [InlineData("00", 0, Unit.Percent)]
        [InlineData("FF", 100, Unit.Percent)]
        [InlineData("03E8", 1.18, Unit.Percent)]
        public void PercentTest(string hex, decimal result, Unit unit)
        {
            Decoder<PercentDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("00", -100, Unit.Percent)]
        [InlineData("80", 0, Unit.Percent)]
        [InlineData("FF", 99.21875, Unit.Percent)]
        public void PercentCenteredTest(string hex, decimal result, Unit unit)
        {
            Decoder<PercentCenteredDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("00", -40, Unit.C)]
        [InlineData("FF", 215, Unit.C)]
        [InlineData("03E8", 960, Unit.C)]
        public void TemperatureTest(string hex, int result, Unit unit)
        {
            Decoder<TemperatureDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<int>(result, unit));
        }

        [Theory]
        [InlineData("0000", -40, Unit.C)]
        [InlineData("FFFF", 6513.5, Unit.C)]
        public void CatalystTemperatureTest(string hex, decimal result, Unit unit)
        {
            Decoder<CatalystTemperatureDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("00000000", -128, Unit.Ma)]
        [InlineData("00008000", 0, Unit.Ma)]
        [InlineData("0000FFFF", 127.99609375, Unit.Ma)]
        [InlineData("ABCD8000", 0, Unit.Ma)]
        public void CurrentCenteredTest(string hex, decimal result, Unit unit)
        {
            Decoder<CurrentCenteredDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("0000", 0, Unit.Volt)]
        [InlineData("FFFF", 1.275, Unit.Volt)]
        public void SensorVoltageTest(string hex, decimal result, Unit unit)
        {
            Decoder<SensorVoltageDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("00000000", 0, Unit.Volt)]
        [InlineData("00008000", 4, Unit.Volt)]
        [InlineData("0000FFFF", 8, Unit.Volt)]
        [InlineData("ABCD0000", 0, Unit.Volt)]
        public void SensorVoltageBigTest(string hex, decimal result, Unit unit)
        {
            Decoder<SensorVoltageBigDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("00", 0u, Unit.Kpa)]
        [InlineData("80", 384u, Unit.Kpa)]
        [InlineData("FF", 765u, Unit.Kpa)]
        public void FuelPressureTest(string hex, uint result, Unit unit)
        {
            Decoder<FuelPressureDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<uint>(result, unit));
        }

        [Theory]
        [InlineData("00", 0u, Unit.Kpa)]
        [InlineData("80", 128u, Unit.Kpa)]
        public void PressureTest(string hex, uint result, Unit unit)
        {
            OldDecoders.Pressure(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<uint>(result, unit));
        }

        [Theory]
        [InlineData("0000", 0, Unit.Kpa)]
        [InlineData("0080", 10.112, Unit.Kpa)]
        [InlineData("FFFF", 5177.265, Unit.Kpa)]
        public void FuelPresureVacTest(string hex, decimal result, Unit unit)
        {
            Decoder<FuelPressureVacuumDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("0000", 0, Unit.Kpa)]
        [InlineData("F00F", 614550, Unit.Kpa)]
        [InlineData("FFFF", 655350, Unit.Kpa)]
        public void FuelPresureDirectTest(string hex, int result, Unit unit)
        {
            Decoder<FuelPressureDirectDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<int>(result, unit));
        }

        [Theory]
        [InlineData("0000", 0, Unit.Kpa)]
        [InlineData("F00F", 307.275, Unit.Kpa)]
        [InlineData("FFFF", 327.675, Unit.Kpa)]
        public void AbsEvapPressureTest(string hex, decimal result, Unit unit)
        {
            Decoder<AbsEvapPressureDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("0000", -32767, Unit.Pa)]
        [InlineData("7FFF", 0, Unit.Pa)]
        [InlineData("FFFF", 32768, Unit.Pa)]
        public void EvapPressureAltTest(string hex, int result, Unit unit)
        {
            Decoder<EvapPressureAltDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<int>(result, unit));
        }

        [Theory]
        [InlineData("0000", 0u, Unit.Rpm)]
        [InlineData("00C1", 48u, Unit.Rpm)]
        [InlineData("7FFF", 8191u, Unit.Rpm)]
        [InlineData("FFFF", 16383u, Unit.Rpm)]
        public void RpmTest(string hex, uint result, Unit unit)
        {
            Decoder<RpmDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<uint>(result, unit));
        }

        [Theory]
        [InlineData("00", 0, Unit.Kph)]
        [InlineData("FF", 255, Unit.Kph)]
        [InlineData("A3", 163, Unit.Kph)]
        public void SpeedTest(string hex, decimal result, Unit unit)
        {
            Decoder<SpeedDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("00", -64, Unit.Degrees)]
        [InlineData("FF", 63.5, Unit.Degrees)]
        [InlineData("A0", 16, Unit.Degrees)]
        public void TimingAdvanceTest(string hex, decimal result, Unit unit)
        {
            Decoder<TimingAdvanceDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("0000", -210, Unit.Degrees)]
        [InlineData("FFFF", 302, Unit.Degrees)]
        [InlineData("C9A0", 193, Unit.Degrees)]
        public void InjectTimingTest(string hex, int result, Unit unit)
        {
            Decoder<InjectTimingDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<int>(result, unit));
        }

        [Theory]
        [InlineData("0000", 0, Unit.Gps)]
        [InlineData("FFFF", 655.35, Unit.Gps)]
        [InlineData("C9A0", 516.16, Unit.Gps)]
        public void MafTest(string hex, decimal result, Unit unit)
        {
            Decoder<MafDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("00000000", 0u, Unit.Gps)]
        [InlineData("FF000000", 2550u, Unit.Gps)]
        [InlineData("00ABCDEF", 0u, Unit.Gps)]
        public void MaxMafTest(string hex, uint result, Unit unit)
        {
            Decoder<MaxMafDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<uint>(result, unit));
        }

        [Theory]
        [InlineData("0000", 0u, Unit.Sec)]
        [InlineData("FFFF", 65535u, Unit.Sec)]
        [InlineData("C9A0", 51616u, Unit.Sec)]
        public void SencondsTest(string hex, uint result, Unit unit)
        {
            Decoder<SecondsDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<uint>(result, unit));
        }

        [Theory]
        [InlineData("0000", 0u, Unit.Min)]
        [InlineData("FFFF", 65535u, Unit.Min)]
        [InlineData("C9A0", 51616u, Unit.Min)]
        public void MinutesTest(string hex, uint result, Unit unit)
        {
            Decoder<MinutesDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<uint>(result, unit));
        }

        [Theory]
        [InlineData("0000", 0u, Unit.Km)]
        [InlineData("FFFF", 65535u, Unit.Km)]
        [InlineData("C9A0", 51616u, Unit.Km)]
        public void DistanceTest(string hex, uint result, Unit unit)
        {
            Decoder<DistanceDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<uint>(result, unit));
        }

        [Theory]
        [InlineData("0000", 0, Unit.Lph)]
        [InlineData("FFFF", 3276.75, Unit.Lph)]
        [InlineData("C9A0", 2580.80, Unit.Lph)]
        public void FuelRateTest(string hex, decimal result, Unit unit)
        {
            Decoder<FuelRateDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<decimal>(result, unit));
        }

        [Theory]
        [InlineData("0100", "Open loop due to insufficient engine temperature", Unit.None)]
        [InlineData("0800", "Open loop due to system failure", Unit.None)]
        [InlineData("0300", null, Unit.None)]
        [InlineData("1000", "Closed loop, using at least one oxygen sensor but there is a fault in the feedback system", Unit.None)]
        public void FuelStatusTest(string hex, string result, Unit unit)
        {
            Decoder<FuelStatusDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<string>(result, unit));
        }

        [Theory]
        [InlineData("0100", "Upstream", Unit.None)]
        [InlineData("0800", "Pump commanded on for diagnostics", Unit.None)]
        [InlineData("0300", null, Unit.None)]
        [InlineData("1000", null, Unit.None)]
        public void AirStatusTest(string hex, string result, Unit unit)
        {
            Decoder<AirStatusDecoder>().Execute(Message.FromHexString(hex)).ShouldBeEquivalentTo(new OBDResponse<string>(result, unit));
        }

        [Theory]
        [MemberData(nameof(DecoderTestCases.TestCases), MemberType = typeof(DecoderTestCases))]
        public void ElmVoltageTest(string raw, decimal? result, Unit unit)
        {
            Decoder<ElmVoltageDecoder>().Execute(new Message(new Frame(raw))).ShouldBeEquivalentTo(new OBDResponse<decimal?>(result, unit));
        }

        public class DecoderTestCases
        {
            static readonly List<object[]> voltages = new List<object[]> {
                new object [] { "12.875", 12.875M, Unit.Volt },
                new object [] { "12", 12M, Unit.Volt },
                new object [] { "12ABCD", default(decimal?), Unit.None }
            };

            public static IEnumerable<object[]> TestCases =>
                voltages;
        }

        [Theory]
        [MemberData(nameof(DtcTestCases.TestCases), MemberType = typeof(DtcTestCases))]
        public void DtcTest(IMessage[] messages, IOBDResponse<IDictionary<string, string>> result)
        {
            Decoder<DtcDecoder>().Execute(messages).ShouldBeEquivalentTo(result);
        }

        public class DtcTestCases
        {
            static readonly object[] singleCode = new object[]
                        {
                            new []{ Message.FromHexString("0104") },
                            new OBDResponse<IDictionary<string, string>>(
                                new Dictionary<string, string>
                                {
                                    {"P0104", "Mass or Volume Air Flow Circuit Intermittent"}
                                }, Unit.None)
                        };

            static readonly object[] multipleCodes = new object[]
                        {
                            new[] {Message.FromHexString("010480034123")},
                            new OBDResponse<IDictionary<string, string>>(
                                new Dictionary<string, string>
                                {
                                    {"P0104", "Mass or Volume Air Flow Circuit Intermittent"},
                                    {"B0003", "Unknown error code"},
                                    {"C0123", "Unknown error code"}
                                }, Unit.None)
                        };

            // Invalid code lengths are dropped
            static readonly object[] invalidCodes = new object[]
                        {
                            new[] {Message.FromHexString("0104800341")},
                            new OBDResponse<IDictionary<string, string>>(
                                new Dictionary<string, string>
                                {
                                    {"P0104", "Mass or Volume Air Flow Circuit Intermittent"},
                                    {"B0003", "Unknown error code"}
                                }, Unit.None)
                        };

            // 0000 code are dropped
            static readonly object[] zeroCodes = new object[]
                        {
                            new[] {Message.FromHexString("000001040000")},
                            new OBDResponse<IDictionary<string, string>>(
                                new Dictionary<string, string>
                                {
                                    {"P0104", "Mass or Volume Air Flow Circuit Intermittent"}
                                }, Unit.None)
                        };

            static readonly object[] multipleMessages = new object[]
                        {
                            new[] {Message.FromHexString("0104"), Message.FromHexString("8003"), Message.FromHexString("0000")},
                            new OBDResponse<IDictionary<string, string>>(
                                new Dictionary<string, string>
                                {
                                    {"P0104", "Mass or Volume Air Flow Circuit Intermittent"},
                                    {"B0003", "Unknown error code"}
                                }, Unit.None)
                        };

            public static IEnumerable<object[]> TestCases
            {
                get
                {
                    yield return singleCode;

                    yield return multipleCodes;

                    yield return invalidCodes;

                    yield return zeroCodes;

                    yield return multipleMessages;
                }
            }
        }
    }
}