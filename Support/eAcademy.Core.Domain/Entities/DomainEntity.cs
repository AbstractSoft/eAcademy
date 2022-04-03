namespace eAcademy.Core.Domain.Entities;

public abstract class DomainEntity : AbstractBase
{
    protected DomainEntity()
        : this(System.Guid.NewGuid())
    {
    }

    protected DomainEntity(System.Guid id)
    {
        Id = id;
    }

    public System.Guid Id { get; }
}