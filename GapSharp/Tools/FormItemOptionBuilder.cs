using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.Tools
{
    public class FormItemOptionBuilder
    {
        public List<Dictionary<string,string>> Options { get; set; }

        public FormItemOptionBuilder AddOption(string name, string value)
        {
            if(Options == null)
                Options =  new List<Dictionary<string, string>>();

            Options.Add(new Dictionary<string, string>()
            {
                {value, name}
            });

            return this;
        }
    }
}
