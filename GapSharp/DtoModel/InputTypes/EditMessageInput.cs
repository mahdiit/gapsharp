using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    /// <summary>
    /// ویرایش پیام
    /// </summary>
    public class EditMessageInput: InputTypeBase
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string ChatId { get; set; }

        /// <summary>
        /// شماره پیام
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// پیام
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// کیبورد این لاین
        /// </summary>
        public string InlineKeyboard { get; set; }
    }
}
