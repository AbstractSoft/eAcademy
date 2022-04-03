namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using FluentValidation;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class TestDomainEntitiesListValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntitiesListValidator<eAcademy.Core.Domain.UnitTests.Fakes.Entities.TestDomainEntitiesList,
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.TestDomainEntity>
{
    public TestDomainEntitiesListValidator()
    {
        RuleFor(list => list)
            .NotEmpty()
            .WithMessage(list => $@"'{list}' must not be empty.");

        RuleForEach(list => list)
            .SetValidator(new TestDomainEntityValidator());
    }
}