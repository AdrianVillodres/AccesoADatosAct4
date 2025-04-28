using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace cat.itb.M6UF3EA2_sol.model
{
    [Serializable]
    public class Product
    {
        //ATTRIBUTES
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string _id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("stock")]
        public int Stock { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }
    }
}