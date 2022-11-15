namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_FileLogger()
        {
            // arrange
            var logger = new decorator_bonus.LoggerFileOutputDecorator();
            var loggedString = "hello file loger";

            // act
            logger.Log(loggedString);

            // assert
            // read file
            // check that the end of the file matches the logged string


            Assert.Pass();
        }
    }
}