namespace oc.TSB.Infrastructure.BaseSearch;

public class ISearchArgs
{
    public int Page { get; set; } = 1;
    public string? Search { get; set; }
    public string? SortBy { get; set; }
}
