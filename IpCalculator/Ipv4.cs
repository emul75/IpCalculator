using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace IpCalculator
{
    public class Ipv4
    {
        // 255.255.255.255/32
        public string FullIp { get; set; }//

        // In Decimal
        public string IpAddress { get; set; } //
        public int ShortMask { get; set; } //
        public string Network { get; set; }
        public string Broadcast { get; set; }
        public string HostMin { get; set; }
        public string HostMax { get; set; }
        public int NumberOfHosts { get; set; }//
        public string Netmask { get; set; }
        public string NetworkClass { get; set; }

        // In Binary
        public string BinaryIpAddress { get; set; } //
        public string Mask { get; set; }//
        public string BinaryNetwork { get; set; }//
        public string BinaryBroadcast { get; set; }//
        public string BinaryHostMin { get; set; }//
        public string BinaryHostMax { get; set; }//


    }
}