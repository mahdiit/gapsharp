using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    /// <summary>
    /// ارسال کار در سرور
    /// </summary>
    public class SendActionInput: InputTypeBase
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string ChatId { get; set; }

        /// <summary>
        /// نوع پیام SendActionType.Typing
        /// </summary>
        public string ActionType { get; set; }
    }
}
