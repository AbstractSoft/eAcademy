namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class
    FakeEntity1EntityValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntityValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity1>
{
    public FakeEntity1EntityValidator()
    {
        DefaultValidatorExtensions.NotEmpty(RuleFor(static a => a.StringField));
    }
}