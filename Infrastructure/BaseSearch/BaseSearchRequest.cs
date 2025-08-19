//using oc.Base.Domain.Enums;

namespace oc.TSB.Infrastructure.BaseSearch;

public class BaseSearchRequest : object
{
    public BaseSearchRequest() : base()
    {
    }
    //**********
    public int PageSize { get; set; } = 10;
    //**********

    //**********
    public int PageIndex { get; set; } = 0;
    //**********

    //**********
    public string SortField { get; set; } = "Id";
    //**********

    //**********
    //public OrderType OrderType { get; set; } = OrderType.DESC;
    //**********

    //**********
}
