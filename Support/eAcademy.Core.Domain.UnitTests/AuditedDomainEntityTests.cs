namespace eAcademy.Core.Domain.UnitTests;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
[Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute]
public class AuditedDomainEntityTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatWhenRequiredPropertiesAreFilledInValidationPasses()
    {
        var auditedEntity =
            new eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity(Constants.UserName,
                Constants.CreatedDate)
            {
                Text = Constants.TestTextValue
            };

        auditedEntity.ValidateAndThrow();
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatArgumentNullExceptionIsThrownWhenCreatedByIsEmpty()
    {
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<FluentValidation.ValidationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () =>
                {
                    var auditedEntity =
                        new eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity(
                            eAcademy.Core.Domain.Helpers.Constants.GetNullString(), default)
                        {
                            Text = Constants.TestTextValue
                        };

                    auditedEntity.ValidateAndThrow();
                }, Constants.SimpleAuditedDomainEntityCreatedByIsEmptyMessage);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatArgumentExceptionIsThrownWhenCreatedDateIsDefault()
    {
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<FluentValidation.ValidationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () =>
                {
                    var auditedEntity =
                        new eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity(Constants.UserName,
                            default)
                        {
                            Text = Constants.TestTextValue
                        };

                    auditedEntity.ValidateAndThrow();
                }, Constants.SimpleAuditedDomainEntityCreatedDateIsDefaultMessage);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatWhenChangedPropertiesAreNotFilledInValidationFails()
    {
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<FluentValidation.ValidationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () =>
                {
                    var auditedEntity = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity(
                        new System.Guid("f20133e7-8e1e-48e3-9458-1001747159a7"),
                        Constants.UserName, Constants.CreatedDate, Constants.UserName,
                        Constants.CreatedDate.AddHours(1))
                    {
                        Text = Constants.TestTextValue
                    };
                    auditedEntity.Update(eAcademy.Core.Domain.Helpers.Constants.GetNullString(), default);

                    auditedEntity.ValidateAndThrow();
                }, Constants.SimpleAuditedDomainEntityChangedPropertiesValidationFailedMessage);
    }
}