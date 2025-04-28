using System;
using Newtonsoft.Json;

namespace cat.itb.M6UF3EA2_sol.model
{
    [Serializable]
    public class Id
    {
        //ATTRIBUTES

        [JsonProperty("$oid")] 
        public string Oid { get; set; }
    }
}