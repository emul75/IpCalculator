using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace IpCalculator
{
    public static class Ip
    {
        public static string FullIp { get; set; }


        public static string IpAddress { get; set; }
        public static string BinaryIp { get; set; }
        public static string[] IpOctets { get; set; }
        public static string ShortMask { get; set; }
        public static string Network { get; set; }
        public static string Mask { get; set; }
        public static string BinaryMask { get; set; }
        public static string Broadcast { get; set; }
        public static string HostMin { get; set; }
        public static string HostMax { get; set; }
        public static string NumberOfHosts { get; set; }
        public static string Netmask { get; set; }
        public static string NetworkClass { get; set; }

        
        public static string AddDots(string address)
        {
            for (int i = 4; i < 15; i += 5) address = address.Insert(i, ".");
            return address;
        }

        public static string RemoveDots(string address)
        {
            for (int i = 4; i < 15; i += 5) address = address.Remove(i, 1);
            return address;
        }

        private static void SplitIp()
        {
            string[] temp = FullIp.Split("/");
            IpAddress = RemoveDots(temp[0]);
            ShortMask = temp[1];
            IpOctets = IpAddress.Split(@".");
        }
    }
}