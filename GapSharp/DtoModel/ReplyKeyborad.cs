using System.Collections.Generic;
using Newtonsoft.Json;

namespace GapSharp.DtoModel
{
    public class ReplyKeyborad
    {
        [JsonProperty("keyboard", NullValueHandling = NullValueHandling.Ignore)]
        public List<List<Dictionary<string, string>>> Keyboard { get; set; }
    }
}