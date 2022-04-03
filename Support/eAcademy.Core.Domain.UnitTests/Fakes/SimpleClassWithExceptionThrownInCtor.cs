namespace eAcademy.Core.Domain.UnitTests.Fakes;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class SimpleClassWithExceptionThrownInCtor
{
    public SimpleClassWithExceptionThrownInCtor()
    {
        Test = string.Empty;
        throw new System.InvalidOperationException("Ctor exception");
    }

    public string Test { get; set; }
}