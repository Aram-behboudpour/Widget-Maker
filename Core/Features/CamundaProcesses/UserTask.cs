using oc.TSB.Core.Base;
using System.Collections.Generic;

namespace oc.TSB.Core.Features.CamundaProcesses;

public class UserTask(string title, string name) : ExtendedEntity
{
    #region Properties

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

    [System.ComponentModel.DataAnnotations.MaxLength
        (length: Constants.MaxLength.Title,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
    public string Title { get; set; }= title;
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

    [System.ComponentModel.DataAnnotations.MaxLength
        (length: Constants.MaxLength.Name,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
    public string Name { get; set; }= name; 
    #endregion /public string Name { get; set; }

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

    #endregion /Properties

    #region Collections

    public virtual IList<Component> Components { get; private set; } = new List<Component>();   

    #endregion /Collections
}
