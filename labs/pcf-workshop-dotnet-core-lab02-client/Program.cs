using System;
using System.Net.Http;
using System.Threading;

namespace Pcf.Workshop.Dotnet.Core.Lab02.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Number of calls: ");
            int count = Convert.ToInt32(Console.ReadLine());

            Console.Write("Length of interval (in milliseconds): ");
            int seconds = Convert.ToInt32(Console.ReadLine());

            string url = "https://pcf-workshop-dotnet-core-lab02.pcfbeta.io/api/values";

            Console.WriteLine("Calling API...");

            var client = new HttpClient();

            for (int i = 1; i <= count; i++)
            {
                try
                {
                    var result = client.GetAsync(url).Result;

                    Console.WriteLine($"Iteration: {i}");

                    Thread.Sleep(seconds);
                }
                finally
                { }
            }

            Console.WriteLine("Done!");
        }
    }
}
