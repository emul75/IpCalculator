using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace IpCalculator
{
    internal static class IpCalculator
    {
        private static void Main(string[] args)
        {
            string userInputIp;
            do
            {
                Console.Write("Type IP adress: ");
                userInputIp = Console.ReadLine();
            } while (!Calculate.CheckValidation(userInputIp));

            Ipv4 ip = new Ipv4 {FullIp = userInputIp};
            
            string[] temp = ip.FullIp.Split("/");
            ip.IpAddress = temp[0];
            ip.ShortMask = Convert.ToInt32(temp[1]);

            ip.BinaryIpAddress = Calculate.ConvertToBinary(ip.IpAddress);

            ip.BinaryMask = Calculate.Mask(ip.ShortMask);
            ip.Mask = Calculate.ConvertToDecimal(ip.BinaryMask);

            ip.BinaryNetwork = Calculate.Network(ip.IpAddress, ip.BinaryMask);
            ip.Network = Calculate.ConvertToDecimal(ip.BinaryNetwork);

            ip.BinaryBroadcast = Calculate.Broadcast(ip.IpAddress, ip.BinaryMask);
            ip.Broadcast = Calculate.ConvertToDecimal(ip.BinaryBroadcast);

            ip.HostMin = Calculate.HostMin(ip.Network);
            ip.BinaryHostMin = Calculate.ConvertToBinary(ip.HostMin);

            ip.HostMax = Calculate.HostMax(ip.Broadcast);
            ip.BinaryHostMax = Calculate.ConvertToBinary(ip.HostMax);

            ip.NumberOfHosts = Calculate.NumberOfHosts(ip.ShortMask);

            ip.NetworkClass = Calculate.NetworkClass(ip.IpAddress);

            string toJson = JsonSerializer.Serialize(ip, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            Console.WriteLine($"{toJson}");
            File.WriteAllText("../../../Output.json", toJson);
        }
    }
}