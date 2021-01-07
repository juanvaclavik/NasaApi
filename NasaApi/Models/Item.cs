using System.Collections.Generic;

namespace NasaApi.Models
{
    public class Item
    {
        public List<Datum> data { get; set; }
        public string href { get; set; }
        public List<Link> links { get; set; }
    }
}
