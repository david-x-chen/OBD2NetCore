﻿using System;
using System.Collections.Generic;
using System.Linq;
using Obd2NetCore.InfrastructureContracts.Enums;
using Obd2NetCore.InfrastructureContracts.Protocols;

namespace Obd2NetCore.Protocols
{
    public sealed class Message : IMessage, IEquatable<Message>
    {
        public Message(params IFrame[] frames)
            : this(ECU.Unknown, new byte[0], frames)
        {
        }

        public Message(ECU ecu, byte[] data, params IFrame[] frames)
        {
            Frames = frames;
            Ecu = ecu;
            Data = data;
        }

        public bool Equals(Message other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Ecu == other.Ecu && Equals(Frames, other.Frames) && Equals(Data, other.Data);
        }

        public ECU Ecu { get; set; }
        public IFrame[] Frames { get; set; }
        public byte[] Data { get; set; }

        public string Hex => BitConverter.ToString(Data).Replace("-", string.Empty);

        public string Raw
        {
            get { return string.Join("\n", Frames.Select(f => f.Raw).ToArray()); }
        }

        public int? TxId
        {
            get
            {
                if (Frames == null || !Frames.Any())
                    return null;
                return Frames[0].TxId;
            }
        }

        public bool Parsed => Data != null;

        public static IMessage FromHexString(string str)
        {
            var hexindex = new Dictionary<string, byte>();
            for (var i = 0; i <= 255; i++)
                hexindex.Add(i.ToString("X2"), (byte) i);

            var hexres = new List<byte>();
            for (var i = 0; i < str.Length; i += 2)
                hexres.Add(hexindex[str.Substring(i, 2)]);

            return new Message(ECU.Unknown, hexres.ToArray());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Message) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Ecu;
                hashCode = (hashCode*397) ^ (Frames?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Data?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}