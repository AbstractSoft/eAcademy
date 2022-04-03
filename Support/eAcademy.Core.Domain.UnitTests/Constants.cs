namespace eAcademy.Core.Domain.UnitTests;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public static class Constants
{
    public const string UserName = @"adm\adm_egh";
    public const string UserName1 = "user";
    public const string UserName2 = "user2";
    public const string UserName3 = "user3";

    public const string AuditedDomainEntityChangedPropertiesValidationFailedMessage = @"Validation failed:
 -- SimpleAuditedDomainEntitiesList[0].Updated.Name: 'AuditChange::Name' must not be empty. Severity: Error
 -- SimpleAuditedDomainEntitiesList[0].Updated.Name: 'AuditChange::Name' must be between 3 and 100 characters. You entered 0 characters. Severity: Error
 -- SimpleAuditedDomainEntitiesList[0].Updated.Date: 'AuditChange::Date' is required. Severity: Error
 -- SimpleAuditedDomainEntitiesList[1].Updated.Name: 'AuditChange::Name' must not be empty. Severity: Error
 -- SimpleAuditedDomainEntitiesList[1].Updated.Name: 'AuditChange::Name' must be between 3 and 100 characters. You entered 0 characters. Severity: Error
 -- SimpleAuditedDomainEntitiesList[1].Updated.Date: 'AuditChange::Date' is required. Severity: Error";

    public const string TestTextValue = "Test text";

    public const string SimpleAuditedDomainEntityChangedPropertiesValidationFailedMessage = @"Validation failed:
 -- Updated.Name: 'AuditChange::Name' must not be empty. Severity: Error
 -- Updated.Name: 'AuditChange::Name' must be between 3 and 100 characters. You entered 0 characters. Severity: Error
 -- Updated.Date: 'AuditChange::Date' is required. Severity: Error";

    public const string SimpleAuditedDomainEntityChangedPropertiesValidationFailed2Message = @"Validation failed:
 -- FakeValueObjects1List[0].GuidProperty: 'FakeValueObject1::GuidProperty' must not be empty. Severity: Error
 -- FakeValueObjects1List[0].DateTimeProperty: 'FakeValueObject1::DateTimeProperty' must not be empty. Severity: Error
 -- FakeValueObjects1List[1].GuidProperty: 'FakeValueObject1::GuidProperty' must not be empty. Severity: Error
 -- FakeValueObjects1List[1].DateTimeProperty: 'FakeValueObject1::DateTimeProperty' must not be empty. Severity: Error";

    public const string FakeEntityForListValidationFailedMessage = @"Validation failed:
 -- FakeEntitiesForListValidationList[0].StringField: 'FakeEntityForListValidation [d1273f9b-f2dd-43ea-b235-4c4c0158ed24]::StringField' must not be empty. Severity: Error
 -- FakeEntitiesForListValidationList[0].StringField2: 'FakeEntityForListValidation [d1273f9b-f2dd-43ea-b235-4c4c0158ed24]::StringField2' must not be empty. Severity: Error
 -- FakeEntitiesForListValidationList[0].StringField2: 'FakeEntityForListValidation [d1273f9b-f2dd-43ea-b235-4c4c0158ed24]::StringField2' must be between 1 and 3 characters. You entered 0 characters. Severity: Error
 -- FakeEntitiesForListValidationList[0].FakeEntities2[0].StringField: 'FakeAuditedDomainEntity2 [2c694487-d12c-426c-849d-2da6b4c2c0ac]::StringField' must not be empty. Severity: Error
 -- FakeEntitiesForListValidationList[0].FakeEntities2[0].FakeEntity3.StringField: 'FakeEntity3 [587334ce-9e96-4dcc-9ce2-32f7a7b0e90e]::StringField' must not be empty. Severity: Error";

    public const string FakeADAccountValidationFailedMessage = @"Validation failed: 
 -- Domain: 'FakeADAccount::Domain' must not be empty. Severity: Error
 -- Domain: The length of 'FakeADAccount::Domain' must be at least 3 characters. You entered 0 characters. Severity: Error
 -- Name: 'FakeADAccount::Name' must not be empty. Severity: Error
 -- Name: The length of 'FakeADAccount::Name' must be at least 3 characters. You entered 0 characters. Severity: Error";

    public const string FakeValueObjectsListCascadingValidationFailedMessage = @"Validation failed:
 -- FakeValueObjects1List[0].GuidProperty: 'FakeValueObject1::GuidProperty' must not be empty. Severity: Error
 -- FakeValueObjects1List[0].DateTimeProperty: 'FakeValueObject1::DateTimeProperty' must not be empty. Severity: Error
 -- FakeValueObjects1List[0].FakeValueObjects2ListProperty[0].StringProperty: 'FakeValueObject2::StringProperty' must not be empty. Severity: Error
 -- FakeValueObjects1List[0].FakeValueObjects2ListProperty[0].StringProperty: 'FakeValueObject2::StringProperty' must be between 1 and 3 characters. You entered 0 characters. Severity: Error
 -- FakeValueObjects1List[0].FakeValueObjects2ListProperty[0].FakeValueObject3Property.StringProperty: 'FakeValueObject3::StringProperty' must not be empty. Severity: Error";

    public const string SimpleAuditedDomainEntityCreatedByIsEmptyMessage = @"Validation failed:
 -- Created.Name: 'AuditChange::Name' must not be empty. Severity: Error
 -- Created.Name: 'AuditChange::Name' must be between 3 and 100 characters. You entered 0 characters. Severity: Error
 -- Created.Date: 'AuditChange::Date' is required. Severity: Error
 -- Updated.Name: 'AuditChange::Name' must not be empty. Severity: Error
 -- Updated.Name: 'AuditChange::Name' must be between 3 and 100 characters. You entered 0 characters. Severity: Error
 -- Updated.Date: 'AuditChange::Date' is required. Severity: Error";

    public const string SimpleAuditedDomainEntityCreatedDateIsDefaultMessage = @"Validation failed:
 -- Created.Date: 'AuditChange::Date' is required. Severity: Error
 -- Updated.Date: 'AuditChange::Date' is required. Severity: Error";

    public static readonly System.DateTime CreatedDate = new(2016, 3, 6);
}