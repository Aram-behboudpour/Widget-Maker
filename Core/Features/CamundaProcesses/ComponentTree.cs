using oc.TSB.Core.Base;

namespace oc.TSB.Core.Features.CamundaProcesses;

public class ComponentTree : ExtendedEntity
{
    #region Properties

    #region public string TreeJson { get; set; }
    /// <summary>
    /// فایل جیسون
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Title))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

    //[System.ComponentModel.DataAnnotations.MaxLength
    //    (length: Constants.MaxLength.Title,
    //    ErrorMessageResourceType = typeof(Resources.Messages.Validations),
    //    ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
    public string TreeJson { get; set; } = string.Empty;
    #endregion /public string TreeJson { get; set; }

    #region public int Version { get; set; }
    /// <summary>
    /// نسخه درخت
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Version))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

    public int Version { get; set; } = 1;
    #endregion /public int Version { get; set; }  

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

    public virtual UserTask? UserTask { get; set; }
    #endregion /public virtual UserTask? UserTask { get; set; }

    #endregion /Properties
}
