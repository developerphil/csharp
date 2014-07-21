using System;
using System.Globalization;
using NUnit.Framework;

namespace CodeSnippets.Formatting
{
    [TestFixture]
    public class NumberStylesExample
    {
        [Test]
        public void NumberStylesTest()
        {
            var iMinus24 = int.Parse("(24)", NumberStyles.AllowParentheses);

            Assert.That(iMinus24, Is.EqualTo(-24));

            var dMinus24 = Double.Parse("(24)", NumberStyles.AllowParentheses);

            Assert.That(dMinus24, Is.EqualTo(-24.00));
        }

        [Test]
        public void NumberStylesCombinedTest()
        {
            var dThousands = Double.Parse("(24,000)", NumberStyles.AllowParentheses | NumberStyles.AllowThousands);

            Assert.That(dThousands, Is.EqualTo(-24000));

            var currency24000 = Double.Parse("£24", NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands);

            Assert.That(currency24000, Is.EqualTo(24));
        }

        [Test]
        public void CustomCurrencyTest()
        {
            const string strangeCurrency = "J$123.45";

            var nfi = new NumberFormatInfo()
            {
                CurrencySymbol = "J$"
            };

            Assert.That(Double.Parse(strangeCurrency, NumberStyles.Currency, nfi), Is.EqualTo(123.45));

        }

    }
}
