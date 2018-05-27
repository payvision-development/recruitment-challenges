
namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Interfaces
{
    public interface INormalizeProvider
    {
        string NormalizeEmail(string basicEmail);

        string NormalizeStreet(string basicStreet);

        string NormalizeState(string basicState);
    }
}
