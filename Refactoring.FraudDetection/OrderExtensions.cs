using System;
using System.Collections.Generic;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public static class OrderExtensions
    {
        public static IEnumerable<FraudRadar.Order> Apply(this IEnumerable<FraudRadar.Order> orders,
            IOrderModifier logic)
        {
            if (orders == null)
                throw new ArgumentNullException("orders");

            foreach(var order in orders)
            {
                logic.Modify(order);
                yield return order;
            } 
        }
    }
}
