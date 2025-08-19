namespace oc.TSB.Infrastructure.Features.Processes.ViewModels;

public class CreateViewModel : object
{
    public CreateViewModel() : base()
    {
        Ordering = 10_000;
        Title = string.Empty;
        Name = string.Empty;
        Version = string.Empty;
    }
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

    #region public string Version { get; set; }
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

    public string Version { get; set; }
    #endregion /public string Version { get; set; }

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
}
