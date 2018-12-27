using System.Collections.Generic;
using Newtonsoft.Json;

namespace GapSharp.Tools
{
    public class InlineButtonBuilder
    {
        

        private readonly List<List<Dictionary<string, string>>> _keys;

        public InlineButtonBuilder()
        {
            _keys = new List<List<Dictionary<string, string>>>();
        }

        public InlineButtonBuilder AddRow()
        {
            _keys.Add(new List<Dictionary<string, string>>());
            return this;
        }

        public InlineButtonBuilder AddCbData(string name, string cbData)
        {
            _keys[_keys.Count - 1].Add(new Dictionary<string, string>()
            {
                {"text", name}, {"cb_data", cbData}
            });
            return this;
        }

        public InlineButtonBuilder AddUrl(string name, string url)
        {
            _keys[_keys.Count - 1].Add(new Dictionary<string, string>()
            {
                {"text", name}, {"url", url}
            });
            return this;
        }

        public InlineButtonBuilder AddAmount(string name, int amount, string currency, string ref_id, string desc)
        {
            _keys[_keys.Count - 1].Add(new Dictionary<string, string>()
            {
                {"text", name},
                {"amount", amount.ToString()},
                {"currency", currency},
                {"ref_id", ref_id},
                {"desc", desc}
            });
            return this;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(_keys);
        }
    }
}