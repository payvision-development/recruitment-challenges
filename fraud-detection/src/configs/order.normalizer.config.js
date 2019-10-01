const orderCsvColumnConfig = [
  { prop: 'orderId', normalizationPipe: ['num'] },
  { prop: 'dealId', normalizationPipe: ['num'] },
  { prop: 'email', normalizationPipe: ['lowercase', 'email'] },
  { prop: 'street', normalizationPipe: ['lowercase', 'street'] },
  { prop: 'city', normalizationPipe: ['lowercase'] },
  { prop: 'state', normalizationPipe: ['lowercase', 'state'] },
  { prop: 'zipCode' },
  { prop: 'creditCard' }
]

module.exports = {orderCsvColumnConfig}
