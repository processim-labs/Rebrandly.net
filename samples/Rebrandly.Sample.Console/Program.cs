using Rebrandly;
using System;
using System.Threading.Tasks;

namespace RebrandlySample.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Presione tecla para continuar");
            Console.ReadLine();
            RebrandlyConfiguration.ApiKey = "907842e1f23c4615b9643d55bdce94ef";

            RebrandlyService rebradlyServices = new RebrandlyService();
            var response = await rebradlyServices.GetLink("52edba6afc154a99b7ee177172f66ff8");
            Console.WriteLine(response);
            Console.ReadLine();
        }
    }
}
