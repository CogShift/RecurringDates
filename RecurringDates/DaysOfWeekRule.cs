using System;
using System.Collections.Generic;
using System.Linq;
using RecurringDates.Helpers;

namespace RecurringDates
{
    public class DaysOfWeekRule : BaseRule, IHasAlternateRules
    {
        private readonly SetUnionRule _rule;

        public IEnumerable<DayOfWeek> DaysOfWeek { get; private set; }

        public DaysOfWeekRule(params DayOfWeek[] daysOfWeek)
            : this((IEnumerable<DayOfWeek>) daysOfWeek)
        {
        }

        public DaysOfWeekRule(IEnumerable<DayOfWeek> daysOfWeek)
        {
            var daysOfWeekArray = daysOfWeek as DayOfWeek[] ?? daysOfWeek.ToArray();
            DaysOfWeek = daysOfWeekArray;
            _rule = new SetUnionRule()
            {
                Rules = daysOfWeekArray.Select(day => new DayOfWeekRule(day))
            };
        }

        public override bool IsMatch(DateTime day)
        {
            return _rule.IsMatch(day);
        }

        public override string GetDescription()
        {
            return DaysOfWeek.StringJoin(" or ");
        }

        public IEnumerable<IRule> Rules
        {
            get { return _rule.Rules; }
            set { _rule.Rules = value; }
        }
    }
}