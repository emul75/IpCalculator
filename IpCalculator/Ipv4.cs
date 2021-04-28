using System;

namespace IpCalculator
{
    public class Ipv4
    {
        public string FullIp { get; set; }
        public string IpAddress { get; set; }
        public string BinaryIpAddress { get; set; }
        public int ShortMask { get; set; }
        public string Mask { get; set; }
        public string BinaryMask { get; set; }
        public string Network { get; set; }
        public string BinaryNetwork { get; set; }
        public string Broadcast { get; set; }
        public string BinaryBroadcast { get; set; }
        public long NumberOfHosts { get; set; }
        public string HostMin { get; set; }
        public string BinaryHostMin { get; set; }
        public string HostMax { get; set; }
        public string BinaryHostMax { get; set; }
        public string NetworkClass { get; set; }

        public Ipv4(string fullIp)
        {
            FullIp = fullIp;
            string[] temp = FullIp.Split("/");
            IpAddress = temp[0];
            ShortMask = Convert.ToInt32(temp[1]);

            BinaryIpAddress = Calculator.ConvertToBinary(IpAddress);

            BinaryMask = Calculator.CalculateMask(ShortMask);
            Mask = Calculator.ConvertToDecimal(BinaryMask);

            BinaryNetwork = Calculator.CalculateNetwork(IpAddress, BinaryMask);
            Network = Calculator.ConvertToDecimal(BinaryNetwork);

            BinaryBroadcast = Calculator.CalculateBroadcast(IpAddress, BinaryMask);
            Broadcast = Calculator.ConvertToDecimal(BinaryBroadcast);

            HostMin = Calculator.CalculateHostMin(Network);
            BinaryHostMin = Calculator.ConvertToBinary(HostMin);

            HostMax = Calculator.CalculateHostMax(Broadcast);
            BinaryHostMax = Calculator.ConvertToBinary(HostMax);

            NumberOfHosts = Calculator.CalculateNumberOfHosts(ShortMask);

            NetworkClass = Calculator.CalculateNetworkClass(IpAddress);

        }
    }
}