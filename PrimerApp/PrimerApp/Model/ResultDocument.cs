using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace analisis.Model
{
    public class ResultDocument
    {
        [JsonProperty("documents")]
        public IEnumerable<ResultMessage> ResultMessages { get; set; }
    }
}
