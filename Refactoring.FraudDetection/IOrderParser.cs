namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public interface IOrderParser
    {
        FraudRadar.Order Parse(string order); 
    }
}
