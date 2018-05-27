using System;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    /// <summary>
    /// A "wrapper/decorator"
    /// </summary>
    public class EmailNormalizer : IOrderModifier
    {
        private readonly IOrderModifier _followingModifier;

        public EmailNormalizer(IOrderModifier followingModifier)
        {
            _followingModifier = followingModifier;
        }

        public void Modify(FraudRadar.Order order)
        {
            ModifyEmail(order);
            if (_followingModifier != null)
                _followingModifier.Modify(order);
        }

        private void ModifyEmail(FraudRadar.Order order)
        {
            //Normalize email
            var aux = order.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            order.Email = string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
