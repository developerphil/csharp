using NUnit.Framework;

namespace CodeSnippets.Indexers
{
    [TestFixture]
    public class IndexerExample
    {
        [Test]
        public void IndexerExampleTest()
        {
            var student = new Student();

            Assert.That(student[2], Is.EqualTo(99));

            student[2] = 11;

            Assert.That(student[2], Is.EqualTo(11));
        }
    }

    public class Student
    {
        private readonly int[] _examScores = {56, 22, 99, 25};

        public int this[int index]
        {
            get { return _examScores[index]; }
            set { _examScores[index] = value; }
        }
    }
}
