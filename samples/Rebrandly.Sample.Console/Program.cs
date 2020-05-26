using Rebrandly;
using Rebrandly.Entities.Enums;
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

            RebrandlyConfiguration.ApiKey = "YOUR API KEY";

            LinkService rebrandlyLinkService = new LinkService();

            var response = await rebrandlyLinkService.Create(new LinkCreateOptions
            {
                Title = "New Short link",
                Destination = "https://www.processimlabs.com/products"
            });

            Console.WriteLine(response);
            Console.ReadLine();
        }
    }
}
