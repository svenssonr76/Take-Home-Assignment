using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Take_Home_Assignment.Models
{
    public class History
    {
        [JsonProperty("start_at")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_at")]
        public DateTime EndDate { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, Dictionary<string, decimal>> Rates { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }
    }
}

