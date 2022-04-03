namespace eAcademy.Core.Domain.Validators;

public abstract class BaseDomainValueObjectsListValidator<TList, TListItem>
    : FluentValidation.AbstractValidator<TList>
    where TList : eAcademy.Core.Domain.ValueObjects.ValueObjectsList<TListItem>
    where TListItem : eAcademy.Core.Domain.ValueObjects.ValueObject
{
    protected new FluentValidation.IRuleBuilderInitialCollection<TList, TProperty> RuleForEach<TProperty>(
        System.Linq.Expressions.Expression<System.Func<TList, System.Collections.Generic.IEnumerable<TProperty>>>
            expression)
    {
        return eAcademy.Core.Domain.Helpers.FluentValidationHelper.WithVariableName(base.RuleForEach(expression),
            () => typeof(TList).Name);
    }
}