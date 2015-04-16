using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipedriveNet
{
    internal class QueryString : Dictionary<string, string>
    {
        public override string ToString()
        {
            if (Count == 0)
                return "";
            return "?" + string.Join("&", this.Select(x => x.Key + "=" + Uri.EscapeDataString(x.Value)));
        }
    }
}
