using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    public class UploadInput: InputTypeBase
    {
        public string FileType { get; set; }
        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string ReplyKeyboard { get; set; }
        public string InlineKeyboard { get; set; }
    }
}
