using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.Infrastructure
{
    public interface IUserSession
    {
        int UserId { get; set; }
        string ChatId { get; set; }
        object Get(string key);
        void Set(string key, object item);
    }
}
