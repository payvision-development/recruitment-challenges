const fs = require('fs')
const normalizer = require('./normalizer/NormalizerManager')
const { Order } = require('./models/Order')
const {orderCsvColumnConfig} = require('./configs/order.normalizer.config')
const { FraudRadar } = require('./fraud/FraudRadar')

function Check (filePath) {
  if (!fs.existsSync(filePath)) {
    throw new Error(`File doesn't exists in the given path: ${filePath}`)
  }

  const fileContent = fs.readFileSync(filePath, 'utf8')
  const orders = normalizer.normalize(fileContent, 'csv', Order, orderCsvColumnConfig)
  const fraudRadar = new FraudRadar(orders)

  return fraudRadar.analyze().getResults()
}

module.exports = { Check }
