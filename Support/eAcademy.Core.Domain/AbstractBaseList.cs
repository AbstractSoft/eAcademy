namespace eAcademy.Core.Domain;

public abstract class AbstractBaseList<T> : System.Collections.Generic.IList<T>,
    eAcademy.Core.Domain.Validators.IValidateable where T
    : AbstractBase
{
    private const string ErrMsgOperationIsNotPermittedOnAReadonlyList =
        "This operation is not allowed on a ReadOnly list!";

    private readonly System.Collections.Generic.IList<T> itemsList;

    protected AbstractBaseList()
    {
        itemsList = new System.Collections.Generic.List<T>();
    }

    public int IndexOf(T item)
    {
        return itemsList.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        CheckIfListIsReadonly();

        if (CheckIfValueObjectAlreadyExist(item)) return;

        itemsList.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        CheckIfListIsReadonly();
        itemsList.RemoveAt(index);
    }

    public T this[int index]
    {
        get => itemsList[index];
        set
        {
            CheckIfListIsReadonly();
            itemsList[index] = value;
        }
    }

    public void Add(T item)
    {
        if (item == null || item.Equals(default(T))) throw new System.ArgumentNullException(nameof(item));

        CheckIfListIsReadonly();
        if (CheckIfValueObjectAlreadyExist(item)) return;

        itemsList.Add(item);
    }

    public void Clear()
    {
        CheckIfListIsReadonly();
        itemsList.Clear();
    }

    public bool Contains(T item)
    {
        return itemsList.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        itemsList.CopyTo(array, arrayIndex);
    }

    public int Count => itemsList.Count;

    public bool IsReadOnly { get; protected set; }

    public bool Remove(T item)
    {
        CheckIfListIsReadonly();
        return itemsList.Remove(item);
    }

    public System.Collections.Generic.IEnumerator<T> GetEnumerator()
    {
        return itemsList.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void ValidateAndThrow()
    {
        var validationResult = GetValidator()
            .Validate(new FluentValidation.ValidationContext<object>(this));

        if (validationResult?.IsValid == false) throw new FluentValidation.ValidationException(validationResult.Errors);
    }

    protected abstract FluentValidation.IValidator GetValidator();

    public void AddRange(System.Collections.Generic.IEnumerable<T> collection)
    {
        if (collection == null) throw new System.ArgumentNullException(nameof(collection));

        CheckIfListIsReadonly();
        foreach (var item in collection) Add(item);
    }

    private void CheckIfListIsReadonly()
    {
        if (IsReadOnly) throw new System.InvalidOperationException(ErrMsgOperationIsNotPermittedOnAReadonlyList);
    }

    private bool CheckIfValueObjectAlreadyExist(T item)
    {
        return itemsList.Contains(item);
    }
}