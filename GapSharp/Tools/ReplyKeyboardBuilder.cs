using System.Collections.Generic;
using GapSharp.DtoModel;
using Newtonsoft.Json;

namespace GapSharp.Tools
{
    public class ReplyKeyboardBuilder
    {
        private readonly ReplyKeyborad _keysList;

        public ReplyKeyboardBuilder()
        {
            _keysList = new ReplyKeyborad()
            {
                Keyboard = new List<List<Dictionary<string, string>>>()
            };
        }

        public ReplyKeyboardBuilder AddRow()
        {
            _keysList.Keyboard.Add(new List<Dictionary<string, string>>());
            return this;
        }

        public ReplyKeyboardBuilder AddRequestLocation(string name)
        {
            return AddKey(name, "$location");
        }

        public ReplyKeyboardBuilder AddRequestContact(string name)
        {
            return AddKey(name, "$contact");
        }

        public ReplyKeyboardBuilder AddKey(string name, string value)
        {
            _keysList.Keyboard[_keysList.Keyboard.Count - 1].Add(new Dictionary<string, string>()
            {
                {value, name}
            });
            return this;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(_keysList);
        }
    }
}