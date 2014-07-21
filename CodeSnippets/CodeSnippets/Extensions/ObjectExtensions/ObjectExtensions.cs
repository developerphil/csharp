using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CodeSnippets.Extensions.ObjectExtensions
{
    public static class ObjectExtensions
    {
        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string GetDescription(this object obj)
        {
            var description = obj.GetType().GetDescription();
            return JsonConvert.SerializeObject(description);
        }

    }
}
