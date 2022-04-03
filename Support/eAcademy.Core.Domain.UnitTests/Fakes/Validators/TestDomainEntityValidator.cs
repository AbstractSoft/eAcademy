namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class TestDomainEntityValidator : FluentValidation.AbstractValidator<
    eAcademy.Core.Domain.UnitTests.Fakes.Entities.TestDomainEntity>
{
    public TestDomainEntityValidator()
    {
        FluentValidation.DefaultValidatorExtensions.Length(
            FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.StringProperty)), 3);
        FluentValidation.DefaultValidatorExtensions.NotNull(RuleFor(x => x.CustomEntity))
            .SetValidator(new CustomEntityValidator());
    }
}