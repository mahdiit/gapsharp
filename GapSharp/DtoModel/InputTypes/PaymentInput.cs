using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    /// <summary>
    /// پرداخت
    /// </summary>
    public class PaymentInput : InputTypeBase
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string ChatId { get; set; }

        /// <summary>
        /// شماره رفرنس
        /// </summary>
        public string RefId { get; set; }
    }
}
