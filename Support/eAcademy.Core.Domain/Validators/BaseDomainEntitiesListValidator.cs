namespace eAcademy.Core.Domain.Validators;

public abstract class BaseDomainEntitiesListValidator<TList, TListItem> : FluentValidation.AbstractValidator<TList>
    where TList : eAcademy.Core.Domain.Entities.DomainEntitiesList<TListItem>
    where TListItem : eAcademy.Core.Domain.Entities.DomainEntity
{
    public new FluentValidation.IRuleBuilderInitialCollection<TList, TProperty> RuleForEach<TProperty>(
        System.Linq.Expressions.Expression<System.Func<TList, System.Collections.Generic.IEnumerable<TProperty>>>
            expression)
    {
        return eAcademy.Core.Domain.Helpers.FluentValidationHelper.WithVariableName(base.RuleForEach(expression),
            () => typeof(TList).Name);
    }
}