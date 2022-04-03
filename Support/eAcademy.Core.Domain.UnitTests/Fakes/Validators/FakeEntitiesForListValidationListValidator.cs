namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeEntitiesForListValidationListValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntitiesListValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntitiesForListValidationList,
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntityForListValidation>
{
    public FakeEntitiesForListValidationListValidator()
    {
        RuleForEach(static list => list)
            .SetValidator(new FakeForListValidationEntityValidator());

        DefaultValidatorExtensions.NotEmpty(RuleFor(static list => list));
    }
}