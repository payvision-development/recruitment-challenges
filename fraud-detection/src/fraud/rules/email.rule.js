module.exports = function emailFraudRule (current, order) {
  return (
    current.dealId === order.dealId &&
    current.email === order.email &&
    current.creditCard !== order.creditCard
  )
}

