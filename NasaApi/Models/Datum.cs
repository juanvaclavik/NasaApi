using System;
using System.Collections.Generic;

namespace NasaApi.Models
{
    public class Datum
    {
        public string nasa_id { get; set; }
        public DateTime date_created { get; set; }
        public string media_type { get; set; }
        public string secondary_creator { get; set; }
        public string description_508 { get; set; }
        public string center { get; set; }
        public string title { get; set; }
        public List<string> keywords { get; set; }
        public string description { get; set; }
    }
}
