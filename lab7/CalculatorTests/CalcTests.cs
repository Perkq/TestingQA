using lab7;

namespace CalculatorTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Test1()
        {
            double x = 10.3;

            double res = Calculator.Add(5.2, 5.1);
            Assert.That(x, Is.EqualTo(res));
        }
    }
}