namespace eAcademy.Core.Domain.ValueObjects;

public abstract class ValueObjectsList<T> : AbstractBaseList<T>
    where T : ValueObject
{
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType()) return false;

        var otherList = (ValueObjectsList<T>)obj;

        if (Count != otherList.Count) return false;

        for (var i = 0; i < Count; ++i)
            if (!this[i].Equals(otherList[i]))
                return false;

        return true;
    }

    public override int GetHashCode()
    {
        var atomicValues = System.Linq.Enumerable.ToArray(GetAtomicValues());
        if (atomicValues.Length == 0) return 0; //Aggregate throws exception if list is empty

        return System.Linq.Enumerable.Aggregate(System.Linq.Enumerable.Select(atomicValues, x => x.GetHashCode()),
            (x, y) => x ^ y);
    }

    private System.Collections.Generic.IEnumerable<object> GetAtomicValues()
    {
        return System.Linq.Enumerable.Cast<object>(System.Linq.Enumerable.Select(this, item => item.GetHashCode()));
    }
}