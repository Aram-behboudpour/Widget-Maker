namespace oc.TSB.Core.Features.CamundaProcesses;

public class UserTask : CamundaBaseModel
{
    #region Constructor
    public UserTask() : base()
    {
        Title = string.Empty;
        Ordering = 10_000;

        Components = new
            System.Collections.Generic.List<Component>();
    }
    #endregion /Constructor

    #region Properties

    #region public bool IsActive { get; set; }
    /// <summary>
    /// وضعیت فرم
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsActive))]
    public bool IsActive { get; set; }
    #endregion /public bool IsActive { get; set; }

    #region public string Title { get; set; }
    /// <summary>
    /// عنوان فرم
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Title))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

    //[System.ComponentModel.DataAnnotations.MaxLength
    //    (length: Constants.MaxLength.MetaTitle,
    //    ErrorMessageResourceType = typeof(Resources.Messages.Validations),
    //    ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
    public string Title { get; set; }
    #endregion /public string Title { get; set; }

    #region public string Name { get; set; }
    /// <summary>
    /// نام فرم
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Name))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

    //[System.ComponentModel.DataAnnotations.MaxLength
    //    (length: Constants.MaxLength.MetaTitle,
    //    ErrorMessageResourceType = typeof(Resources.Messages.Validations),
    //    ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
    public string Name { get; set; }
    #endregion /public string Name { get; set; }

    #region public bool IsTestData { get; set; }
    /// <summary>
    /// داده تستی
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsTestData))]
    public bool IsTestData { get; set; }
    #endregion /public bool IsTestData { get; set; }

    #region public Guid ProcessId { get; set; }
    /// <summary>
    /// فرایندا
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Process))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
    public System.Guid ProcessId { get; set; }

    #endregion /public Guid ProcessId { get; set; }

    #region public virtual Process? Process { get; set; }
    /// <summary>
    /// فرایند
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Process))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
    public virtual Process? Process { get; set; }
    #endregion /public virtual Process? Process { get; set; }

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

    #endregion /Properties

    #region Collections

    public virtual System.Collections.Generic.IList<Component> Components { get; private set; }

    #endregion /Collections
}
