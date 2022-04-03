namespace eAcademy.Core.Domain.Validators;

public abstract class BaseDomainEntityValidator<T> : FluentValidation.AbstractValidator<T>
    where T : eAcademy.Core.Domain.Entities.DomainEntity
{
    protected new FluentValidation.IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(
        System.Linq.Expressions.Expression<System.Func<T, TProperty>> expression)
    {
        return eAcademy.Core.Domain.Helpers.FluentValidationHelper.WithName(
            base.RuleFor(expression), static (instance, propertyName) =>
                $"{typeof(T).Name} [{instance?.Id}]::{propertyName}");
    }
}