namespace eAcademy.Core.Domain.UnitTests;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
[Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute]
public class ValueObjectsListTests
{
    private readonly eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1 firstValueObject;
    private readonly eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List listOfInvalidValueObjects;

    // ReSharper disable once CollectionNeverQueried.Local
    private readonly eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.ReadonlyFakeValueObjects1List
        readonlyValueObjectsList;

    private readonly eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1 secondValueObject;

    public ValueObjectsListTests()
    {
        firstValueObject = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1(1, "test", default,
            3.7F, default, new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects2List());
        secondValueObject = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1(2, "test", default,
            3.7F, default, new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects2List());

        listOfInvalidValueObjects = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
            { firstValueObject, secondValueObject };
        readonlyValueObjectsList =
            new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.ReadonlyFakeValueObjects1List(
                listOfInvalidValueObjects);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatAValueObjectsListIsSuccessfullyPopulated()
    {
        var listOfValidValueObjects = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
        {
            GetNewValidFakeValueObject()
        };

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, listOfValidValueObjects.Count);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatNewInitializedValueObjectsListOnlyContainDistinctValueObjects()
    {
        var listOfValueObjects = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
            { GetNewDefaultFakeValueObject(), GetNewDefaultFakeValueObject() };

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, listOfValueObjects.Count);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatAValueObjectsListIsValid()
    {
        var listOfValidValueObjects = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
        {
            GetNewValidFakeValueObject()
        };

        listOfValidValueObjects.ValidateAndThrow();
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatValidatedListThrowsValidationExceptionWhenAnItemIsInvalid()
    {
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<FluentValidation.ValidationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () =>
                    listOfInvalidValueObjects.ValidateAndThrow(),
                Constants.SimpleAuditedDomainEntityChangedPropertiesValidationFailed2Message);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestIndexOf()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1,
            listOfInvalidValueObjects.IndexOf(secondValueObject));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestInsert()
    {
        var thirdValueObject = GetNewValidFakeValueObject();

        listOfInvalidValueObjects.Insert(1, thirdValueObject);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, listOfInvalidValueObjects.Count);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1,
            listOfInvalidValueObjects.IndexOf(thirdValueObject));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatInsertWillNotAddObjectWithSameValues()
    {
        var listOfValueObjects = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
            { GetNewInvalidFakeValueObject() };

        listOfValueObjects.Insert(0, GetNewInvalidFakeValueObject());

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, listOfValueObjects.Count);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestRemoveAt()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1,
            listOfInvalidValueObjects.IndexOf(secondValueObject));

        listOfInvalidValueObjects.RemoveAt(0);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, listOfInvalidValueObjects.Count);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0,
            listOfInvalidValueObjects.IndexOf(secondValueObject));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestSetterOfItemFromTheList()
    {
        var thirdEntity = GetNewValidFakeValueObject();

        listOfInvalidValueObjects[0] = thirdEntity;

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, listOfInvalidValueObjects.IndexOf(thirdEntity));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestGetterOfItemFromTheList()
    {
        var compareObject = new KellermanSoftware.CompareNetObjects.CompareLogic();

        var thirdEntity = GetNewValidFakeValueObject();

        listOfInvalidValueObjects[0] = thirdEntity;

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(compareObject
            .Compare(listOfInvalidValueObjects[0], thirdEntity).AreEqual);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestAddRange()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, listOfInvalidValueObjects.Count);

        var newListOfValueObjects = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
        {
            GetNewValidFakeValueObject(),
            GetNewValidFakeValueObject()
        };

        listOfInvalidValueObjects.AddRange(newListOfValueObjects);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(4, listOfInvalidValueObjects.Count);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatAddWillNotAddObjectWithSameValues()
    {
        var listOfValueObjects = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
        {
            GetNewInvalidFakeValueObject(), GetNewInvalidFakeValueObject()
        };

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, listOfValueObjects.Count);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatAddWithNullSourceThrowsArgumentNullException()
    {
        // ReSharper disable once CollectionNeverQueried.Local
        var listOfValueObjects = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List();

        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<System.ArgumentNullException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () => { listOfValueObjects.Add(null!); },
                @"Value cannot be null. (Parameter 'item')");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatAddRangeWillNotAddObjectsWithSameValues()
    {
        var listOfValueObjects = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
            { GetNewInvalidFakeValueObject() };
        var listOfValueObjects1 = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
            { GetNewInvalidFakeValueObject(), GetNewValidFakeValueObject() };

        listOfValueObjects.AddRange(listOfValueObjects1);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, listOfValueObjects.Count);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatAddRangeWithNullSourceThrowsArgumentNullException()
    {
        var listOfValueObjects = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List();

        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<System.ArgumentNullException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () => { listOfValueObjects.AddRange(null!); },
                @"Value cannot be null. (Parameter 'collection')");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestClear()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, listOfInvalidValueObjects.Count);

        listOfInvalidValueObjects.Clear();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, listOfInvalidValueObjects.Count);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestContains()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(
            listOfInvalidValueObjects.Contains(firstValueObject));

        listOfInvalidValueObjects.Remove(firstValueObject);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(
            listOfInvalidValueObjects.Contains(firstValueObject));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestCopyTo()
    {
        var newListOfValueObjects =
            new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1[listOfInvalidValueObjects.Count + 1];

        listOfInvalidValueObjects.CopyTo(newListOfValueObjects, 1);

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(secondValueObject, newListOfValueObjects[2]);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(newListOfValueObjects[0]);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestIsReadonly()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(listOfInvalidValueObjects.IsReadOnly);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(readonlyValueObjectsList.IsReadOnly);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestGetEnumerator()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(
            ((System.Collections.IEnumerable)listOfInvalidValueObjects).GetEnumerator(),
            typeof(System.Collections.IEnumerator));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestGetEnumerator2()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(listOfInvalidValueObjects.GetEnumerator(),
            typeof(System.Collections.Generic.List<eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1>.
                Enumerator));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatTryingToModifyAReadonlyListThrowsError()
    {
        const string expectedExceptionMessage = "This operation is not allowed on a ReadOnly list!";
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<System.InvalidOperationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () => readonlyValueObjectsList.Clear(),
                expectedExceptionMessage);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatAnEmptyListThatShouldNotBeEmptyThrowsValidationException()
    {
        const string expectedExceptionMessage =
            "Validation failed: \r\n -- : 'eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List' must not be empty. Severity: Error";
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<FluentValidation.ValidationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () =>
                {
                    var valueObjectsList =
                        new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List();
                    valueObjectsList.ValidateAndThrow();
                }, expectedExceptionMessage);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatCascadingValidationWorksOkOnLists()
    {
        var fakeValueObjects2List = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects2List
        {
            new(1, eAcademy.Core.Domain.Helpers.Constants.GetNullString(),
                new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject3(eAcademy.Core.Domain.Helpers
                    .Constants.GetNullString()))
        };

        var fakeValueObjectsList = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
        {
            new(1, "test", default, 1.1F, default, fakeValueObjects2List)
        };

        var exception =
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException<FluentValidation.ValidationException>(
                () => { fakeValueObjectsList.ValidateAndThrow(); });

        var normalized1 =
            System.Text.RegularExpressions.Regex.Replace(Constants.FakeValueObjectsListCascadingValidationFailedMessage,
                @"\s", "");
        var normalized2 = System.Text.RegularExpressions.Regex.Replace(exception.Message, @"\s", "");

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(normalized1, normalized2);
    }

    private static eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1 GetNewDefaultFakeValueObject()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1(1, "test",
            new System.DateTime(2019, 03, 04),
            3.7F, new System.Guid("9a0e13e4-f11d-42c6-9a02-5b38dc4bb082"),
            new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects2List());
    }

    private static eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1 GetNewValidFakeValueObject()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1(1, "test",
            new System.DateTime(2019, 03, 04), 3.7F, System.Guid.NewGuid(),
            new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects2List());
    }

    private static eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1 GetNewInvalidFakeValueObject()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject1(1, "test", default, 1.1F, default,
            new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects2List());
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void AValidValueObjectsListIsEqualWithAnotherValueObjectsListWithTheSameValues()
    {
        var fakeValueObjects2List = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects2List
        {
            new(1, "Abc", new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject3("Another test string"))
        };

        var fakeValueObjectsList1 = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
        {
            new(1, "test", new System.DateTime(2021, 07, 12), 1.1F,
                new System.Guid("26262DB5-9396-4633-B571-3A215CC56F05"),
                fakeValueObjects2List)
        };

        fakeValueObjectsList1.ValidateAndThrow();

        var fakeValueObjectsList2 = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
        {
            new(1, "test", new System.DateTime(2021, 07, 12), 1.1F,
                new System.Guid("26262DB5-9396-4633-B571-3A215CC56F05"),
                fakeValueObjects2List)
        };

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(fakeValueObjectsList1.Equals(fakeValueObjectsList2));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void AValidValueObjectsListIsNotEqualWithAnotherValueObjectsListWithDifferentValues()
    {
        var fakeValueObjects2List = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects2List
        {
            new(1, "Abc", new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject3("Another test string"))
        };

        var fakeValueObjectsList1 = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
        {
            new(1, "test1", new System.DateTime(2021, 07, 12), 1.1F,
                new System.Guid("26262DB5-9396-4633-B571-3A215CC56F05"),
                fakeValueObjects2List)
        };

        fakeValueObjectsList1.ValidateAndThrow();

        var fakeValueObjectsList2 = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObjects1List
        {
            new(1, "test2", new System.DateTime(2021, 07, 12), 1.1F,
                new System.Guid("26262DB5-9396-4633-B571-3A215CC56F05"),
                fakeValueObjects2List)
        };

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(
            fakeValueObjectsList1.Equals(fakeValueObjectsList2));
    }
}