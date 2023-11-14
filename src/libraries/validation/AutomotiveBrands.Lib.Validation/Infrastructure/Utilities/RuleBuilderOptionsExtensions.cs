namespace AutomotiveBrands.Lib.Validation.Infrastructure.Utilities
{
    public static class RuleBuilderOptionsExtensions
    {
        public static IRuleBuilderOptions<TModel, string> NotNullAndNotWhiteSpace<TModel>(this IRuleBuilder<TModel, string> ruleBuilder, string message) where TModel : class, new()
        {
            return ruleBuilder.Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(message);
        }
    }
}
