using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GapSharp.DtoModel
{
    /// <summary>
    /// برای ارسال یا دریافت اطلاعات تماس
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// شماره تلفن
        /// </summary>
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// نام فرد
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
