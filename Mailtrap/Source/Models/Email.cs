namespace Mailtrap.Source.Models
{
    public class Email
    {
        public string To { get; }
        public string From { get; }
        public string Subject { get; }
        public string Body { get; }
        public bool IsBodyHtml { get; }
        public string[]? AttachmentPaths { get; set; }

        public Email(string to, string from, string subject, string body, bool isBodyHtml = false)
        {
            To = to;
            From = from;
            Subject = subject;
            Body = body;
            IsBodyHtml = isBodyHtml;
        }

        public Email(string to, string from, string subject, string body, bool isBodyHtml, string[] attachmentPaths) 
            : this(to, from, subject, body, isBodyHtml)
        {
            AttachmentPaths = attachmentPaths;
        }
    }
}