using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace analisis.Model
{
    public class RequestDocument
    {
        [JsonProperty("documents")]
        public IEnumerable<RequestMessage> Messages { get; set; }
    }
}
