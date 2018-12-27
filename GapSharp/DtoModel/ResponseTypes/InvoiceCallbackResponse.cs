using Newtonsoft.Json;

namespace GapSharp.DtoModel.ResponseTypes
{
    public class InvoiceCallbackResponse
    {
        [JsonProperty("invoiceId")]
        public string InvoiceId { get; set; }
    }
}