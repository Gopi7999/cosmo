using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDBSQLAPI.Models
{
    public class Cars
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "fuel")]
        public string Fuel { get; set; }
    }
}
