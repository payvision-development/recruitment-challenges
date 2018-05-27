using System.Collections.Generic;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Interfaces
{
    public interface IOrderProcessProvider
    {
        List<FraudRadar.Order> GetOrderList(string[] initialLines);
    }
}
