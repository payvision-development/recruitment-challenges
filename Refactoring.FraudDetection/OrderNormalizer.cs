namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public static class OrderNormalizer
    {
        private static readonly IOrderModifier _defaultNormalizer =
            new EmailNormalizer(new StreetNormalizer(new OrderAddressStateNormalizer(null)));

        public static IOrderModifier Default { get { return _defaultNormalizer; } }
    }
}
