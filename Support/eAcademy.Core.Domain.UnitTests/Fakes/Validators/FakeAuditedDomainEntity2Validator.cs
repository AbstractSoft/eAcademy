namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeAuditedDomainEntity2Validator
    : eAcademy.Core.Domain.Validators.AuditedDomainEntityValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeAuditedDomainEntity2>
{
    public FakeAuditedDomainEntity2Validator()
    {
        DefaultValidatorExtensions.NotEmpty(RuleFor(static a => a.StringField));
        RuleFor(static a => a.FakeEntity3)
            .SetValidator(new FakeEntity3EntityValidator());
    }
}