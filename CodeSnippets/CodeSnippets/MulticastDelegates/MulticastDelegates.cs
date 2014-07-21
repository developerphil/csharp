using System.Diagnostics;
using NUnit.Framework;

namespace CodeSnippets.MulticastDelegates
{
    [TestFixture]
    public class MulticastDelegates
    {
        private delegate string ProgressChangeNotifier(int precent);

        string WriteToDebug(int precent)
        {
            Debug.WriteLine(precent);

            return "Ignored if not the last";
        }

        string WriteToDebugWithMessage(int precent)
        {
            Debug.WriteLine("Progress now at:" + precent);

            return "Last result wins";
        }

        [Test]
        public void MulitcastDelegatesTest()
        {
            var progressDelegate = new ProgressChangeNotifier(WriteToDebug);

            progressDelegate += WriteToDebugWithMessage;

            var result = progressDelegate(50);

            Debug.WriteLine(result);
        }

    }
}
