namespace oc.TSB.Core.Features.CamundaProcesses;

public class Process : CamundaBaseModel
{
    #region Costructor
    public Process() : base()
    {
        Title = string.Empty;
        Name = string.Empty;    

        Ordering = 10_000;

        UserTasks =
            new System.Collections.Generic.List<UserTask>();
    }

    #endregion /Costructor

    #region Properties

    #region public bool IsActive { get; set; }
    /// <summary>
    /// وضعیت فرایند
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsActive))]
    public bool IsActive { get; set; }
    #endregion /public bool IsActive { get; set; }

    #region public string Title { get; set; }
    /// <summary>
    /// عنوان فرایند
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

    #region public bool IsTestData { get; set; }
    /// <summary>
    /// داده تستی
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsTestData))]
    public bool IsTestData { get; set; }
    #endregion /public bool IsTestData { get; set; }

    #region public string Name { get; set; }
    /// <summary>
    /// نام فرایند
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

    #region public int Version { get; set; }
    /// <summary>
    /// نسخه فرایند
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Version))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

    public int Version { get; set; }
    #endregion /public int Version { get; set; }

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

    public virtual System.Collections.Generic.IList<UserTask> UserTasks { get; private set; }

    #endregion /Collections
}
