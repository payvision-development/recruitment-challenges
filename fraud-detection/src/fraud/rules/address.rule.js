module.exports = function addressFraudRule (current, order) {
  return (
    current.dealId === order.dealId &&
    current.state === order.state &&
    current.zipCode === order.zipCode &&
    current.street === order.street &&
    current.city === order.city &&
    current.creditCard !== order.creditCard
  )
}
