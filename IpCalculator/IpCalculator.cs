using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace IpCalculator
{
    public static class IpCalculator
    {
        private static void Main(string[] args)
        {
            string userInputIp;
            do
            {
                Console.Write("Enter IP adress ( for example 82.126.84.209/14 ): ");
                userInputIp = Console.ReadLine();
            } while (!Calculator.CheckCorrectIpFormat(userInputIp));

            Ipv4 ip = new(userInputIp);

            string toJson = JsonSerializer.Serialize(ip, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            File.WriteAllText("../../../output.json", toJson);

            const string symbolsToDelete = "{}\":,";
            Console.WriteLine(symbolsToDelete.Aggregate(toJson,
                (current, c) => current.Replace(Convert.ToString(c), "").Replace("  ", "")));
        }
    }
}