using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace IpCalculator
{
    public static class Calculate
    {
        public static bool CheckValidation(string ip)
        {
            const string pattern =
                @"^(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9])(\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9])){2}\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9])\/(3[0-2]|[0-2]?[0-9])$";
            if (!Regex.IsMatch(ip, pattern))
            {
                Console.WriteLine("Bad IP Address patter, please try again.");
                return false;
            }

            Console.WriteLine("not bad");
            return true;
        }


        public static string NetworkOrBroadcast(string ip, string mask, bool broadcast)
        {
            string network = "";
            for (int i = 0; i < 32; i++)
            {
                network = string.Concat(network, mask[i] == '1' ? ip[i] : (broadcast ? "0" : "1"));
            }

            return network;
        }

        public static string Class(int firstOctet)
        {
            return firstOctet switch
            {
                <= 0 and <= 128 => "A",
                <= 128 and <= 192 => "B",
                <= 192 and <= 223 => "C",
                <= 224 and <= 239 => "D",
                <= 240 and <= 255 => "E",
                _ => throw new ArgumentOutOfRangeException(nameof(firstOctet), firstOctet, null)
            };
        }

        public static string FullMask(string mask)
        {
            string fullMask = "";
            for (int i = 0; i < 32; i++)
            {
                fullMask = string.Concat(fullMask, i < Convert.ToInt32(fullMask) ? "0" : "1");
            }

            return fullMask;
        }


        public static string HostMin(string network)
        {
            int address = Convert.ToInt32(network, 2);
            address++;
            return Convert.ToString(address);
        }

        public static string HostMax(string broadcast)
        {
            int address = Convert.ToInt32(broadcast, 2);
            address--;
            return Convert.ToString(address);
        }

        public static int NumberOfHosts(string mask)
        {
            return Convert.ToInt32(Math.Pow(2, 32 - Convert.ToInt32(mask)) - 2.0);
        }

        public static string ConvertToBinary(string ip)
        {
            return "0";
        }
    }
}