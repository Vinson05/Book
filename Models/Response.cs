using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class ResultSet
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "result")]
        public Object Result { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
