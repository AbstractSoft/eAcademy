namespace eAcademy.Core.Domain.UnitTests.Fakes;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class SimpleClassWithCtor1Param
{
    public SimpleClassWithCtor1Param(string param1)
    {
        Test1 = param1;
    }

    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    private string Test1 { get; }
}