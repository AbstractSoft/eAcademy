namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeEntity3 : eAcademy.Core.Domain.Entities.DomainEntity
{
    public FakeEntity3()
        : this(System.Guid.NewGuid())
    {
    }

    public FakeEntity3(System.Guid id)
        : base(id)
    {
        IntField = default;
        StringField = CoreConstants.GetNullString();
    }

    public int IntField { get; set; }

    public string StringField { get; set; }

    public override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeEntity3EntityValidator();
    }

    public static CustomEntity GetNullObject()
    {
        return new CustomEntity(System.Guid.Empty);
    }
}