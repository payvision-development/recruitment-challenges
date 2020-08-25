// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{

    public class Order : IOrder
    {
        public int OrderId { get; set; }

        public int DealId { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string CreditCard { get; set; }
        public Order(int orderId, int dealId,
                     string email, string street,
                     string city, string state,
                     string zipCode, string creditCard)
        {
            OrderId = orderId;
            DealId = dealId;
            Email = email;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            CreditCard = creditCard;
        }


    }

}