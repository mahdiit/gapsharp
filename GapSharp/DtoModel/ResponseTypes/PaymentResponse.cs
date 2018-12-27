using Newtonsoft.Json;

namespace GapSharp.DtoModel.ResponseTypes
{
    public class PaymentResponse
    {
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public long? Amount { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }
}