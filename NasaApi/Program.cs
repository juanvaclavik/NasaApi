using Microsoft.Extensions.DependencyInjection;
using NasaApi.ResultBuilders;
using NasaApi.Services;
using System;
using System.Threading.Tasks;

namespace NasaApi
{
    class Program
    {
        static void Main()
        {
            // DI implementation
            var serviceProvider = new ServiceCollection()
                .AddHttpClient()
                .AddSingleton<IService, Service>()
                .AddSingleton<IResultBuilder, ResultBuilder>()
                .BuildServiceProvider();

            var program = serviceProvider.GetService<IResultBuilder>();

            Console.WriteLine("1st task:");

            // Print first five Mars surface images hrefs
            var url = "https://images-api.nasa.gov/search?media_type=image&year_start=2018&year_end=2018&keywords=mars";
            program.AnalyzeImages(url);


            Console.WriteLine("---------------------------------");
            Console.WriteLine("2st task:");

            // Print info from media library
            url = "https://images-api.nasa.gov/search?media_type=video&year_start=2018&year_end=2018&keywords=mars";
            program.AnalyzeVideoLibrary(url);

            Console.WriteLine("Application finished");
            Console.ReadLine();
        }
    }
}
