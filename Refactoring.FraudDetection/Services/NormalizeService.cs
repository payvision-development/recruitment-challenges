using System;
using System.Collections.Generic;

namespace Refactoring.FraudDetection
{
    public class NormalizeService : INormalizeService
    {

        private readonly Dictionary<string, string> _stateDictionary = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _streetDictionary = new Dictionary<string, string>();

        public NormalizeService()
        {
            _stateDictionary.Add("il", "illinois");
            _stateDictionary.Add("ca", "california");
            _stateDictionary.Add("ny", "new york");
            _streetDictionary.Add("st.", "street");
            _streetDictionary.Add("rd.", "road");
        }

        public string NormalizeEmail(string email)
        {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return  string.Join("@", new string[] { aux[0], aux[1] });
        }

        public string NormalizeState(string state)
        {
            if (_stateDictionary.ContainsKey(state))
                return _stateDictionary[state];
            return state;
        }

        public string NormalizeStreet(string street)
        {
            string[] splittedStreet = street.Split(new char[] { ' ' });
            for (int i = 0; i < splittedStreet.Length; i++)
            {
                if (_streetDictionary.ContainsKey(splittedStreet[i].ToLower()))
                    splittedStreet[i] = _streetDictionary[splittedStreet[i]];

            }

            return string.Join(' ', splittedStreet);
        }
    }
}
