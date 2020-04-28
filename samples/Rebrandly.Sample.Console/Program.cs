using Rebrandly;
using Rebrandly.Contracts;
using Rebrandly.Models;
using System;
using System.Threading.Tasks;

namespace RebrandlySample.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press Enter");
            Console.ReadLine();

            RebrandlyConfiguration.ApiKey = "ENTER YOUR API KEY";

            RebrandlyService rebrandlyService = new RebrandlyService();

            var response = await rebrandlyService.CreateShortLink(new CreateShortLinkRequest
            {
                Destination = "https://www.processimlabs.com/about-us",
                Domain = new Domain
                {
                    FullName = "rebrand.ly"
                }
            });

            Console.WriteLine(response);
            Console.ReadLine();
        }
    }
}
