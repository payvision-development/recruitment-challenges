using System.Collections.Generic;

namespace Refactoring.FraudDetection
{
    public interface IOrderService
    {
        IEnumerable<Order> LoadOdersFromFile(string filePath);
    }
}