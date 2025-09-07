using oc.TSB.Core.Base;
using System.Collections.Generic;

namespace oc.TSB.Core.Features.CamundaProcesses;

public class Process(string title,string name) : ExtendedEntity
{
    #region Properties

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

    [System.ComponentModel.DataAnnotations.MaxLength
        (length: Constants.MaxLength.Title,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
    public string Title { get; set; } = title;
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

    [System.ComponentModel.DataAnnotations.MaxLength
        (length: Constants.MaxLength.Name,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
    public string Name { get; set; }= name; 
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

    public override string ToString()
    {
        var result =
            $"{nameof(Id)}:{Id} - {nameof(Title)}:{Title} - {nameof(Name)}:{Name}";

        return result;
    }

    #endregion /Properties

    #region Collections

    public virtual IList<UserTask> UserTasks { get; private set; } = new List<UserTask>();  

    #endregion /Collections
}
