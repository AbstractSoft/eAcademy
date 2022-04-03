namespace eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeValueObject1 : eAcademy.Core.Domain.ValueObjects.ValueObject
{
    public FakeValueObject1(
        int intProperty,
        string stringProperty,
        System.DateTime dateTimeProperty,
        float floatProperty,
        System.Guid guidProperty,
        FakeValueObjects2List fakeValueObjects2ListProperty)
    {
        IntProperty = intProperty;
        StringProperty = stringProperty;
        DateTimeProperty = dateTimeProperty;
        FloatProperty = floatProperty;
        GuidProperty = guidProperty;
        FakeValueObjects2ListProperty = fakeValueObjects2ListProperty;
    }

    public int IntProperty { get; }
    public string StringProperty { get; }
    public System.DateTime DateTimeProperty { get; }
    public float FloatProperty { get; }
    public System.Guid GuidProperty { get; }
    public FakeValueObjects2List FakeValueObjects2ListProperty { get; }

    protected override System.Collections.Generic.IEnumerable<object> GetAtomicValues()
    {
        yield return IntProperty;
        yield return StringProperty;
        yield return DateTimeProperty;
        yield return FloatProperty;
        yield return GuidProperty;
        yield return FakeValueObjects2ListProperty;
    }

    public override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeValueObject1Validator();
    }
}