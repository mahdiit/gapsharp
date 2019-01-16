using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    /// <summary>
    /// ارسال پیام
    /// </summary>
    public class SendMessageInput: InputTypeBase
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string ChatId { get; set; } 

        /// <summary>
        /// نوع پیام
        /// </summary>
        public SendMessageType MessageType { get; set; }

        /// <summary>
        /// اطلاعات
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// کیبورد پاسخ
        /// </summary>
        public string ReplyKeyboard { get; set; }

        /// <summary>
        /// کیبورد متنی
        /// </summary>
        public string InlineKeyboard { get; set; }

        /// <summary>
        /// فرم
        /// </summary>
        public string Form { get; set; }
    }
}
