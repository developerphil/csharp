using System.Text;

namespace System
{
    /*Full exception trace*/

    public static class ExceptionExtension
    {
        public static string FullMessage(this Exception ex)
        {
            var builder = new StringBuilder();

            while (ex != null)
            {
                builder.AppendFormat("{0}{1}", ex.Message, Environment.NewLine);
                ex = ex.InnerException;
            }

            return builder.ToString();
        }
    }
}
