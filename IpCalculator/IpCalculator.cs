using System;

namespace IpCalculator
{
    internal static class IpCalculator
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string userInputIp;
                do
                {
                    Console.Write("Type IP adress: ");
                    userInputIp = Console.ReadLine();
                } while (!Calculate.CheckValidation(userInputIp));

                Ip.FullIp = userInputIp;
                Ip.Network = Calculate.NetworkOrBroadcast(Ip.IpAddress, Ip.ShortMask,false);
                Ip.Broadcast = Calculate.NetworkOrBroadcast(Ip.BinaryMask,Ip.ShortMask,true);
                Ip.NetworkClass = Calculate.Class(Convert.ToInt32(Ip.IpOctets[0]));
                Ip.BinaryMask = Calculate.FullMask(Ip.ShortMask);
            
            }
        }
    }
}