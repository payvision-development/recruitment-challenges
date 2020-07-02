const FraudRadar = require('./FraudRadar')
const path = require('path')
const assert = require('assert')

describe('Fraud Radar', function () {
  it('Should process the one line file', function () {
    let result = FraudRadar.Check(path.join(__dirname, 'Files', 'OneLineFile.txt'))
    assert.ok(result)
    assert.equal(result.length, 0)
  })

  it('Should process the two line file in which the second is fraudulent', function () {
    let result = FraudRadar.Check(path.join(__dirname, 'Files', 'TwoLines_FraudulentSecond.txt'))
    assert.ok(result)
    assert.equal(result.length, 1)
    assert.equal(result[0].isFraudulent, true)
    assert.equal(result[0].orderId, 2)
  })

  it('Should process the three line file in which the second is fraudulent', function () {
    let result = FraudRadar.Check(path.join(__dirname, 'Files', 'ThreeLines_FraudulentSecond.txt'))
    assert.ok(result)
    assert.equal(result.length, 1)
    assert.equal(result[0].isFraudulent, true)
    assert.equal(result[0].orderId, 2)
  })

  it('Should process the four line file in which more than one order is fraudulent', function () {
    let result = FraudRadar.Check(path.join(__dirname, 'Files', 'FourLines_MoreThanOneFraudulent.txt'))
    assert.ok(result)
    assert.equal(result.length, 2)
  })
})
