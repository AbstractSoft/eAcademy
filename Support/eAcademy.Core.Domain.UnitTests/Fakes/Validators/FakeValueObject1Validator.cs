namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeValueObject1Validator
    : eAcademy.Core.Domain.Validators.BaseDomainValueObjectValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1>
{
    public FakeValueObject1Validator()
    {
        FluentValidation.DefaultValidatorExtensions.MinimumLength(
            FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.StringProperty)),
            3);
        FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.GuidProperty));
        FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.DateTimeProperty));
        RuleFor(x => x.FakeValueObjects2ListProperty)
            .SetValidator(new FakeValueObjects2ListValidator());
    }
}