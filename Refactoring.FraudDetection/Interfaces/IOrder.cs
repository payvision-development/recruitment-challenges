// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
    public interface IOrder
    {
        string City { get; set; }
        string CreditCard { get; set; }
        int DealId { get; set; }
        string Email { get; set; }
        int OrderId { get; set; }
        string State { get; set; }
        string Street { get; set; }
        string ZipCode { get; set; }


    }
}