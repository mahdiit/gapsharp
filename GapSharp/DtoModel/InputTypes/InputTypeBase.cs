using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.DtoModel.InputTypes
{
    public abstract class InputTypeBase
    {
        public string MethodName
        {
            get { return this.GetType().ToString(); }
        }
    }
}
