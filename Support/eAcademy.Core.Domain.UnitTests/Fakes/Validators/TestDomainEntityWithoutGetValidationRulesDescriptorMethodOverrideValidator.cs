namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

#region

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

#endregion

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class TestDomainEntityWithoutGetValidationRulesDescriptorMethodOverrideValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntityValidator<eAcademy.Core.Domain.UnitTests.Fakes.Entities.
        TestDomainEntityWithoutGetValidationRulesDescriptorMethodOverride>
{
    public TestDomainEntityWithoutGetValidationRulesDescriptorMethodOverrideValidator()
    {
        DefaultValidatorExtensions.Length(DefaultValidatorExtensions.NotEmpty(RuleFor(static x => x.StringProperty)),
            3);
        DefaultValidatorExtensions.NotNull(RuleFor(static x => x.CustomEntity))
            .SetValidator(new CustomEntityValidator());
    }
}