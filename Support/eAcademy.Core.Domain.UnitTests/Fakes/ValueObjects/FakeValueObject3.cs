namespace eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeValueObject3 : eAcademy.Core.Domain.ValueObjects.ValueObject
{
    public FakeValueObject3(string stringProperty)
    {
        StringProperty = stringProperty;
    }

    public string StringProperty { get; }

    protected override System.Collections.Generic.IEnumerable<object> GetAtomicValues()
    {
        yield return StringProperty;
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeValueObject3Validator();
    }
}