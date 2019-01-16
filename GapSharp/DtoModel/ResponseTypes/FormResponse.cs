using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace GapSharp.DtoModel.ResponseTypes
{
    /// <summary>
    /// دریافت پاسخ از سرور
    /// </summary>
    public class FormResponse
    {
        /// <summary>
        /// اطلاعات پردازش شده سرور
        /// </summary>
        [JsonIgnore]
        public NameValueCollection FormValue { get; private set; }

        private string _data;

        /// <summary>
        /// اطلاعات خام سرور
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public string Data
        {
            get { return _data; }
            set
            {
                _data = value;
                FormValue = HttpUtility.ParseQueryString(value);
            }
        }

        /// <summary>
        /// شماره پیام ارسال شده
        /// </summary>
        [JsonProperty("message_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MessageId { get; set; }

        /// <summary>
        /// شماره کال بک ارسال شده
        /// </summary>
        [JsonProperty("callback_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }
    }
}
