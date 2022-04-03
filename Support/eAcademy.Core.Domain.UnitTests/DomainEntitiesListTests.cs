namespace eAcademy.Core.Domain.UnitTests;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
[Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute]
public class DomainEntitiesListTests
{
    private const int ExpectedElementsCount = 1;

    private readonly eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity firstEntity;
    private readonly eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntitiesList listOfEntities;

    // ReSharper disable once CollectionNeverQueried.Local
    private readonly eAcademy.Core.Domain.UnitTests.Fakes.Entities.ReadonlySimpleAuditedDomainEntitiesList
        readOnlyEntitiesList;

    private readonly eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity secondEntity;
    private readonly eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity thirdEntity;

    public DomainEntitiesListTests()
    {
        firstEntity = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity(
            new System.Guid("f20133e7-8e1e-48e3-9458-1001747159a7"),
            Constants.UserName,
            Constants.CreatedDate,
            Constants.UserName3,
            Constants.CreatedDate.AddHours(1))
        {
            Text = Constants.TestTextValue
        };
        firstEntity.Update(eAcademy.Core.Domain.Helpers.Constants.GetNullString(), default);

        secondEntity = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity(
            new System.Guid("0b04c66c-e7cc-405c-8c9e-26f77fa951e7"),
            Constants.UserName,
            Constants.CreatedDate,
            Constants.UserName,
            Constants.CreatedDate.AddHours(1))
        {
            Text = Constants.TestTextValue
        };
        secondEntity.Update(eAcademy.Core.Domain.Helpers.Constants.GetNullString(), default);

        thirdEntity =
            new eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity(Constants.UserName,
                Constants.CreatedDate)
            {
                Text = Constants.TestTextValue
            };
        thirdEntity.Update(eAcademy.Core.Domain.Helpers.Constants.GetNullString(), default);

        listOfEntities = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntitiesList
            { firstEntity, secondEntity };
        readOnlyEntitiesList =
            new eAcademy.Core.Domain.UnitTests.Fakes.Entities.ReadonlySimpleAuditedDomainEntitiesList(listOfEntities);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatADomainEntitiesListIsSuccessfullyPopulated()
    {
        var domainEntitiesList = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.TestDomainEntitiesList
        {
            new()
        };

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ExpectedElementsCount, domainEntitiesList.Count);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatADomainEntitiesListIsValid()
    {
        FillTestDomainEntitiesList()
            .ValidateAndThrow();
    }

    private eAcademy.Core.Domain.UnitTests.Fakes.Entities.TestDomainEntitiesList FillTestDomainEntitiesList()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Entities.TestDomainEntitiesList
        {
            new()
            {
                CustomEntity = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomEntity
                {
                    DateTimeProperty = System.DateTime.Now,
                    IntProperty = 1,
                    StringProperty = "abc",
                    StringProperty2 = "def",
                    CustomEntity2 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomEntity2
                    {
                        Property = "000",
                        Property2 = "123"
                    }
                },
                StringProperty = "abc"
            }
        };
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatValidatedListThrowsValidationExceptionWhenAnItemIsInvalid()
    {
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<FluentValidation.ValidationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () => { listOfEntities.ValidateAndThrow(); },
                Constants.AuditedDomainEntityChangedPropertiesValidationFailedMessage);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestIndexOf()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, listOfEntities.IndexOf(secondEntity));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestInsert()
    {
        listOfEntities.Insert(1, thirdEntity);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, listOfEntities.Count);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, listOfEntities.IndexOf(thirdEntity));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestRemoveAt()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, listOfEntities.IndexOf(secondEntity));

        listOfEntities.RemoveAt(0);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, listOfEntities.Count);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, listOfEntities.IndexOf(secondEntity));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestSetterOfItemFromTheList()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Test text", listOfEntities[0].Text);

        listOfEntities[0] = thirdEntity;

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, listOfEntities.IndexOf(thirdEntity));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestAddRange()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, listOfEntities.Count);

        var newListOfEntities = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntitiesList
        {
            new(Constants.UserName, Constants.CreatedDate)
            {
                Text = Constants.TestTextValue
            },
            new(Constants.UserName, Constants.CreatedDate)
            {
                Text = Constants.TestTextValue
            }
        };

        newListOfEntities[0].Update(eAcademy.Core.Domain.Helpers.Constants.GetNullString(), default);
        newListOfEntities[1].Update(eAcademy.Core.Domain.Helpers.Constants.GetNullString(), default);

        listOfEntities.AddRange(newListOfEntities);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(4, listOfEntities.Count);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestClear()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, listOfEntities.Count);

        listOfEntities.Clear();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, listOfEntities.Count);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestContains()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(listOfEntities.Contains(firstEntity));

        listOfEntities.Remove(firstEntity);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(listOfEntities.Contains(firstEntity));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestCopyTo()
    {
        var newListOfEntities =
            new eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity[listOfEntities.Count + 1];

        listOfEntities.CopyTo(newListOfEntities, 1);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(secondEntity, newListOfEntities[2]);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(newListOfEntities[0]);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestIsReadonly()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(listOfEntities.IsReadOnly);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(readOnlyEntitiesList.IsReadOnly);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestGetEnumerator()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(
            ((System.Collections.IEnumerable)listOfEntities).GetEnumerator(), typeof(System.Collections.IEnumerator));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestGetEnumerator2()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(listOfEntities.GetEnumerator(),
            typeof(System.Collections.Generic.List<
                eAcademy.Core.Domain.UnitTests.Fakes.Entities.SimpleAuditedDomainEntity>.Enumerator));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatTryingToModifyAReadonlyListThrowsError()
    {
        const string expectedExceptionMessage = "This operation is not allowed on a ReadOnly list!";
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<System.InvalidOperationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () => readOnlyEntitiesList.Clear(),
                expectedExceptionMessage);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatAnEmptyListThatShouldNotBeEmptyThrowsValidationException()
    {
        const string expectedExceptionMessage =
            "Validation failed: \r\n -- : 'eAcademy.Core.Domain.UnitTests.Fakes.Entities.TestDomainEntitiesList' must not be empty. Severity: Error";
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<FluentValidation.ValidationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () =>
                {
                    var domainEntitiesList = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.TestDomainEntitiesList();
                    domainEntitiesList.ValidateAndThrow();
                }, expectedExceptionMessage);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatCascadingValidationWorksOkOnLists()
    {
        const string expectedExceptionMessage = Constants.FakeEntityForListValidationFailedMessage;
        var ex = Microsoft.VisualStudio.TestTools.UnitTesting.Assert
            .ThrowsException<FluentValidation.ValidationException>(
                GetFakeEntitiesForListValidationList().ValidateAndThrow);

        var normalized1 = System.Text.RegularExpressions.Regex.Replace(expectedExceptionMessage, @"\s", "");
        var normalized2 = System.Text.RegularExpressions.Regex.Replace(ex.Message, @"\s", "");

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(normalized1, normalized2);
    }

    private static eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntitiesForListValidationList
        GetFakeEntitiesForListValidationList()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntitiesForListValidationList
        {
            new(new System.Guid("d1273f9b-f2dd-43ea-b235-4c4c0158ed24"))
            {
                IntField = 1,
                StringField = eAcademy.Core.Domain.Helpers.Constants.GetNullString(),
                StringField2 = eAcademy.Core.Domain.Helpers.Constants.GetNullString(),
                FakeEntities2 = GetFakeEntity2List1()
            },
            new(new System.Guid("4a3d8d29-dddf-491e-a454-538bf6e32407"))
            {
                IntField = 2,
                StringField = "str",
                StringField2 = "str",
                FakeEntities2 = GetFakeEntity2List2()
            }
        };
    }

    private static eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity2List GetFakeEntity2List1()
    {
        var fakeEntity2A = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeAuditedDomainEntity2(
            new System.Guid("2c694487-d12c-426c-849d-2da6b4c2c0ac"),
            Constants.UserName1,
            System.DateTime.Now, Constants.UserName1,
            System.DateTime.Now.AddHours(1))
        {
            IntField = 1,
            FakeEntity3 =
                new eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity3(
                    new System.Guid("587334CE-9E96-4DCC-9CE2-32F7A7B0E90E"))
                {
                    IntField = 1,
                    StringField = eAcademy.Core.Domain.Helpers.Constants.GetNullString()
                }
        };

        var fakeEntity2B = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeAuditedDomainEntity2(
            new System.Guid("76CF69DE-60BD-4072-8418-9D3F3F0C1A1B"),
            Constants.UserName2,
            System.DateTime.Now,
            Constants.UserName2,
            System.DateTime.Now.AddHours(1))
        {
            IntField = 2,
            StringField = "str",
            FakeEntity3 =
                new eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity3(
                    new System.Guid("e27dddf3-452f-4bca-bf0e-e5e6b064a744"))
                {
                    IntField = 2,
                    StringField = "str"
                }
        };

        return new eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity2List { fakeEntity2A, fakeEntity2B };
    }

    private static eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity2List GetFakeEntity2List2()
    {
        var fakeEntity2 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeAuditedDomainEntity2(
            new System.Guid("5E2D215C-9256-47BC-8B6E-E5BA61DC6881"),
            Constants.UserName3,
            System.DateTime.Now,
            Constants.UserName3,
            System.DateTime.Now.AddHours(1))
        {
            IntField = 3,
            StringField = "str",
            FakeEntity3 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity3
            {
                IntField = 3,
                StringField = "str"
            }
        };

        return new eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity2List { fakeEntity2 };
    }
}