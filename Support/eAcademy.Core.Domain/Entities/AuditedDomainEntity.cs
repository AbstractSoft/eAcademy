namespace eAcademy.Core.Domain.Entities;

public abstract class AuditedDomainEntity : DomainEntity
{
    protected AuditedDomainEntity(string createdBy, System.DateTime createdDate)
        : this(System.Guid.NewGuid(), createdBy, createdDate, createdBy, createdDate)
    {
    }

    protected AuditedDomainEntity(System.Guid id, string createdBy, System.DateTime createdDate, string updatedBy,
        System.DateTime updatedDate)
        : base(id)
    {
        Created = new eAcademy.Core.Domain.ValueObjects.AuditChange(createdBy, createdDate);
        Updated = new eAcademy.Core.Domain.ValueObjects.AuditChange(updatedBy, updatedDate);
    }

    public eAcademy.Core.Domain.ValueObjects.AuditChange Created { get; }
    public eAcademy.Core.Domain.ValueObjects.AuditChange Updated { get; private set; }

    public void Update(string updatedBy, System.DateTime updatedDate)
    {
        Updated = new eAcademy.Core.Domain.ValueObjects.AuditChange(updatedBy, updatedDate);
    }
}