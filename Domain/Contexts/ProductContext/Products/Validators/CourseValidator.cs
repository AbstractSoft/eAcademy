namespace eAcademy.Domain.Contexts.ProductContext.Products.Validators;

#region

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;
//using Models.ProductAggregate;

#endregion

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CourseValidator : eAcademy.Core.Domain.Validators.BaseDomainEntityValidator<Course>
{
    public CourseValidator()
    {
        DefaultValidatorExtensions.Length(DefaultValidatorExtensions.NotEmpty(RuleFor(p => p.Name)), 2, 50);
        // RuleFor(p => p.ApplicationCode)
        //     .NotEmpty()
        //     .Length(2, 50);
        // RuleFor(p => p.R12Code)
        //     .LessThanOrEqualTo(3);
    }
}