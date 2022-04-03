namespace eAcademy.Core.Domain.UnitTests.Fakes;

#region

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

#endregion

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class SimpleClass
{
    public SimpleClass()
    {
        Test = CoreConstants.GetNullString();
    }

    public string Test { get; set; }
}