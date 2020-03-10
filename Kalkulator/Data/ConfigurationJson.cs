using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Kalkulator.Data
{
    public class ConfigurationJson
    {
        [JsonProperty("max")]
        public int MAX { get;  set; }

        [JsonProperty("min")]
        public int MIN { get;  set; }
    }
}