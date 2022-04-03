namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

#region

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

#endregion

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class
    Test1DomainEntityValidator : eAcademy.Core.Domain.Validators.BaseDomainEntityValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.Test1DomainEntity>
{
    public Test1DomainEntityValidator()
    {
        DefaultValidatorExtensions.NotEmpty(RuleFor(static x => x.StringProperty));
    }
}