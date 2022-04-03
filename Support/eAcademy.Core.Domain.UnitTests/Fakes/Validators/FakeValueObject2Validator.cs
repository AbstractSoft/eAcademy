namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeValueObject2Validator : eAcademy.Core.Domain.Validators.BaseDomainValueObjectValidator<
    eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject2>
{
    public FakeValueObject2Validator()
    {
        FluentValidation.DefaultValidatorExtensions.Length(
            FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.StringProperty)), 1, 3);
        RuleFor(x => x.FakeValueObject3Property)
            .SetValidator(new FakeValueObject3Validator());
    }
}