namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using FluentValidation;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeEntity3ListValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntitiesListValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity3List,
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity3>
{
    public FakeEntity3ListValidator()
    {
        RuleFor(static list => list)
            .NotEmpty();

        RuleForEach(static list => list)
            .SetValidator(new FakeEntity3EntityValidator());
    }
}