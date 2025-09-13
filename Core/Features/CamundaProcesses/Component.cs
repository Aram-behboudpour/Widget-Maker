using oc.TSB.Core.Base;
using System.Collections.Generic;

namespace oc.TSB.Core.Features.CamundaProcesses;

public class Component(string title, string name) : ExtendedEntity
{
    #region Properties

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

    [System.ComponentModel.DataAnnotations.MaxLength
        (length: Constants.MaxLength.Title,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
    public string Title { get; set; } = title;
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

    [System.ComponentModel.DataAnnotations.MaxLength
        (length: Constants.MaxLength.Name,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
    public string Name { get; set; } = name;
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

    public virtual IList<Component> Children { get; private set; } = [];

    #endregion /Collections
}
