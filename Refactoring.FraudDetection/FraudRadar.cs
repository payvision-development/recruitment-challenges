// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    using System.Collections.Generic;

    public class FraudRadar
    {
        public IEnumerable<FraudResult> Check(IEnumerable<Order> input)
        {
            var fraudResults = new List<FraudResult>();

            var orders = new List<Order>(input);
            // CHECK FRAUD
            for (int i = 0; i < orders.Count; i++)
            {
                for (int j = i + 1; j < orders.Count; j++)
                {
                    if (IsFraudulent(orders[i], orders[j]))
                    {
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = orders[j].OrderId });
                    }
                }
            }

            return fraudResults;
        }

        private bool IsFraudulent(Order first, Order second)
        {
            if (first.DealId == second.DealId
                        && first.Email == second.Email
                        && first.CreditCard != second.CreditCard)
                return true;

            if (first.DealId == second.DealId
                && first.State == second.State
                && first.ZipCode == second.ZipCode
                && first.Street == second.Street
                && first.City == second.City
                && first.CreditCard != second.CreditCard)
                return true;

            return false;
        }

        public class FraudResult
        {
            public int OrderId { get; set; }

            public bool IsFraudulent { get; set; }
        }

        public class Order
        {
            public int OrderId { get; set; }

            public int DealId { get; set; }

            public string Email { get; set; }

            public string Street { get; set; }

            public string City { get; set; }

            public string State { get; set; }

            public string ZipCode { get; set; }

            public string CreditCard { get; set; }
        }
    }
}