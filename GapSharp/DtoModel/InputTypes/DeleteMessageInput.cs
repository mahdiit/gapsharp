using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    /// <summary>
    /// پاک کردن پیام
    /// </summary>
    public class DeleteMessageInput: InputTypeBase
    {
        /// <summary>
        /// نام کاربر
        /// </summary>
        public string ChatId { get; set; }

        /// <summary>
        /// شماره پیام
        /// </summary>
        public int MessageId { get; set; }
    }
}
