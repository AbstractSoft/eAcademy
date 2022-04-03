namespace eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeADAccount : eAcademy.Core.Domain.ValueObjects.ValueObject
{
    public FakeADAccount()
    {
        Domain = eAcademy.Core.Domain.Helpers.Constants.GetNullString();
        Name = eAcademy.Core.Domain.Helpers.Constants.GetNullString();
    }

    public string Domain { get; private set; }

    public string Name { get; private set; }

    public static FakeADAccount From(string accountString)
    {
        var account = new FakeADAccount();

        var index = accountString.IndexOf("\\", System.StringComparison.Ordinal);
        account.Domain = accountString[..index];
        account.Name = accountString[(index + 1)..];

        return account;
    }

    public static implicit operator string(FakeADAccount account)
    {
        return account.ToString();
    }

    public static explicit operator FakeADAccount(string accountString)
    {
        return From(accountString);
    }

    public override string ToString()
    {
        return $"{Domain}\\{Name}";
    }

    protected override System.Collections.Generic.IEnumerable<object> GetAtomicValues()
    {
        yield return Domain;
        yield return Name;
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.FakeADAccountValidator();
    }

    public void ResetName()
    {
        Name = eAcademy.Core.Domain.Helpers.Constants.GetNullString();
    }
}