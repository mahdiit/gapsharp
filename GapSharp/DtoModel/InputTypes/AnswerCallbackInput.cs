using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    public class AnswerCallbackInput: InputTypeBase
    {
        public string ChatId { get; set; }
        public int CallbackId { get; set; }
        public string Text { get; set; }
        public bool ShowAlert { get; set; }
    }
}
