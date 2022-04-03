namespace eAcademy.Core.Domain.UnitTests;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
[Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute]
public class DomainEntityTests
{
    private readonly KellermanSoftware.CompareNetObjects.CompareLogic compareObject = new();

    private eAcademy.Core.Domain.UnitTests.Fakes.Entities.Test1DomainEntity entity = eAcademy.Core.Domain.Helpers
        .Constants.GetNullObject<eAcademy.Core.Domain.UnitTests.Fakes.Entities.Test1DomainEntity>();

    private eAcademy.Core.Domain.UnitTests.Fakes.Entities.Test1DomainEntity entityCopy = eAcademy.Core.Domain.Helpers
        .Constants.GetNullObject<eAcademy.Core.Domain.UnitTests.Fakes.Entities.Test1DomainEntity>();

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute]
    public void SetUp()
    {
        entity = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.Test1DomainEntity();
        entityCopy = (eAcademy.Core.Domain.UnitTests.Fakes.Entities.Test1DomainEntity)entity.Copy();
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatACopyOfADomainEntityIsObtained()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(entityCopy);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(entity.Equals(entityCopy));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void TestThatTheCopyPropertiesHaveTheSameValuesWithTheOriginalOnes()
    {
        compareObject.Config.MembersToIgnore.Add("Id");

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(compareObject.Compare(entityCopy, entity).AreEqual);
    }
}