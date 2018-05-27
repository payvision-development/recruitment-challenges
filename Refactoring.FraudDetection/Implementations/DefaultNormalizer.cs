using Payvision.CodeChallenge.Refactoring.FraudDetection.Interfaces;
using System;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Implementations
{
    public class DefaultNormalizer : INormalizeProvider
    {
        public string NormalizeEmail(string basicEmail)
        {
            //Normalize email
            var aux = basicEmail.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }

        public string NormalizeState(string basicState)
        {
            //Normalize state
            return basicState.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
        }

        public string NormalizeStreet(string basicStreet)
        {
            //Normalize street
            return basicStreet.Replace("st.", "street").Replace("rd.", "road");
        }
    }
}
