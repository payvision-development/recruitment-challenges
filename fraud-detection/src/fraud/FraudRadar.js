const fraudRules = require('./rules')

class FraudRadar {
  constructor (orders) {
    this.orders = orders
    this.rules = Object.values(fraudRules)
    this.results = []
  }

  analyze () {
    let current, order, isFraudulent
    for (let i = 0, nOrders = this.orders.length; i < this.orders.length; i++) {
      current = this.orders[i]

      for (let j = i + 1; j < nOrders; j++) {
        order = this.orders[j]
        // With find we stop checking on the first rule match
        isFraudulent = typeof this.rules.find(rule => rule(current, this.orders[j])) !== 'undefined'
        if (isFraudulent) {
          this.results.push({isFraudulent, orderId: order.orderId})
        }
      }
    }
    return this
  }

  getResults () {
    return this.results
  }
}

module.exports = { FraudRadar }
