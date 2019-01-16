using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    /// <summary>
    /// ارسال صورت حساب
    /// </summary>
    public class SendInvoiceInput: InputTypeBase
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string ChatId { get; set; }

        /// <summary>
        /// مبلغ
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
    }
}
