using System;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class CsvRecordOrderParser : IOrderParser
    {
        public FraudRadar.Order Parse(string order)
        {
            if (string.IsNullOrEmpty(order))
                throw new ArgumentException("An order string should not be null or empty.");

            var items = order.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (items.Length != 8)
                throw new ArgumentException("The order argument should contain 8 values delimetered by a comma.");

            return new FraudRadar.Order
            {
                OrderId = int.Parse(items[0]),
                DealId = int.Parse(items[1]),
                Email = items[2].ToLower(),
                Street = items[3].ToLower(),
                City = items[4].ToLower(),
                State = items[5].ToLower(),
                ZipCode = items[6],
                CreditCard = items[7]
            };
        }
    }
}
