using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    public class SendInvoiceInput: InputTypeBase
    {
        public string ChatId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
