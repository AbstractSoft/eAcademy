namespace eAcademy.Core.Domain.Entities;

public abstract class ReadonlyDomainEntitiesList<T> : DomainEntitiesList<T>
    where T : DomainEntity
{
    protected ReadonlyDomainEntitiesList(System.Collections.Generic.IEnumerable<T> list)
    {
        AddRange(list);
        IsReadOnly = true;
    }
}