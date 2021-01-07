using System.Collections.Generic;

namespace NasaApi.Models
{
    public class Collection
    {
        public Metadata metadata { get; set; }
        public string version { get; set; }
        public string href { get; set; }
        public List<Item> items { get; set; }
        public List<Link2> links { get; set; }
    }
}
