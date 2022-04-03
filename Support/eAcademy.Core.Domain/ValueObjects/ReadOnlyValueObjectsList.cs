namespace eAcademy.Core.Domain.ValueObjects;

public abstract class ReadOnlyValueObjectsList<T>
    : ValueObjectsList<T>
    where T : ValueObject
{
    protected ReadOnlyValueObjectsList(System.Collections.Generic.IEnumerable<T> list)
    {
        AddRange(list);
        IsReadOnly = true;
    }
}