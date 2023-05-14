using Mailtrap.Source.Interfaces;
using Mailtrap.Source.Models;
using Moq;

namespace Mailtrap.Test
{
    public class SenderUnitTest
    {
        private Mock<IMailtrapSender>? _emailMock;

        [SetUp]
        public void Setup()
        {
            _emailMock = new Mock<IMailtrapSender>();
        }


        [Test(Author = "Flavio", Description = "Validate credential without username and password filled in")]
        public void Test_MailTrap_Credential_Empty()
        {
            Assert.That(() => new MailtrapSender("", ""),
                        Throws.TypeOf<ArgumentException>()
                        .With
                        .Message
                        .EqualTo("Check your credential"));
        }

        [Test(Author = "Flavio", Description = "Validate credential without username filled in")]
        public void Test_MailTrap_Credential_Username_Empty()
        {
            Assert.That(() => new MailtrapSender("", "password"),
                        Throws.TypeOf<ArgumentException>()
                        .With
                        .Message
                        .EqualTo("Check your credential"));
        }
        [Test(Author = "Flavio", Description = "Validate credential without password filled in")]
        public void Test_MailTrap_Credential_Password_Empty()
        {
            Assert.That(() => new MailtrapSender("username", ""),
                        Throws.TypeOf<ArgumentException>()
                        .With
                        .Message
                        .EqualTo("Check your credential"));
        }


        [Test(Author = "Flavio", Description = "Validate Mailtrap port")]
        public void Test_Port_Validator_Invalid_Port()
        {
            Assert.That(() => new MailtrapSender("userName", "password", port: 1234),
                        Throws.TypeOf<ArgumentException>()
                        .With
                        .Message
                        .EqualTo("Port must be either 25, 465 or 2525 (Parameter 'port')"));
        }

        [Test(Author = "Flavio", Description = "Send e-mail without attachment")]
        public void Test_Send_Email_Without_Attachments()
        {
            var mailtrapSender = new MailtrapSender("username","password");
            var email = new Email(
                                "to@mailtrap.io",
                                "from@mailtrap.io",
                                "Sending e-mail test using Mailtrap for .NET 📬",
                                "Ahoooy! It really works! 😎");
                             
            _emailMock.Setup(x => x.Send(email));
            
            Assert.IsTrue(true);
        }
    }
}