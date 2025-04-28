using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace cat.itb.M6UF3EA2_sol.model
{
    [Serializable]
    public class Restaurant
    {
        //ATTRIBUTES
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string _id { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("borough")]
        public string Borough { get; set; }

        [JsonProperty("cuisine")]
        public string Cuisine { get; set; }

        [JsonProperty("grades")]
        public List<Grade> Grades { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("restaurant_id")]
        public string Restaurant_id { get; set; }


        //ToSTRING
        public override string ToString()
        {
            return "  Address: " + Address + "  Borough: " + Borough + "   Cuisine: " + Cuisine + "   Name: " + Name +
                   "   Grades: " + Grades + "   Id: " + Restaurant_id;
        }

    }
}