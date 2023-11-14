namespace AutomotiveBrands.Lib.MassTransit.Models
{
    public sealed record AttachmentFile
    {
        public string Name { get; init; }
        public byte[] Binary { get; init; }
        //public MimeType MimeType { get; init; }
    }
}
