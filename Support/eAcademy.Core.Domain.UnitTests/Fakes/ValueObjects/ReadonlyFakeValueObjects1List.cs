namespace eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class ReadonlyFakeValueObjects1List
    : eAcademy.Core.Domain.ValueObjects.ReadOnlyValueObjectsList<FakeValueObject1>
{
    public ReadonlyFakeValueObjects1List(System.Collections.Generic.IEnumerable<FakeValueObject1> list)
        : base(list)
    {
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.ReadonlyFakeValueObjectsListValidator();
    }
}