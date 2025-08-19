namespace oc.TSB.Core.Features.CamundaProcesses;

public class CamundaBaseModel: Base.Entity,
          Faraz.Domain.IEntityHasUpdateDateTime

{
    public CamundaBaseModel() : base()
    {
        InsertDateTime = Faraz.DateTime.Now;
        UpdateDateTime = InsertDateTime;
    }

    #region public System.Guid? InsertUserId { get; set; }
    /// <summary>
    /// شناسه
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.CreatorUser))]

    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
        (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public System.Guid? InsertUserId { get; set; }
    #endregion /public System.Guid? InsertUserId { get; set; }

    #region public System.Guid? UpdateUserId { get; set; }
    /// <summary>
    /// شناسه
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UpdateUser))]

    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
        (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public System.Guid? UpdateUserId { get; set; }
    #endregion /public System.Guid? UpdateUserId { get; set; }

    #region public System.DateTimeOffset InsertDateTime { get; private set; }
    /// <summary>
    /// زمان ایجاد
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.InsertDateTime))]

    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
        (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public System.DateTimeOffset InsertDateTime { get; private set; }
    #endregion /public System.DateTimeOffset InsertDateTime { get; private set; }

    #region public  System.DateTimeOffset UpdateDateTime { get; private set; }
    /// <summary>
    /// زمان ویرایش
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UpdateDateTime))]

    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
        (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public System.DateTimeOffset UpdateDateTime { get; private set; }
    #endregion /public  System.DateTimeOffset UpdateDateTime { get; private set; }


    #region Methods

    #region SetUpdateDateTime()
    public void SetUpdateDateTime()
    {
        UpdateDateTime =
            Faraz.DateTime.Now;
    }
    #endregion /SetUpdateDateTime()

    #endregion /Methods
}

