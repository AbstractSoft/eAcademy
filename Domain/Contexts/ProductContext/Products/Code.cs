namespace eAcademy.Domain.Contexts.ProductContext.Products;

public class Code : eAcademy.Core.Domain.ValueObjects.ValueObject
{
    private Code(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Code Create(string value)
    {
        Code code = new(value);

        code.ValidateAndThrow();

        return code;
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Domain.Contexts.ProductContext.Products.Validators.CodeValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}