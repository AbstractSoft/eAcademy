namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

#region

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;
using DefaultValidatorOptions = FluentValidation.DefaultValidatorOptions;

#endregion

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class TestDomainEntitiesListValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntitiesListValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.TestDomainEntitiesList,
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.TestDomainEntity>
{
    public TestDomainEntitiesListValidator()
    {
        DefaultValidatorOptions.WithMessage(DefaultValidatorExtensions.NotEmpty(RuleFor(list => list)),
            list => $@"'{list}' must not be empty.");

        RuleForEach(list => list)
            .SetValidator(new TestDomainEntityValidator());
    }
}