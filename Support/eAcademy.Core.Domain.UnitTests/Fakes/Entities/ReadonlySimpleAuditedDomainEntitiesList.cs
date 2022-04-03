namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class ReadonlySimpleAuditedDomainEntitiesList
    : eAcademy.Core.Domain.Entities.ReadonlyDomainEntitiesList<SimpleAuditedDomainEntity>
{
    public ReadonlySimpleAuditedDomainEntitiesList(
        System.Collections.Generic.IEnumerable<SimpleAuditedDomainEntity> list)
        : base(list)
    {
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.ReadonlySimpleAuditedDomainEntitiesListValidator();
    }
}