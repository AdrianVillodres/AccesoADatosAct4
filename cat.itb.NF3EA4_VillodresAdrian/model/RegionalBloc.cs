using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cat.itb.M6UF3EA2_sol.model
{
    [Serializable]
    public class RegionalBloc
    {
        //ATTRIBUTES

        [JsonProperty("acronym")]
        public String Acronym { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("otherAcronyms")]
        public List<String> OtherAcronyms { get; set; }

        [JsonProperty("otherNames")]
        public List<String> OtherNames { get; set; }
    }
}
