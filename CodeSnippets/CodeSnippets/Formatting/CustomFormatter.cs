using System;
using NUnit.Framework;

namespace CodeSnippets.Formatting
{
    //http://bit.ly/pscsformat

    [TestFixture]
    public class CustomFormatter
    {
        [Test]
        public void CustomeFormatterTest()
        {
            const string naughtyVersion = "censor words in a string";

            var cleanVersion = string.Format(new CensorWordFormatProvider(), "Clean version: {0:xxx}", naughtyVersion);

            Assert.That(cleanVersion, Is.EqualTo("Clean version: censor wxxxds in a string"));
        }

    }

    public class CensorWordFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof (ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return CensorWords(arg.ToString(), format);
        }

        private string CensorWords(string s, string format)
        {
            return s.Replace("words", string.Format("w{0}ds", format));
        }
    }


}
