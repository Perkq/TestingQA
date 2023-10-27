using lab7;

namespace CalculatorTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Sum_Test_EqualTo_ExpectedNumber()
        {
            double expected = 10.3;

            double result = Calculator.Add(5.2, 5.1);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Sub_Test_EqualTo_ExpectedNumber()
        {
            double expected = 30.8;
            double result = Calculator.Sub(50.5, 19.7);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Mul_Test_EqualTo_ExpectedNumber()
        {
            double expected = 3.7 * 8.3;
            double result = Calculator.Mul(3.7, 8.3);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Div_Test_EqualTo_ExpectedNumber()
        {
            double expected = 123.5 / 3.8;
            double result = Calculator.Div(123.5, 3.8);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}