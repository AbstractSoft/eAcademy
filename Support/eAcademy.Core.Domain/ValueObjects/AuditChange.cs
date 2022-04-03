namespace eAcademy.Core.Domain.ValueObjects;

public class AuditChange
    : ValueObject
{
    public AuditChange(string name, System.DateTime date)
    {
        Name = name;
        Date = date;
    }

    public string Name { get; }
    public System.DateTime Date { get; }

    protected override System.Collections.Generic.IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return Date;
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.Validators.AuditChangeValidator();
    }
}