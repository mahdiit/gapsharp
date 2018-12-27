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
    public class FormResponse
    {
        [JsonIgnore]
        public NameValueCollection FormValue { get; private set; }

        private string _data;

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

        [JsonProperty("message_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MessageId { get; set; }

        [JsonProperty("callback_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }
    }
}
