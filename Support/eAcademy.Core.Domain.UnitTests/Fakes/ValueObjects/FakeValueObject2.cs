namespace eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeValueObject2 : eAcademy.Core.Domain.ValueObjects.ValueObject
{
    public FakeValueObject2(int intProperty, string stringProperty, FakeValueObject3 fakeValueObject3Property)
    {
        IntProperty = intProperty;
        StringProperty = stringProperty;
        FakeValueObject3Property = fakeValueObject3Property;
    }

    public int IntProperty { get; }
    public string StringProperty { get; }
    public FakeValueObject3 FakeValueObject3Property { get; }

    protected override System.Collections.Generic.IEnumerable<object> GetAtomicValues()
    {
        yield return IntProperty;
        yield return StringProperty;
        yield return FakeValueObject3Property;
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeValueObject2Validator();
    }
}