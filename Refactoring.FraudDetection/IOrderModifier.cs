namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public interface IOrderModifier
    {
        void Modify(FraudRadar.Order order);
    }
}
