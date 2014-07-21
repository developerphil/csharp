using System.Linq;
using NUnit.Framework;

namespace CodeSnippets.Linq
{
    [TestFixture]
    public class Aggregate
    {
        [Test]
        public void CustomAggregateFunctionTest()
        {
            var nums = new[] {1, 2, 3, 4};

            var resultWithSeed = nums.Aggregate(2, CustomAccumulation);

            Assert.That(resultWithSeed, Is.EqualTo(8));

            var resultWithSeedZero = nums.Aggregate(0, CustomAccumulation);

            Assert.That(resultWithSeedZero, Is.EqualTo(6));

            var resultWithNoSeed = nums.Aggregate(CustomAccumulation);

            Assert.That(resultWithNoSeed, Is.EqualTo(7));

            var resultWithLambdaExpression = nums.Aggregate(10, (runningTotal, num) => runningTotal + num);

            Assert.That(resultWithLambdaExpression, Is.EqualTo(20));
        }

        private int CustomAccumulation(int runningTotal, int num)
        {
            if (num%2 == 0)
            {
                return runningTotal + num;

            }

            return runningTotal;
        }

    }
}
