namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class SimpleAuditedDomainEntity
    : eAcademy.Core.Domain.Entities.AuditedDomainEntity
{
    public SimpleAuditedDomainEntity(string createdBy, System.DateTime createdDate)
        : base(createdBy, createdDate)
    {
        Text = CoreConstants.GetNullString();
    }

    public SimpleAuditedDomainEntity(System.Guid id, string createdBy, System.DateTime createdDate, string updatedBy,
        System.DateTime updatedDate)
        : base(id, createdBy, createdDate, createdBy, createdDate)
    {
        Text = CoreConstants.GetNullString();
    }

    public string Text { get; set; }

    public override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.SimpleAuditedDomainEntityValidator();
    }
}