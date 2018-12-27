using Newtonsoft.Json;

namespace GapSharp.DtoModel.ResponseTypes
{
    public class SendInvoiceResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}