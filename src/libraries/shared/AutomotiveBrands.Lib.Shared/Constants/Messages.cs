namespace AutomotiveBrands.Lib.Shared.Constants
{
    internal record struct ExceptionMessage
    {
        internal const string EnumValueRequired = "Numaralandırıcı (enum) değeri boş olamaz.";
        internal const string ObjectValueRequired = "Object değeri boş olamaz";
        internal const string NoMatchingBrandCode = "No matching brand code found.";
    }
}
