namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CustomEntityValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntityValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomEntity>
{
    public CustomEntityValidator()
    {
        FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.StringProperty));
        FluentValidation.DefaultValidatorExtensions.Length(
            FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.StringProperty2)), 3);
        FluentValidation.DefaultValidatorExtensions.NotNull(RuleFor(x => x.CustomEntity2))
            .SetValidator(new CustomEntity2EntityValidator());
    }
}