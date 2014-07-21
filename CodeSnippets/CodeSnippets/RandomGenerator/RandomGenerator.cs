using System;
using System.Diagnostics;
using NUnit.Framework;

namespace CodeSnippets.RandomGenerator
{
    [TestFixture]
    public class RandomGenerator
    {
        [Test]
        public void RandomGeneratorTest()
        {
            /*if you create two random objects at the same time they will have
              the same seed and create same sequence
             
             e.g. var random1 = new Random();
                  var random2 = new Random();
             
             */

            var r1 = new Random();

            for (int i = 0; i < 5; i++)
            {
                Debug.WriteLine(r1.Next());
            }
        }

        [Test]
        public void HighSecurity()
        {
            var r = System.Security.Cryptography.RandomNumberGenerator.Create();
            var randomBytes = new byte[4];

            r.GetBytes(randomBytes);

            int randomInt = BitConverter.ToInt32(randomBytes, 0);

            Debug.WriteLine(randomInt);
        }
    }
}


