namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using FluentValidation;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class SimpleAuditedDomainEntityValidator
    : eAcademy.Core.Domain.Validators.AuditedDomainEntityValidator<
    eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity>
{
    public SimpleAuditedDomainEntityValidator()
    {
        RuleFor(static entity => entity.Text)
            .NotEmpty()
            .Length(1, 20);
    }
}