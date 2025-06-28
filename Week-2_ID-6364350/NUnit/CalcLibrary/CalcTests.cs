using NUnit.Framework;
using CalcLibrary;

namespace CalcTests
{
    [TestFixture] // Marks this class as a test container
    public class CalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Init()
        {
            calculator = new SimpleCalculator(); // Setup runs before each test
        }

        [TearDown]
        public void Cleanup()
        {
           // calculator.AllClear(); // Cleanup runs after each test
        }

        [Test]
        [TestCase(2, 3, 5)]
        [TestCase(-1, -1, -2)]
        [TestCase(0, 0, 0)]
        [TestCase(1.5, 2.5, 4.0)]
        public void Addition_WithVariousInputs_ReturnsCorrectResult(double a, double b, double expected)
        {
            double result = calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [Ignore("This is a sample ignored test.")]
        public void Ignored_Test_Sample()
        {
            // This will not be executed
            Assert.Fail("This test should have been ignored.");
        }
    }
}