namespace eAcademy.Core.Domain.Helpers;

public static class FluentValidationHelper
{
    public static FluentValidation.IRuleBuilderInitial<T, TProperty> WithName<T, TProperty>(
        this FluentValidation.IRuleBuilderInitial<T, TProperty> rule, System.Func<T, string, string> nameProvider)
    {
        return FluentValidation.DefaultValidatorOptions.Configure(rule,
            config => { config.SetDisplayName(ctx => nameProvider(ctx.InstanceToValidate, config.PropertyName)); });
    }

    public static FluentValidation.IRuleBuilderInitialCollection<T, TProperty> WithVariableName<T, TProperty>(
        this FluentValidation.IRuleBuilderInitialCollection<T, TProperty> rule, System.Func<string> nameProvider)
    {
        return FluentValidation.DefaultValidatorOptions.Configure(rule,
            config => { config.SetDisplayName(ctx => !ctx.IsChildContext ? nameProvider() : null); });
    }
}