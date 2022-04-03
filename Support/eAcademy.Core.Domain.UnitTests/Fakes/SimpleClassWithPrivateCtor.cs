namespace eAcademy.Core.Domain.UnitTests.Fakes;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class SimpleClassWithPrivateCtor
{
    private SimpleClassWithPrivateCtor()
    {
        Test = string.Empty;
    }

    public string Test { get; set; }
}