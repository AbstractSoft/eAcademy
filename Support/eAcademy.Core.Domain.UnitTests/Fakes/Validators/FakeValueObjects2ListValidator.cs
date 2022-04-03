namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class
    FakeValueObjects2ListValidator
    : eAcademy.Core.Domain.Validators.BaseDomainValueObjectsListValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects2List,
        eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject2>
{
    public FakeValueObjects2ListValidator()
    {
        RuleForEach(list => list)
            .SetValidator(new FakeValueObject2Validator());
    }
}