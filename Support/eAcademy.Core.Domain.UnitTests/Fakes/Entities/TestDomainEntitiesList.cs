namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class TestDomainEntitiesList
    : eAcademy.Core.Domain.Entities.DomainEntitiesList<TestDomainEntity>
{
    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.TestDomainEntitiesListValidator();
    }
}