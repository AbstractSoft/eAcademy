namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class ReadonlyFakeValueObjectsListValidator
    : eAcademy.Core.Domain.Validators.BaseDomainValueObjectsListValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.ReadonlyFakeValueObjects1List,
        eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1>
{
    public ReadonlyFakeValueObjectsListValidator()
    {
        RuleForEach(static list => list)
            .SetValidator(new FakeValueObject1Validator());
    }
}