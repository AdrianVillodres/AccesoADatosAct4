using Newtonsoft.Json;

namespace cat.itb.M6UF3EA2_sol.model
{
    [Serializable]
    public class PublishedDate
    {
        //ATTRIBUTES

        [JsonProperty("$date")]
        public String _Date { get; set; }

        //ToSTRING
        public override string ToString()
        {
            return
                "PublishedDate{" +
                "$_Date = '" + _Date + '\'' +
                "}";
        }
    }
}