namespace oc.TSB.Core.Features.CamundaProcesses;

public class Component : CamundaBaseModel
{
    public Component() : base()
    {
        Title = string.Empty;
        Name = string.Empty;
        Ordering = 10_000;

        Children = new
          System.Collections.Generic.List<Component>();
    }

    #region Properties

    #region public bool IsActive { get; set; }
    /// <summary>
    /// وضعیت کامپوننت
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsActive))]
    public bool IsActive { get; set; }
    #endregion /public bool IsActive { get; set; }

    #region public string Title { get; set; }
    /// <summary>
    /// عنوان کامپوننت
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
    /// نام کامپوننت
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

    #region public ComponentType ComponentType { get; set; }
    /// <summary>
    /// نوع کامپوننت
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.ComponentType))]

    public Enums.ComponentType ComponentType { get; set; }
    #endregion /public ComponentType ComponentType { get; set; }

    #region public Guid UserTaskId { get; set; }
    /// <summary>
    /// فرم
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UserTask))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
    public System.Guid UserTaskId { get; set; }

    #endregion /public Guid UserTaskId { get; set; }

    #region public virtual UserTask? UserTask { get; set; }
    /// <summary>
    /// فرم
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UserTask))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
    public virtual UserTask? UserTask { get; set; }
    #endregion /public virtual UserTask? UserTask { get; set; }

    #region public bool IsTestData { get; set; }
    /// <summary>
    /// داده تستی
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsTestData))]
    public bool IsTestData { get; set; }
    #endregion /public bool IsTestData { get; set; }

    #region public Guid? ParentComponentId { get; set; }
    /// <summary>]
    /// کامپوننت والد
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Component))]

    public System.Guid? ParentComponentId { get; set; }
    #endregion /public Guid? ParentComponentId { get; set; }

    #region public virtual Component? ParentComponent { get; set; }
    /// <summary>
    ///  کامپوننت والد
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Component))]

    public virtual Component? ParentComponent { get; set; }
    #endregion /public virtual Component? ParentComponent { get; set; }


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
    public int Ordering { get; set; }
    #endregion /public int Ordering { get; set; }

    #region public string? ComponentImageUrl { get; set; }
    /// <summary>
    /// نشانی فایل
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.ComponentImageUrl))]

    public string? ComponentImageUrl { get; set; }
    #endregion /public string? ComponentImageUrl { get; set; }

    #endregion /Properties

    #region Collections

    public virtual System.Collections.Generic.IList<Component> Children { get; set; }

    #endregion /Collections
}
