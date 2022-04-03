namespace eAcademy.Core.Domain.UnitTests.Fakes.Entities;

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class Test1DomainEntity : eAcademy.Core.Domain.Entities.DomainEntity
{
    public Test1DomainEntity()
        : this(System.Guid.NewGuid())
    {
    }

    public Test1DomainEntity(System.Guid id)
        : base(id)
    {
        StringProperty = CoreConstants.GetNullString();
        IntProperty = default;
        DateTimeProperty = default;
        CustomObjectsList = new System.Collections.Generic.List<CustomEntity>(3);

        InitTest1DomainEntity();
    }

    public string StringProperty { get; set; }
    private int IntProperty { get; set; }
    private System.DateTime DateTimeProperty { get; set; }
    private System.Collections.Generic.List<CustomEntity> CustomObjectsList { get; set; }

    private void InitTest1DomainEntity()
    {
        StringProperty = "StringPropertyValue";
        IntProperty = 1;
        DateTimeProperty = System.DateTime.Now;
        CustomObjectsList = new System.Collections.Generic.List<CustomEntity>(3);

        CustomObjectsList.AddRange(new System.Collections.Generic.List<CustomEntity>
        {
            new()
            {
                StringProperty = "entity1",
                IntProperty = 100,
                DateTimeProperty = new System.DateTime(2015, 9, 1)
            },
            new()
            {
                StringProperty = "entity2",
                IntProperty = 200,
                DateTimeProperty = new System.DateTime(2015, 9, 2)
            },
            new()
            {
                StringProperty = "entity3",
                IntProperty = 300,
                DateTimeProperty = new System.DateTime(2015, 9, 3)
            }
        });
    }

    public override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Core.Domain.UnitTests.Fakes.Validators.Test1DomainEntityValidator();
    }
}