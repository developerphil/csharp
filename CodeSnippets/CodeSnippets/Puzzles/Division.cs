using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeSnippets.Puzzles
{
    [TestFixture]
    public class Division
    {
        [Test]
        public void DivisionTest()
        {
            //Truncate markupPercent/niceFactor to zero

            int maxDiscountPercent = 30;
            int markupPercent = 20;
            int niceFactor = 30;

            double discount = maxDiscountPercent*(markupPercent/niceFactor);

            Assert.IsTrue(0 == discount);
        }

        [Test]
        [ExpectedException (typeof(DivideByZeroException))]
        public void DivisionTest2()
        {
            const int x = 9;
            const int y = 10;
            const int z = 100;

            decimal interim = x/y;

            decimal result = z/interim;
        }

    }
}
