namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    /// <summary>
    /// A "wrapper/decorator"
    /// </summary>
    public class StreetNormalizer : IOrderModifier
    {
        private readonly IOrderModifier _followingModifier;

        public StreetNormalizer(IOrderModifier followingModifier)
        {
            _followingModifier = followingModifier;
        }

        public void Modify(FraudRadar.Order order)
        {
            ModifyStreet(order);
            if (_followingModifier != null)
                _followingModifier.Modify(order);
        }

        private void ModifyStreet(FraudRadar.Order order)
        {
            //Normalize street
            order.Street = order.Street.Replace("st.", "street").Replace("rd.", "road");
        }
    }
}
