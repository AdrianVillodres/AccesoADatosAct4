using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace cat.itb.M6UF3EA2_sol.model
{
    [Serializable]
    public class Country

    {
        //ATTRIBUTES
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string _id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("topLevelDomain")]
        public List<String> TopLevelDomain { get; set; }

        [JsonProperty("alpha2Code")]
        public String Alpha2Code { get; set; }

        [JsonProperty("alpha3Code")]
        public String Alpha3Code { get; set; }

        [JsonProperty("callingCodes")]
        public List<String> CallingCodes { get; set; }

        [JsonProperty("capital")]
        public String Capital { get; set; }

        [JsonProperty("altSpellings")]
        public List<String> AltSpellings { get; set; }

        [JsonProperty("region")]
        public String Region { get; set; }

        [JsonProperty("subregion")]
        public String Subregion { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("latlng")]
        public List<Double> Latlng { get; set; }

        [JsonProperty("demonym")]
        public String Demonym { get; set; }

        [JsonProperty("area")]
        public Double? Area { get; set; }

        [JsonProperty("gini")]
        public Double? Gini { get; set; }

        [JsonProperty("timezones")]
        public List<String> Timezones { get; set; }

        [JsonProperty("borders")]
        public List<String> Borders { get; set; }

        [JsonProperty("nativeName")]
        public String NativeName { get; set; }

        [JsonProperty("numericCode")]
        public String NumericCode { get; set; }

        [JsonProperty("currencies")]
        public List<Currency> Currencies { get; set; }

        [JsonProperty("languages")]
        public List<Language> Languages { get; set; }

        [JsonProperty("translations")]
        public Translation Translations { get; set; }

        [JsonProperty("flag")]
        public String Flag { get; set; }

        [JsonProperty("regionalBlocs")]
        public List<RegionalBloc> RegionalBlocs { get; set; }

        [JsonProperty("cioc")]
        public String Cioc { get; set; }

    }
}
