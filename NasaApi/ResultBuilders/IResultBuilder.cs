using System.Collections.Generic;
using System.Threading.Tasks;

namespace NasaApi.ResultBuilders
{
    public interface IResultBuilder
    {
        Task AnalyzeImages(string url);

        Task AnalyzeVideoLibrary(string url);
    }
}
