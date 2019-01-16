using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    /// <summary>
    /// آپلود
    /// </summary>
    public class UploadInput: InputTypeBase
    {
        /// <summary>
        /// نوع فایل FileType.Image
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// باینری اطلاعات فایل
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// برای jpg مثلا image/jpeg
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// کیبورد پاسخ
        /// </summary>
        public string ReplyKeyboard { get; set; }

        /// <summary>
        /// کیبورد متنی
        /// </summary>
        public string InlineKeyboard { get; set; }
    }
}
