using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommTests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockMailSender = new Mock<IMailSender>();

            // Configure SendMail to accept any 2 strings and return true
            _mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailIsSent()
        {
            bool result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);
            _mockMailSender.Verify(m => m.SendMail("cust123@abc.com", "Some Message"), Times.Once);
        }
    }
}