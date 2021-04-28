using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IpCalculator
{
    public static class Calculator
    {
        public static bool CheckCorrectIpFormat(string ip)
        {
            const string pattern =
                @"^(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9])(\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9])){2}\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9])\/(3[0-2]|[0-2]?[0-9])$";
            if (Regex.IsMatch(ip, pattern)) return true;
            Console.WriteLine("Bad IP Address format, please try again.");
            return false;
        }

        public static string CalculateNetwork(string ip, string mask)
        {
            return CalculateNetworkOrBroadcast(ip, mask, true, false);
        }

        public static string CalculateBroadcast(string ip, string mask)
        {
            return CalculateNetworkOrBroadcast(ip, mask, false, true);
        }

        private static string CalculateNetworkOrBroadcast(string ip, string mask, bool network, bool broadcast)
        {
            ip = ConvertToBinary(ip).Replace(".", "");
            mask = mask.Replace(".", "");

            string address = null;
            for (int i = 0; i < 32; i++)
            {
                address = string.Concat(address, mask[i] == '1' ? ip[i] : (broadcast ? "1" : "0"));
            }

            return AddDotsToBinaryAddress(address);
        }

        public static string CalculateNetworkClass(string ip)
        {
            ip = ip.Split(".")[0];

            return Convert.ToInt32(ip) switch
            {
                <= 0 and <= 128 => "A",
                <= 128 and <= 192 => "B",
                <= 192 and <= 223 => "C",
                <= 224 and <= 239 => "D",
                <= 240 and <= 255 => "E",
                _ => throw new ArgumentOutOfRangeException(nameof(ip), "Octet out of range 0-255")
            };
        }

        public static string CalculateMask(int shortMask)
        {
            string fullMask = "";
            for (int i = 0; i < 32; i++)
            {
                fullMask = string.Concat(fullMask, i < shortMask ? "1" : "0");
            }

            return AddDotsToBinaryAddress(fullMask);
        }

        public static string CalculateHostMin(string network)
        {
            var octets = new List<string>(network.Split("."));
            for (int i = 4 - 1; i >= 0; i--)
            {
                if (Convert.ToInt32(octets[i]) == 255)
                {
                    octets[i] = "0";
                    continue;
                }

                octets[i] = Convert.ToString(Convert.ToInt32(octets[i]) + 1);
                break;
            }

            return string.Join(".", octets);
        }

        public static string CalculateHostMax(string broadcast)
        {
            var octets = new List<string>(broadcast.Split("."));
            for (int i = 4 - 1; i >= 0; i--)
            {
                if (Convert.ToInt32(octets[i]) == 0)
                {
                    octets[i] = "255";
                    continue;
                }

                octets[i] = Convert.ToString(Convert.ToInt32(octets[i]) - 1);
                break;
            }

            return string.Join(".", octets);
        }

        public static long CalculateNumberOfHosts(int shortMask)
        {
            return Convert.ToInt64(Math.Pow(2, 32 - shortMask) - 2.0);
        }


        //Converting methods
        public static string ConvertToBinary(string address)
        {
            var octets = new List<string>(address.Split("."));
            for (int i = 0; i < 4; i++)
            {
                octets[i] = Convert.ToString(Convert.ToInt32(octets[i], 10), 2).PadLeft(8, '0');
            }

            return string.Join(".", octets);
        }

        public static string ConvertToDecimal(string address)
        {
            var octets = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                octets.Add(Convert.ToString(Convert.ToInt32(address.Split(".")[i], 2), 10));
            }

            return string.Join(".", octets);
        }

        private static string AddDotsToBinaryAddress(string address)
        {
            for (int i = 8; i < 32; i += 9) address = address.Insert(i, ".");
            return address;
        }
    }
}