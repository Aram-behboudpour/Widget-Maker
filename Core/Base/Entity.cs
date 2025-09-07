using Faraz.Domain;
using System;

namespace oc.TSB.Core.Base;

public abstract class Entity : object, IEntity<Guid>
{
    #region Constructor
    public Entity() : base()
    {
    }
    #endregion /Constructor

    #region Properties

    #region public System.Guid Id { get; protected set; }
    /// <summary>
    /// شناسه
    /// </summary>

    [System.ComponentModel.DataAnnotations.Key]
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Id))]

    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
        (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public Guid Id { get; protected set; } = Guid.NewGuid();
    #endregion /public System.Guid Id { get; protected set; }

    #region public System.DateTimeOffset InsertDateTime { get; private set; }
    /// <summary>
    /// زمان ایجاد
    /// </summary>
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.InsertDateTime))]

    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
        (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public DateTimeOffset InsertDateTime { get; private set; }= DateTimeOffset.Now;
    #endregion /public System.DateTimeOffset InsertDateTime { get; private set; }

    #endregion /Properties
}