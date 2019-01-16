using Newtonsoft.Json;

namespace GapSharp.DtoModel.ResponseTypes
{
    /// <summary>
    /// پاسخ صورت حساب
    /// </summary>
    public class InvoiceCallbackResponse
    {
        /// <summary>
        /// شماره صورت حساب ایجاد شده 
        /// </summary>
        [JsonProperty("invoiceId")]
        public string InvoiceId { get; set; }
    }
}