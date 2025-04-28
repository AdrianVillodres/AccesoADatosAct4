using Newtonsoft.Json;

namespace cat.itb.M6UF3EA2_sol.model
{
    [Serializable]
    public class LongDate
    {
        //ATTRIBUTES

        [JsonProperty("$date")]
        public long _Date { get; set; }
    }
}

