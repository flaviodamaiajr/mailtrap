namespace Mailtrap.Test
{
    public class SenderUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test(Author = "Flávio", Description = "Validate credential without username and password filled in")]
        public void Test_MailTrap_Credential_Empty()
        {
            Assert.That(() => new MailtrapSender("", ""),
                        Throws.TypeOf<ArgumentException>()
                        .With
                        .Message
                        .EqualTo("Check your credential"));
        }

        [Test(Author = "Flávio", Description = "Validate credential without username filled in")]
        public void Test_MailTrap_Credential_Username_Empty()
        {
            Assert.That(() => new MailtrapSender("", "password"),
                        Throws.TypeOf<ArgumentException>()
                        .With
                        .Message
                        .EqualTo("Check your credential"));
        }
        [Test(Author = "Flávio", Description = "Validate credential without password filled in")]
        public void Test_MailTrap_Credential_Password_Empty()
        {
            Assert.That(() => new MailtrapSender("username", ""),
                        Throws.TypeOf<ArgumentException>()
                        .With
                        .Message
                        .EqualTo("Check your credential"));
        }


        [Test(Author = "Flávio", Description = "Validate Mailtrap port")]
        public void Test_Port_Validator_Invalid_Port()
        {
            Assert.That(() => new MailtrapSender("userName", "password", port: 1234),
                        Throws.TypeOf<ArgumentException>()
                        .With
                        .Message
                        .EqualTo("Port must be either 25, 465 or 2525 (Parameter 'port')"));
        }
    }
}