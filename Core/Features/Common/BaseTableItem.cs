using oc.TSB.Core.Base;
using System;
using System.Collections.Generic;

namespace oc.TSB.Core.Features.Common;

public class BaseTableItem(Guid baseTableId,
        string keyName, int? code = null) : ExtendedEntity
{
    #region Properties

    #region public System.Guid BaseTableId { get; set; }
    /// <summary>
    /// نوع اطلاعات پایه
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.BaseTable))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
    public System.Guid BaseTableId { get; set; } = baseTableId;
    #endregion /public System.Guid BaseTableId { get; set; }

    #region public virtual BaseTable? BaseTable { get; private set; }
    /// <summary>
    /// نوع اطلاعات پایه
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.BaseTable))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
    public virtual BaseTable? BaseTable { get; private set; }
    #endregion /public virtual BaseTable? BaseTable { get; private set; }

    #region public string KeyName { get; set; }
    /// <summary>
    /// نام کلیدی
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.KeyName))]

    [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

    [System.ComponentModel.DataAnnotations.MaxLength
        (length: Constants.MaxLength.KeyName,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

    [System.ComponentModel.DataAnnotations.RegularExpression
        (pattern: Constants.RegularExpression.AToZDigitsUnderline,
        ErrorMessageResourceType = typeof(Resources.Messages.Validations),
        ErrorMessageResourceName = nameof(Resources.Messages.Validations.KeyName))]
    public string KeyName { get; set; } = keyName;
    #endregion /public string KeyName { get; set; }

    #region public int? Code { get; set; }
    /// <summary>
    /// کد
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Code))]
    public int? Code { get; set; } = code;
    #endregion /public int? Code { get; set; }

    #endregion /Properties

    #region Collections

    public virtual IList<Identity.User> Users_Role { get; private set; } = [];
    public virtual IList<Identity.User> Users_Gender { get; private set; } = [];

    #endregion /Collections
}
