namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

#region

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

#endregion

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeEntity3ListValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntitiesListValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity3List,
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity3>
{
    public FakeEntity3ListValidator()
    {
        DefaultValidatorExtensions.NotEmpty(RuleFor(static list => list));

        RuleForEach(static list => list)
            .SetValidator(new FakeEntity3EntityValidator());
    }
}