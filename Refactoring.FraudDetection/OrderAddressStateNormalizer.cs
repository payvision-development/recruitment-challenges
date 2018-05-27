namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    /// <summary>
    /// A "wrapper/decorator"
    /// </summary>
    public class OrderAddressStateNormalizer : IOrderModifier
    {
        private readonly IOrderModifier _followingModifier;

        public OrderAddressStateNormalizer(IOrderModifier followingModifier)
        {
            _followingModifier = followingModifier;
        }

        public void Modify(FraudRadar.Order order)
        {
            ModifyState(order);
            if (_followingModifier != null)
                _followingModifier.Modify(order);
        }

        private void ModifyState(FraudRadar.Order order)
        {
            //Normalize state
            order.State = order.State.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
        }
    }
}
