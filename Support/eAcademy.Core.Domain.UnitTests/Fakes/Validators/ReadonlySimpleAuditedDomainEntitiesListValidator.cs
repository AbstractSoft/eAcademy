namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class ReadonlySimpleAuditedDomainEntitiesListValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntitiesListValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.ReadonlySimpleAuditedDomainEntitiesList,
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity>
{
    public ReadonlySimpleAuditedDomainEntitiesListValidator()
    {
        RuleForEach(static list => list)
            .SetValidator(new SimpleAuditedDomainEntityValidator());
    }
}