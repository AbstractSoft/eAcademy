namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CustomValueObject
    : eAcademy.Core.Domain.ValueObjects.ValueObject
{
    public CustomValueObject()
    {
        Thing = default;
        ThingsEnumerable = System.Linq.Enumerable.Empty<int>();
    }

    public int Thing { get; set; }
    public System.Collections.Generic.IEnumerable<int> ThingsEnumerable { get; set; }

    protected override System.Collections.Generic.IEnumerable<object> GetAtomicValues()
    {
        yield return Thing;
        yield return ThingsEnumerable;
    }

    public override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.CustomerValueObjectValidator();
    }
}