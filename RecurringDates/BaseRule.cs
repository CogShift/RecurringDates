using System;


namespace RecurringDates
{
    
    public abstract class BaseRule : IRule
    {
        public abstract bool IsMatch(DateTime day);
        public virtual string GetDescription()
        {
            return this.GetType().Name;
        }

        public override string ToString()
        {
            return GetDescription();
        }
    }
}