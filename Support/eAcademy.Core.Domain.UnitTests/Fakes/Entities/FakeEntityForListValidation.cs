namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeEntityForListValidation : eAcademy.Core.Domain.Entities.DomainEntity
{
    public FakeEntityForListValidation()
        : this(System.Guid.NewGuid())
    {
    }

    public FakeEntityForListValidation(System.Guid id)
        : base(id)
    {
        IntField = default;
        StringField = CoreConstants.GetNullString();
        StringField2 = CoreConstants.GetNullString();
        FakeEntities2 = new FakeEntity2List();
    }

    public int IntField { get; set; }
    public string StringField { get; set; }
    public string StringField2 { get; set; }

    public FakeEntity2List FakeEntities2 { get; set; }

    public override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeForListValidationEntityValidator();
    }
}