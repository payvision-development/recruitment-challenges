// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>
using System.Collections.Generic;
namespace Refactoring.FraudDetection
{


    public class FraudRadar : IFraudRadar
    {
        private readonly ICheckFraudSevice _checkFraudService;

        public FraudRadar(ICheckFraudSevice checkFraudService)
        {
            _checkFraudService = checkFraudService;
        }
        public IEnumerable<FraudResult> Check(IEnumerable<Order> orders)
        {
            var fraudResults = new List<FraudResult>();
            var currentOrders = new List<Order>();
            foreach (var order in orders)
            {
                if (_checkFraudService.IsFraudOrder(currentOrders, order))
                    fraudResults.Add(new FraudResult(order.OrderId, true));
                currentOrders.Add(order);
            }

            return fraudResults;
        }


    }
}