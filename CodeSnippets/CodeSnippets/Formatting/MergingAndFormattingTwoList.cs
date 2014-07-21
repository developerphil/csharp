using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace CodeSnippets.Formatting
{
    [TestFixture]
    public class MergingAndFormattingTwoList
    {
        [Test]
        public void MergingAndFormatting()
        {
            var names = new[] {"BOB", "TOM", "MIKE"};
            var ages = new[] {30, 32, 26};

            var namesAndAges = names.Zip(ages, (name, age) => name + ":" + age).ToList();

            foreach (var namesAndAge in namesAndAges)
            {
                Debug.WriteLine(namesAndAge);
            }

        }
    }
}
