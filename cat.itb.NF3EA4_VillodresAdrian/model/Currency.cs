using Newtonsoft.Json;
using System;

namespace cat.itb.M6UF3EA2_sol.model
{
    public class Currency

    {
        //ATTRIBUTES

        [JsonProperty("code")]
        public String Code { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("symbol")]
        public String Symbol { get; set; }
    }
}
