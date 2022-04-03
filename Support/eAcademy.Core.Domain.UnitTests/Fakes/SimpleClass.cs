namespace eAcademy.Core.Domain.UnitTests.Fakes;

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class SimpleClass
{
    public SimpleClass()
    {
        Test = CoreConstants.GetNullString();
    }

    public string Test { get; set; }
}