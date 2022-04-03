namespace eAcademy.Core.Domain.UnitTests.Fakes;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class SimpleClassWithCtor2Params
{
    public SimpleClassWithCtor2Params(string param1, SimpleClass param2)
    {
        Test1 = param1;
        Test2 = param2;
    }

    public string Test1 { get; }

    public SimpleClass Test2 { get; }
}