using lab7;

namespace CalculatorTests
{
    [TestFixture(10.3, 12.5)]
    [TestFixture(43.143, 6.2)]
    [TestFixture(125.65, 67.4)]
    public class Tests
    {

        private readonly double _eq1;
        private readonly double _eq2;

        public Tests(double eq1, double eq2)
        {
            _eq1 = eq1;
            _eq2 = eq2;
        }

        [Test, Timeout(2000)]
        public void Sum_Test_EqualTo_ExpectedNumber()
        {
            double expected = _eq1 + _eq2;

            double result = Calculator.Add(_eq1, _eq2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test, Timeout(2000)]
        public void Sub_Test_EqualTo_ExpectedNumber()
        {
            double expected = _eq1 - _eq2;
            double result = Calculator.Sub(_eq1, _eq2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test, Timeout(2000)]
        public void Mul_Test_EqualTo_ExpectedNumber()
        {
            double expected = _eq1 * _eq2;
            double result = Calculator.Mul(_eq1, _eq2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test, Timeout(2000)]
        public void Div_Test_EqualTo_ExpectedNumber()
        {
            double expected = _eq1 / _eq2;
            double result = Calculator.Div(_eq1, _eq2);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}