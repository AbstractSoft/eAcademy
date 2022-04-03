namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class TestDomainEntity
    : eAcademy.Core.Domain.Entities.DomainEntity
{
    public TestDomainEntity()
    {
        StringProperty = CoreConstants.GetNullString();
        CustomEntity = CoreConstants.GetNullObject<CustomEntity>();
    }

    public string StringProperty { get; set; }

    public CustomEntity CustomEntity { get; set; }

    public override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.TestDomainEntityValidator();
    }
}