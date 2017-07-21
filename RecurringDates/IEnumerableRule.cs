using System;
using System.Collections.Generic;


namespace RecurringDates
{
    public interface IEnumerableRule : IRule
    {
        IEnumerable<DateTime> MatchingDates { get; }
    }
}