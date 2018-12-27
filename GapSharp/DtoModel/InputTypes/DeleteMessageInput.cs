﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    public class DeleteMessageInput: InputTypeBase
    {
        public string ChatId { get; set; }
        public int MessageId { get; set; }
    }
}