namespace AutomotiveBrands.Lib.MassTransit.MessageTypes.Commands.Emails
{
    public interface IEmailCommand
    {
        int PlatformType { get; set; }
        List<string> ToEmails { get; set; }
        List<string> CcEmails { get; set; }
        List<string> BccEmails { get; set; }
        int TemplateId { get; set; }
        string Subject { get; set; }
        Dictionary<string, dynamic> TemplateBodyParameter { get; set; }
        List<AttachmentFile> AttachmentFiles { get; set; }
    }

    public sealed record EmailCommand : IEmailCommand
    {
        public EmailCommand()
        {
        }

        public EmailCommand(int templateId)
        {
            TemplateId = templateId;
        }

        public int PlatformType { get; set; }
        public List<string> ToEmails { get; set; }
        public List<string> CcEmails { get; set; }
        public List<string> BccEmails { get; set; }
        public int TemplateId { get; set; }
        public string Subject { get; set; }
        public Dictionary<string, dynamic> TemplateBodyParameter { get; set; }
        public List<AttachmentFile> AttachmentFiles { get; set; }
    }
}