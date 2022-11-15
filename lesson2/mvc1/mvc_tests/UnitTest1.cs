namespace mvc_tests
{
    public class UnitTest1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            List a;
            Assert.Pass();
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void Test2(int arg)
        {
            Assert.IsTrue(arg > 5);

            Assert.Throws<Exception>(() =>
            {
                throw new Exception("Errror");
            });

            Assert.Pass();
        }
    }
}