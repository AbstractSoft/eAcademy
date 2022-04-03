namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeEntity3List
    : eAcademy.Core.Domain.Entities.DomainEntitiesList<FakeEntity3>
{
    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeEntity3ListValidator();
    }
}