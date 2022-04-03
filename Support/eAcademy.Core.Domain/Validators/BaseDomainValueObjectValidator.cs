namespace eAcademy.Core.Domain.Validators;

public abstract class BaseDomainValueObjectValidator<T> : FluentValidation.AbstractValidator<T> where T
    : eAcademy.Core.Domain.ValueObjects.ValueObject
{
    protected new FluentValidation.IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(
        System.Linq.Expressions.Expression<System.Func<T, TProperty>> expression)
    {
        return eAcademy.Core.Domain.Helpers.FluentValidationHelper.WithName(base
            .RuleFor(expression), (a, propertyName) =>
            (string.IsNullOrEmpty(propertyName) ? null : $"{typeof(T).Name}::{propertyName}") ??
            throw new System.InvalidOperationException());
    }
}