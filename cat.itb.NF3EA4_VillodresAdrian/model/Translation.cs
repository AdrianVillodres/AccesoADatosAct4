using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF3EA2_sol.model
{
    public class Translation
    {
        //ATTRIBUTES

        [JsonProperty("de")]
        public String De { get; set; }

        [JsonProperty("es")]
        public String Es { get; set; }

        [JsonProperty("fr")]
        public String Fr { get; set; }

        [JsonProperty("ja")]
        public String Ja { get; set; }

        [JsonProperty("it")]
        public String It { get; set; }

        [JsonProperty("br")]
        public String Br { get; set; }

        [JsonProperty("pt")]
        public String Pt { get; set; }

        [JsonProperty("nl")]
        public String Nl { get; set; }

        [JsonProperty("hr")]
        public String Hr { get; set; }

        [JsonProperty("fa")]
        public String Fa { get; set; }
    }
}
