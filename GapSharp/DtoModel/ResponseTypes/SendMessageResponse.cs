using Newtonsoft.Json;

namespace GapSharp.DtoModel.ResponseTypes
{
    public class SendMessageResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}