using oc.TSB.Core.Base;
using System.Collections.Generic;

namespace oc.TSB.Core.Features.Common;

public class BaseTable(Enums.BaseTableEnum
        code, Enums.BaseTableTypeEnum type) : ExtendedEntity
{
    #region Properties

    #region public Enums.BaseTableEnum Code { get; set; }
    /// <summary>
    /// کد
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Code))]
    public Enums.BaseTableEnum Code { get; set; } = code;
    #endregion /public Enums.BaseTableEnum Code { get; set; }

    #region public Enums.BaseTableTypeEnum Type { get; set; }
    /// <summary>
    /// نوع اطلاعات پایه
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.BaseTableType))]
    public Enums.BaseTableTypeEnum Type { get; set; } = type;
    #endregion /public Enums.BaseTableTypeEnum Type { get; set; }

    #endregion /Properties

    #region Collections
    public virtual IList<BaseTableItem> BaseTableItems { get; private set; } = new List<BaseTableItem>();

    #endregion /Collections
}
