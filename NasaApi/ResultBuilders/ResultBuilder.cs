using NasaApi.Models;
using NasaApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NasaApi.ResultBuilders
{
    public class ResultBuilder : IResultBuilder
    {
        protected readonly IService Service;

        public ResultBuilder(IService service)
        {
            Service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task AnalyzeImages(string url)
        {               
            try
            {
                var response = await Service.GetData<Root>(url);
                if (response.Data != null) 
                {
                    var result = response.Data.collection.items.Take(5).Select(i => i.href).ToList();
                    PrintResult(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task AnalyzeVideoLibrary(string url)
        {
            try
            {
                var response = await Service.GetData<Root>(url);
                if (response.Data != null)
                {
                    var result = response.Data.collection.items.Select(i => i.href).ToList();
                    await AnalyzeLinks(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task AnalyzeLinks(List<string> responseLinks)
        {
            var counter = 0;

            foreach (var link in responseLinks)
            {
                // Return media collection
                var mediaResponse = await Service.GetData<List<string>>(link);
                if (mediaResponse.Data != null)
                {
                    var result = new List<string>();
                    result.Add($"Resource no: {counter}");
                    // Add media link to return collection
                    result.Add(link);
                    // Return number of files in collection
                    var nrOffiles = mediaResponse.Data.Count();
                    // Select video links in media collection
                    var videoLinksCollection = mediaResponse.Data.Select(i => i).Where(i => i.EndsWith("mp4")).ToList();
                    // Return number of videos in collection
                    var nrOfVideos = videoLinksCollection.Count();
                    // Return output information
                    result.Add($"Media library contains {nrOfVideos} video files out of total {nrOffiles} media files.");
                    // Add description
                    result.Add("Links to videos:");
                    // Add video links to return collection
                    result.AddRange(videoLinksCollection);
                    // Add separator for output print
                    result.Add("---------------------------------");
                    PrintResult(result);
                }
                else
                {
                    Console.WriteLine($"Resource no: {counter}");
                    Console.WriteLine($"Wrong link: {link}");
                }

                counter++;
            }
        }

        private void PrintResult(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }


    }
}
