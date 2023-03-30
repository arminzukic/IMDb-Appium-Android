using System.Collections.Generic;
using Newtonsoft.Json;

namespace IMDb_Appium_Android.Models;

public class FindByTitleResponse
    {
        [JsonProperty("@meta")]
        public Meta meta { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }
        public string query { get; set; }
        public List<Result> results { get; set; }
        public List<string> types { get; set; }
    }