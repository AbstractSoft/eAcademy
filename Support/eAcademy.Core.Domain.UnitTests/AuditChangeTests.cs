namespace eAcademy.Core.Domain.UnitTests;

[Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute]
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class AuditChangeTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void WhenValidArgumentsAreProvidedValidationPasses()
    {
        var auditChange = new eAcademy.Core.Domain.ValueObjects.AuditChange(Constants.UserName, Constants.CreatedDate);

        auditChange.ValidateAndThrow();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(Constants.UserName, auditChange.Name);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(Constants.CreatedDate, auditChange.Date);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void WhenInvalidArgumentsAreProvidedAValidationExceptionIsThrown()
    {
        var auditChange =
            new eAcademy.Core.Domain.ValueObjects.AuditChange(eAcademy.Core.Domain.Helpers.Constants.GetNullString(),
                default);

        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<FluentValidation.ValidationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () => { auditChange.ValidateAndThrow(); },
                @"Validation failed: 
 -- Name: 'AuditChange::Name' must not be empty. Severity: Error
 -- Name: 'AuditChange::Name' must be between 3 and 100 characters. You entered 0 characters. Severity: Error
 -- Date: 'AuditChange::Date' is required. Severity: Error");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void WhenUserNameIsNotValidAValidationExceptionIsThrown()
    {
        var auditChange = new eAcademy.Core.Domain.ValueObjects.AuditChange(null!, Constants.CreatedDate);

        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<FluentValidation.ValidationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () => { auditChange.ValidateAndThrow(); },
                @"Validation failed:
 -- Name: 'AuditChange::Name' must not be empty. Severity: Error");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void WhenDateIsNotValidAValidationExceptionIsThrown()
    {
        var auditChange = new eAcademy.Core.Domain.ValueObjects.AuditChange(Constants.UserName, default);

        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<FluentValidation.ValidationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () => { auditChange.ValidateAndThrow(); },
                @"Validation failed:
 -- Date: 'AuditChange::Date' is required. Severity: Error");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void AValidAuditChangeIsEqualWithAnotherValidAuditChangeWithTheSameValues()
    {
        var auditChange1 = new eAcademy.Core.Domain.ValueObjects.AuditChange(Constants.UserName, Constants.CreatedDate);
        auditChange1.ValidateAndThrow();

        var auditChange2 = new eAcademy.Core.Domain.ValueObjects.AuditChange(Constants.UserName, Constants.CreatedDate);
        auditChange2.ValidateAndThrow();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(auditChange1.Equals(auditChange2));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void AValidAuditChangeIsNotEqualWithAnotherValidAuditChangeWithDifferentValues()
    {
        var auditChange1 =
            new eAcademy.Core.Domain.ValueObjects.AuditChange(Constants.UserName1, Constants.CreatedDate);
        auditChange1.ValidateAndThrow();

        var auditChange2 =
            new eAcademy.Core.Domain.ValueObjects.AuditChange(Constants.UserName2, Constants.CreatedDate);
        auditChange2.ValidateAndThrow();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(auditChange1.Equals(auditChange2));
    }
}