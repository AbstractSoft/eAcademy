namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeAuditedDomainEntity2
    : eAcademy.Core.Domain.Entities.AuditedDomainEntity
{
    public FakeAuditedDomainEntity2(string createdBy, System.DateTime createdDate)
        : this(System.Guid.NewGuid(), createdBy, createdDate, createdBy, createdDate)
    {
    }

    public FakeAuditedDomainEntity2(System.Guid id, string createdBy, System.DateTime createdDate, string updatedBy,
        System.DateTime updatedDate)
        : base(id, createdBy, createdDate, updatedBy, updatedDate)
    {
        IntField = default;
        StringField = CoreConstants.GetNullString();
        FakeEntity3 = CoreConstants.GetNullObject<FakeEntity3>();
    }

    public int IntField { get; set; }
    public string StringField { get; set; }
    public FakeEntity3 FakeEntity3 { get; set; }

    public override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeAuditedDomainEntity2Validator();
    }
}