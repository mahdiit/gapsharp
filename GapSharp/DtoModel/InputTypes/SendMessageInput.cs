using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    public class SendMessageInput: InputTypeBase
    {
        public string ChatId { get; set; } 
        public SendMessageType MessageType { get; set; }
        public string Data { get; set; }
        public string ReplyKeyboard { get; set; }
        public string InlineKeyboard { get; set; }
        public string Form { get; set; }
    }
}
