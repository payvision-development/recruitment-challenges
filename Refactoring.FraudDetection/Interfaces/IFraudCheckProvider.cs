using System.Collections.Generic;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Interfaces
{
    public interface IFraudCheckProvider
    {
        IEnumerable<FraudRadar.FraudResult> Check(List<FraudRadar.Order> orders);
    }
}
