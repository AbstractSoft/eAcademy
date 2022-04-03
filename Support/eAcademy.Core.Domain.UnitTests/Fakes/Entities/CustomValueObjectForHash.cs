namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CustomValueObjectForHash
    : eAcademy.Core.Domain.ValueObjects.ValueObject
{
    public CustomValueObjectForHash(string field1, string field2)
    {
        Field1 = field1;
        Field2 = field2;
    }

    public string Field1 { get; }
    public string Field2 { get; }

    protected override System.Collections.Generic.IEnumerable<object> GetAtomicValues()
    {
        yield return Field1;
        yield return Field2;
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return null!;
    }
}