namespace eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeValueObjects2List : eAcademy.Core.Domain.ValueObjects.ValueObjectsList<FakeValueObject2>
{
    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeValueObjects2ListValidator();
    }
}