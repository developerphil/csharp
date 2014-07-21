using NUnit.Framework;

namespace CodeSnippets.Formatting
{
    [TestFixture]
    public class ThreePartNumericFormatString
    {
        [Test]
        public void ThreePartNumericFormatStringTest()
        {
            const double aPositiveNumber = 99.99;
            const double aNegativeNumber = -23.55;
            const double aZeroNumber = 0;

            const string threePartFormat = "(pos)#.##;(neg)#.##;(sorry nothing at all)";

            Assert.That(aPositiveNumber.ToString(threePartFormat), Is.EqualTo("(pos)99.99"));
            Assert.That(aNegativeNumber.ToString(threePartFormat), Is.EqualTo("(neg)23.55"));
            Assert.That(aZeroNumber.ToString(threePartFormat), Is.EqualTo("(sorry nothing at all)"));
        }
    }
}
