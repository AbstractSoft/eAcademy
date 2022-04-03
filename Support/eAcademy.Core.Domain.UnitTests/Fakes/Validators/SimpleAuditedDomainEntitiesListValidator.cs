namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using FluentValidation;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class SimpleAuditedDomainEntitiesListValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntitiesListValidator<eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntitiesList,
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity>
{
    public SimpleAuditedDomainEntitiesListValidator()
    {
        RuleFor(list => list)
            .NotEmpty();

        RuleForEach(list => list)
            .SetValidator(new SimpleAuditedDomainEntityValidator());
    }
}