using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Extensions.InaccessibleTypes
{
    /* Not recommed implementation */

    public class InaccessibleTypes
    {
        public string GetString()
        {
            return "accessible";
        }

        private class Inaccessible
        {
            private string GetString()
            {
                return "inaccessible";
            }
        }
    }
}
