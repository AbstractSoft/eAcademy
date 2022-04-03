namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CustomEntity2
    : eAcademy.Core.Domain.Entities.DomainEntity
{
    public CustomEntity2()
        : this(System.Guid.NewGuid())
    {
    }

    public CustomEntity2(System.Guid id)
        : base(id)
    {
        Property = CoreConstants.GetNullString();
        Property2 = CoreConstants.GetNullString();
    }

    public string Property { get; set; }
    public string Property2 { get; set; }

    public override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.CustomEntity2EntityValidator();
    }
}