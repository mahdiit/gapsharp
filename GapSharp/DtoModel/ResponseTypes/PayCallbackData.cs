using Newtonsoft.Json;

namespace GapSharp.DtoModel.ResponseTypes
{
    public class PayCallbackResponse
    {
        [JsonProperty("ref_id")]
        public string RefId { get; set; }

        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }
    }
}