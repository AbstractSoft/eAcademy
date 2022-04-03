namespace eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeValueObjects1List : eAcademy.Core.Domain.ValueObjects.ValueObjectsList<FakeValueObject1>
{
    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeValueObjects1ListValidator();
    }
}