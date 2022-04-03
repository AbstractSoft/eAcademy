namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using FluentValidation;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class TestDomainEntityWithoutGetValidationRulesDescriptorMethodOverrideValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntityValidator<eAcademy.Core.Domain.UnitTests.Fakes.Entities.
        TestDomainEntityWithoutGetValidationRulesDescriptorMethodOverride>
{
    public TestDomainEntityWithoutGetValidationRulesDescriptorMethodOverrideValidator()
    {
        RuleFor(static x => x.StringProperty)
            .NotEmpty()
            .Length(3);
        RuleFor(static x => x.CustomEntity)
            .NotNull()
            .SetValidator(new CustomEntityValidator());
    }
}