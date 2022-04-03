namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeEntity2ListValidator : eAcademy.Core.Domain.Validators.BaseDomainEntitiesListValidator<
    eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity2List,
    eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeAuditedDomainEntity2>
{
    public FakeEntity2ListValidator()
    {
        DefaultValidatorExtensions.NotEmpty(RuleFor(list => list));

        RuleForEach(list => list)
            .SetValidator(new FakeAuditedDomainEntity2Validator());
    }
}