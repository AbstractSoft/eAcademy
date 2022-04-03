namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeEntity1 : eAcademy.Core.Domain.Entities.DomainEntity
{
    public FakeEntity1()
        : this(System.Guid.NewGuid())
    {
    }

    public FakeEntity1(System.Guid id) : base(id)
    {
        FakeEntity3List = new FakeEntity3List();
        IntField = default;
        StringField = CoreConstants.GetNullString();
        DateTimeField = default;
        FloatField = default;
        GuidField = System.Guid.Empty;
        FakeEntity2List = new FakeEntity2List();
        FakeEntity2ListTest = new FakeEntity2List();
    }

    public FakeEntity3List FakeEntity3List { get; set; }
    public int IntField { get; set; }
    public string StringField { get; set; }
    public System.DateTime DateTimeField { get; set; }
    public float FloatField { get; set; }
    public System.Guid GuidField { get; set; }
    public FakeEntity2List FakeEntity2List { get; set; }
    public FakeEntity2List FakeEntity2ListTest { get; set; }

    public override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeEntity1EntityValidator();
    }
}