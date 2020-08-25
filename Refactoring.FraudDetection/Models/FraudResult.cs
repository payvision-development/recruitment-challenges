// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
 
        public class FraudResult
        {
            public int OrderId { get; set; }

            public bool IsFraudulent { get; set; }
            public FraudResult(int OrderId, bool IsFraudulent)
            {
                     this.OrderId = OrderId;
                     this.IsFraudulent = IsFraudulent;
            }
        }

}