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
            var state = order.State;
            if (string.IsNullOrWhiteSpace(state))
                return;
            state = state.ToLower().Trim();

            if (state == "il")
            {
                order.State = "illinois";
                return;
            }
            if (state == "ca")
            {
                order.State = "california";
                return;
            }
            if (state == "ny")
            {
                order.State = "new york";
                return;
            }
        }
    }
}
