namespace AutomotiveBrands.Lib.Security.Infrastructure.Contants
{
    internal sealed record ExceptionMessage
    {
        internal const string CaptchaVerificationFailed = "Google captcha doğrulaması sağlanamadı. Lütfen daha sonra tekrar deneyiniz.";
        internal const string RedisServiceRequired = "Öncelikle redis servisi eklemelisiniz.";
        internal const string InputRequired = "Şifrelenecek veri gereklidir.";
        internal const string PurposeRequired = "Şifreleme anahtarı gereklidir.";
        internal const string HashedValueRequired = "Şifrelenmiş değer boş olamaz.";
        internal const string TextToBeEncryptedRequired = "Şifrelenecek metin boş olamaz.";
        internal const string CipherTextRequired = "Şifreli metin boş olamaz.";
    }
}
