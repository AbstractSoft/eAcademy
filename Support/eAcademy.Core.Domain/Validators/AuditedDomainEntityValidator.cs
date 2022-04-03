namespace eAcademy.Core.Domain.Validators;

public abstract class AuditedDomainEntityValidator<T> : BaseDomainEntityValidator<T>
    where T : eAcademy.Core.Domain.Entities.AuditedDomainEntity
{
    protected AuditedDomainEntityValidator()
    {
        FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(entity => entity.Created))
            .SetValidator(new AuditChangeValidator());

        FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(entity => entity.Updated))
            .SetValidator(new AuditChangeValidator());
    }
}