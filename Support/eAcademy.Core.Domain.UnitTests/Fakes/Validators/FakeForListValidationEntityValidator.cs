namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeForListValidationEntityValidator : eAcademy.Core.Domain.Validators.BaseDomainEntityValidator<
    eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntityForListValidation>
{
    public FakeForListValidationEntityValidator()
    {
        DefaultValidatorExtensions.NotEmpty(RuleFor(static a => a.StringField));
        DefaultValidatorExtensions.Length(DefaultValidatorExtensions.NotEmpty(RuleFor(static a => a.StringField2)), 1,
            3);
        RuleFor(static a => a.FakeEntities2)
            .SetValidator(new FakeEntity2ListValidator());
    }
}