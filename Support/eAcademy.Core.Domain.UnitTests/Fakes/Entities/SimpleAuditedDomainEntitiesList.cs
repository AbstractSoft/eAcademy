namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class SimpleAuditedDomainEntitiesList
    : eAcademy.Core.Domain.Entities.DomainEntitiesList<SimpleAuditedDomainEntity>
{
    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.SimpleAuditedDomainEntitiesListValidator();
    }
}