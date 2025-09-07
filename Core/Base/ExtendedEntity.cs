namespace oc.TSB.Core.Base;

public class ExtendedEntity: Entity,
          Faraz.Domain.IEntityHasUpdateDateTime

{
    public ExtendedEntity() : base()
    {
        Ordering = 10_000;

        InsertDateTime = Faraz.DateTime.Now;
        UpdateDateTime = InsertDateTime;
    }

    #region public bool IsActive { get; set; }
    /// <summary>
    /// وضعیت 
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsActive))]
    public bool IsActive { get; set; }
    #endregion /public bool IsActive { get; set; }

    #region public bool IsTestData { get; set; }
    /// <summary>
    /// داده تستی
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsTestData))]
    public bool IsTestData { get; set; }
    #endregion /public bool IsTestData { get; set; }

    #region public int Ordering { get; set; }
    /// <summary>
    /// چیدمان
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Ordering))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

    //[System.ComponentModel.DataAnnotations.Range
    //    (minimum: 1, maximum: 100_000,
    //    ErrorMessageResourceType = typeof(Resources.Messages.Validations),
    //    ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
    public int Ordering { get; set; }
    #endregion /public int Ordering { get; set; }

    #region public System.Guid? InsertUserId { get; set; }
    /// <summary>
    /// شناسه
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.CreatorUser))]

    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
        (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public System.Guid? InsertUserId { get; set; }
    #endregion /public System.Guid? InsertUserId { get; set; }

    #region public System.Guid? UpdateUserId { get; set; }
    /// <summary>
    /// شناسه
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UpdateUser))]

    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
        (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public System.Guid? UpdateUserId { get; set; }
    #endregion /public System.Guid? UpdateUserId { get; set; }

    #region public System.DateTimeOffset InsertDateTime { get; private set; }
    /// <summary>
    /// زمان ایجاد
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.InsertDateTime))]

    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
        (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public System.DateTimeOffset InsertDateTime { get; private set; }
    #endregion /public System.DateTimeOffset InsertDateTime { get; private set; }

    #region public  System.DateTimeOffset UpdateDateTime { get; private set; }
    /// <summary>
    /// زمان ویرایش
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UpdateDateTime))]

    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
        (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public System.DateTimeOffset UpdateDateTime { get; private set; }
    #endregion /public  System.DateTimeOffset UpdateDateTime { get; private set; }


    #region Methods

    #region SetUpdateDateTime()
    public void SetUpdateDateTime()
    {
        UpdateDateTime =
            Faraz.DateTime.Now;
    }
    #endregion /SetUpdateDateTime()

    #endregion /Methods
}

