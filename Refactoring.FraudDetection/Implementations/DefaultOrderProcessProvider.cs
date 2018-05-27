using Payvision.CodeChallenge.Refactoring.FraudDetection.Interfaces;
using System;
using System.Collections.Generic;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Implementations
{
    public class DefaultOrderProcessProvider : IOrderProcessProvider
    {
        private readonly INormalizeProvider _normalizeProvider;

        public DefaultOrderProcessProvider()
        {
            _normalizeProvider = new DefaultNormalizer();
        }

        public DefaultOrderProcessProvider(INormalizeProvider normalizeProvider)
        {
            _normalizeProvider = normalizeProvider;
        }

        public List<FraudRadar.Order> GetOrderList(string[] initialLines)
        {
            List<FraudRadar.Order> sendedOrders = new List<FraudRadar.Order>();

            foreach (var line in initialLines)
            {
                var items = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (DefaultValidatorProvider.CorrectElementsAmount(items))
                {
                    var order = new FraudRadar.Order
                    {
                        OrderId = DefaultValidatorProvider.ValidateToInt(items[0]),
                        DealId = DefaultValidatorProvider.ValidateToInt(items[1]),
                        Email = _normalizeProvider.NormalizeEmail(items[2].ToLower()),
                        Street = _normalizeProvider.NormalizeStreet(items[3].ToLower()),
                        City = items[4].ToLower(),
                        State = _normalizeProvider.NormalizeState(items[5].ToLower()),
                        ZipCode = items[6],
                        CreditCard = items[7]
                    };

                    sendedOrders.Add(order);
                }
            }

            return sendedOrders;
        }

        public static class DefaultValidatorProvider
        {
            public static int ValidateToInt(string value)
            {
                int parsedValue = 0;
                if (int.TryParse(value, out parsedValue))
                {
                    return parsedValue;
                }
                else
                {
                    throw new InvalidCastException(string.Format("Cannot parse into Int32 the value '{0}'", value));
                }
            }

            public static bool CorrectElementsAmount(string[] items)
            {
                bool correctAmount = true;

                if (items.Length < 8)
                {
                    correctAmount = false;
                }

                return correctAmount;
            }

        }
    }
}
