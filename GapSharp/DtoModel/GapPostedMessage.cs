using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GapSharp.DtoModel
{
    public class GapPostedMessage
    {
        public string ChatId { get; set; }
        public RecivedMessageType MessageType  { get; set; }
        public string Data { get; set; }
    }
}
