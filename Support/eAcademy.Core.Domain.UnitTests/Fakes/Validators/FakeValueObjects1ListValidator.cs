namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class
    FakeValueObjects1ListValidator : eAcademy.Core.Domain.Validators.BaseDomainValueObjectsListValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List,
        eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1>
{
    public FakeValueObjects1ListValidator()
    {
        RuleForEach(list => list)
            .SetValidator(new FakeValueObject1Validator());

        FluentValidation.DefaultValidatorOptions.WithMessage(
            FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(list => list)),
            list => $@"'{list}' must not be empty.");
    }
}