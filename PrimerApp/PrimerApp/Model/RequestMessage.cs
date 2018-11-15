using System;
using Newtonsoft.Json;

namespace analisis.Model
{
    public class RequestMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string MessageText { get; set; }

        [JsonProperty("language")]
        public string Language => "es";
    }
}
