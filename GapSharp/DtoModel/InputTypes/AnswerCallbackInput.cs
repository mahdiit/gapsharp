using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    /// <summary>
    /// پاسخ کال بک
    /// </summary>
    public class AnswerCallbackInput: InputTypeBase
    {
        /// <summary>
        /// اطلاعات کاربر
        /// </summary>
        public string ChatId { get; set; }

        /// <summary>
        /// شماره پاسخ
        /// </summary>
        public int CallbackId { get; set; }

        /// <summary>
        /// متن پاسخ
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// نمایش پیام
        /// </summary>
        public bool ShowAlert { get; set; }
    }
}
