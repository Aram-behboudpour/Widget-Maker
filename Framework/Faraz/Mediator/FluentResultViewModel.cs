using System.Collections.Generic;

namespace Faraz.Mediator;

public class FluentResultViewModel<TObject> : object
{
    public FluentResultViewModel() : base()
    {
    }
    //**********
    public bool IsFailed { get; set; }
    //**********

    //**********
    public bool IsSuccess { get; set; }
    //**********

    //**********
    public List<FluentResultReason> Reasons { get; set; } = new List<FluentResultReason>();
    //**********

    //**********
    public List<FluentResultError> Errors { get; set; } = new List<FluentResultError>();
    //**********

    //**********
    public List<FluentResultSuccess> Successes { get; set; } = new List<FluentResultSuccess>();
    //**********

    //**********
    public TObject? Value { get; set; }
    //**********

    //**********

    public class FluentResultSuccess
    {
        public string? Message { get; set; }
    }

    public class FluentResultError
    {
        public string? Message { get; set; }
        public List<string> Reasons { get; set; } = new List<string>();
    }

    public class FluentResultReason
    {
        public string? Message { get; set; }
    }

    public class FluentResultForGetCity
    {
        public bool IsFailed { get; set; }
        public bool IsSuccess { get; set; }
        public List<FluentResultReason> Reasons { get; set; } = new List<FluentResultReason>();
        public List<FluentResultError> Errors { get; set; }= new List<FluentResultError>();
        public List<FluentResultSuccess> Successes { get; set; } = new List<FluentResultSuccess>();
        public string[]? Value { get; set; }
    }
}
