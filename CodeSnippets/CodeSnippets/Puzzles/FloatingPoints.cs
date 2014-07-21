using System;
using NUnit.Framework;

namespace CodeSnippets.Puzzles
{

    [TestFixture]
    public class FloatingPoints
    {
        // .net is base 2 not base 10 (different holding and rounding), Decimal base 10 but slower performance
        // Precision different between x86 and x64

        [Test]
        public void FloatingPointTest()
        {
            //Dont't change data types bad practice
            Single one = 1;
            Single three = 3;
            Single x = one / three;
            Double result = 3 * x;

            Assert.IsFalse(result == 1.0);
            Assert.IsTrue(Math.Round(result, 7) == 1);

        }

        [Test]
        public void FloatingPointTest2()
        {
            Double x = .1;
            Double result = 10 * x;
            Double result2 = x + x + x + x + x + x + x + x + x + x;

            Assert.IsFalse(result == result2);
        }

        [Test]
        public void DivideByZeroNoException()
        {
            /* Same for Single but decimal and int throw exception*/

            const double three = 3;
            const double zero = 0;

            Double result = three/zero;

            Assert.AreEqual(Double.PositiveInfinity, result);

        }
    }
}
