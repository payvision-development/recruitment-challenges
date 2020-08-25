namespace Refactoring.FraudDetection
{
    public interface INormalizeService
    {
        string NormalizeEmail(string email);
        string NormalizeStreet(string street);
        string NormalizeState(string state);
    }
}
