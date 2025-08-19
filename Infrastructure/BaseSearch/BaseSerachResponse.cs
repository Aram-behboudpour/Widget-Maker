using System.Collections.Generic;

namespace oc.TSB.Infrastructure.BaseSearch;

public class BaseSerachResponse<T> : object
{
    public BaseSerachResponse() : base()
    {
    }
    //**********
    public int PageIndex { get; set; }
    //**********

    //**********
    public int PageCount { get; set; }
    //**********

    //**********
    public int RecordCount { get; set; }
    //**********

    //**********
    public IList<T> List { get; set; } = new List<T>();
    //**********

    //**********
    public int? TotalCountByCondition { get; set; }
    //**********

    //**********
}
