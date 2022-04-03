namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeADAccountValidator
    : eAcademy.Core.Domain.Validators.BaseDomainValueObjectValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeADAccount>
{
    public FakeADAccountValidator()
    {
        FluentValidation.DefaultValidatorExtensions.MaximumLength(
            FluentValidation.DefaultValidatorExtensions.MinimumLength(
                FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(a => a.Domain)), 3),
            255);
        FluentValidation.DefaultValidatorExtensions.MaximumLength(
            FluentValidation.DefaultValidatorExtensions.MinimumLength(
                FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(a => a.Name)), 3),
            255);
    }
}