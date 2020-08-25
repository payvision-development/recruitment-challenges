using System.Collections.Generic;

namespace Refactoring.FraudDetection
{
    public interface ICheckFraudSevice
    {
        bool IsFraudOrder(IEnumerable<Order> currentOrders, Order newOrder);
    }
}
