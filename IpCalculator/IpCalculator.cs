using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace IpCalculator
{
    internal static class IpCalculator
    {
        static void Main(string[] args)
        {
            string userInputIp;
            do
            {
                Console.Write("Type IP adress: ");
                userInputIp = "1.213.48.127/14";
            } while (!Calculate.CheckValidation(userInputIp));
            
            Ipv4 ip = new Ipv4 {FullIp = userInputIp};

            if (ip.FullIp != null)
            {
                string[] temp = ip.FullIp.Split("/");
                ip.IpAddress = temp[0];
                ip.ShortMask = Convert.ToInt32(temp[1]);
            }
            ip.BinaryIpAddress = Calculate.ConvertToBinary(ip.IpAddress);
            
            ip.Mask = Calculate.FullMask(ip.ShortMask);
            
            ip.BinaryNetwork = Calculate.NetworkOrBroadcast(ip.IpAddress, ip.Mask, false);
            ip.Network = Calculate.ConvertToDecimal(ip.BinaryNetwork);
            
            ip.BinaryBroadcast = Calculate.NetworkOrBroadcast(ip.IpAddress, ip.Mask, true);
            ip.Broadcast = Calculate.ConvertToDecimal(ip.BinaryBroadcast);
            
            ip.HostMin = Calculate.HostMin(ip.Network);
            ip.BinaryHostMin = Calculate.ConvertToBinary(ip.HostMin);
            
            ip.HostMax = Calculate.HostMax(ip.Broadcast);
            ip.BinaryHostMax = Calculate.ConvertToBinary(ip.HostMax);
            
            ip.NumberOfHosts = Calculate.NumberOfHosts(ip.ShortMask);

            string toJson = JsonSerializer.Serialize(ip, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            Console.WriteLine($"{toJson}");
            File.WriteAllText("../../../Output.json",toJson);
        }
    }
}