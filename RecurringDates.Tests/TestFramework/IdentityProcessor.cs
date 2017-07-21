namespace RecurringDates.Tests
{
    class IdentityProcessor : IRuleProcessor
    {
        public U Process<U>(U rule) where U : IRule
        {
            return rule;
        }
    }
}