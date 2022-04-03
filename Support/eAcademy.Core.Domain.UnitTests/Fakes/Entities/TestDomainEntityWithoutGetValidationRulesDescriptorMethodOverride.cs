namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

#region

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

#endregion

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class TestDomainEntityWithoutGetValidationRulesDescriptorMethodOverride
    : eAcademy.Core.Domain.Entities.DomainEntity
{
    public TestDomainEntityWithoutGetValidationRulesDescriptorMethodOverride()
    {
        StringProperty = CoreConstants.GetNullString();
        CustomEntity = CoreConstants.GetNullObject<CustomEntity>();
    }

    public string StringProperty { get; set; }
    public CustomEntity CustomEntity { get; set; }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.
            TestDomainEntityWithoutGetValidationRulesDescriptorMethodOverrideValidator();
    }
}