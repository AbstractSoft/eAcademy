namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeEntitiesForListValidationList
    : eAcademy.Core.Domain.Entities.DomainEntitiesList<FakeEntityForListValidation>
{
    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeEntitiesForListValidationListValidator();
    }
}