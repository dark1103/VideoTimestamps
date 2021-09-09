using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoTimestamps
{
    public class Config
    {
        [JsonProperty("Directory")]
        public string Directory { get; set; }

        [JsonProperty("RecordsDirectory")]
        public string RecordsDirectory { get; set; }

        [JsonProperty("Folders")]
        public Dictionary<string, Folders> Folders { get; set; }

        [JsonProperty("RecordPickupHours")]
        public double RecordPickupHours { get; set; }

        [JsonProperty("RecordsTimeFormat")]
        public string RecordsTimeFormat { get; set; }
        [JsonProperty("RecordsRegex")]
        public string RecordsRegex { get; set; }
    }

    public class Folders
    {
        [JsonProperty("Subfolders")]
        public List<string> Subfolders { get; set; }
    }
}
