namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CustomEntity2EntityValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntityValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomEntity2>
{
    public CustomEntity2EntityValidator()
    {
        FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.Property));
        FluentValidation.DefaultValidatorExtensions.Length(
            FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.Property2)), 3);
    }
}