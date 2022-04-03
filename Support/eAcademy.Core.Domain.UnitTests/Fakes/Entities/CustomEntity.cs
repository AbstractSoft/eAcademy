namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

#region

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

#endregion

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CustomEntity
    : eAcademy.Core.Domain.Entities.DomainEntity
{
    public CustomEntity()
        : this(System.Guid.NewGuid())
    {
    }

    public CustomEntity(System.Guid id)
        : base(id)
    {
        StringProperty = CoreConstants.GetNullString();
        StringProperty2 = CoreConstants.GetNullString();
        IntProperty = default;
        DateTimeProperty = default;
        CustomEntity2 = CoreConstants.GetNullObject<CustomEntity2>();
    }

    public string StringProperty { get; set; }
    public string StringProperty2 { get; set; }
    public int IntProperty { get; set; }
    public System.DateTime DateTimeProperty { get; set; }
    public CustomEntity2 CustomEntity2 { get; set; }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.CustomEntityValidator();
    }
}