namespace eAcademy.Core.Domain.ValueObjects;

// Source: https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects

public abstract class ValueObject : AbstractBase
{
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    public override bool Equals(object? obj)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    {
        if (obj == null || obj.GetType() != GetType()) return false;

        var other = (ValueObject)obj;
        using var thisValues = GetAtomicValues().GetEnumerator();
        using var otherValues = other.GetAtomicValues().GetEnumerator();

        while (thisValues.MoveNext() && otherValues.MoveNext())
        {
            // If either value (but not both) is null, return false
            if (thisValues.Current is null ^ otherValues.Current is null) return false;

            // If both values are null, move to next
            if (thisValues.Current is null) continue;

            // If both values are index-able, check for sequential equality
            if (thisValues.Current is System.Collections.IList thisList &&
                otherValues.Current is System.Collections.IList otherList)
            {
                var thisGenList = System.Linq.Enumerable.Cast<object>(thisList);
                var otherGenList = System.Linq.Enumerable.Cast<object>(otherList);
                if (!System.Linq.Enumerable.SequenceEqual(thisGenList, otherGenList)) return false;
            }
            // If both values are enumerable but not index-able, check for collection equality
            else if (thisValues.Current is System.Collections.IEnumerable thisCollection &&
                     otherValues.Current is System.Collections.IEnumerable otherCollection)
            {
                var thisGenCollection =
                    System.Linq.Enumerable.ToList(System.Linq.Enumerable.Cast<object>(thisCollection));
                var otherGenCollection =
                    System.Linq.Enumerable.ToList(System.Linq.Enumerable.Cast<object>(otherCollection));
                // If the collections contain different amounts of elements or collection B does not contain all of collection A's elements, return false
                if (thisGenCollection.Count != otherGenCollection.Count
                    || !System.Linq.Enumerable.All(thisGenCollection, thisElement =>
                        System.Linq.Enumerable.Any(otherGenCollection, otherElement =>
                            Equals(thisElement, otherElement))))
                    return false;
            }
            else if (!thisValues.Current.Equals(otherValues.Current))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return System.Linq.Enumerable.Aggregate(GetAtomicValues(), 92821, (result, obj) =>
        {
            // https://github.com/dotnet/roslyn/blob/master/src/Compilers/Test/Resources/Core/NetFX/ValueTuple/ValueTuple.cs#L11
            var rol5 = ((uint)result << 5) | ((uint)result >> 27);
            return ((int)rol5 + result) ^ obj?.GetHashCode() ?? 0;
        });
    }

    protected abstract System.Collections.Generic.IEnumerable<object> GetAtomicValues();
}