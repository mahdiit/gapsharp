using System.Collections.Generic;
using GapSharp.DtoModel;
using Newtonsoft.Json;

namespace GapSharp.Tools
{
    public class FormBuilder
    {
        private readonly List<FormItem> _items;

        public FormBuilder()
        {
            _items = new List<FormItem>();
        }

        public FormBuilder Add(FormItem item)
        {
            _items.Add(item);
            return this;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(_items);
        }

        public FormBuilder Qrcode(string name, string label)
        {
            _items.Add(new FormItem()
            {
                Label = label,
                Name = name,
                TypeData = FormItemType.Inbuilt,
                Value = "qrcode"
            });
            return this;
        }

        public FormBuilder Barcode(string name, string label)
        {
            _items.Add(new FormItem()
            {
                Label = label,
                Name = name,
                TypeData = FormItemType.Inbuilt,
                Value = "barcode"
            });
            return this;
        }
    }
}