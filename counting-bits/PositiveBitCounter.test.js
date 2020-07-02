const PositiveBitCounter = require('./PositiveBitCounter')
const assert = require('assert')

describe('PositiveBitCounter', function () {
  it('Should return a RangeError when a negative value is supplied', function () {
    assert.throws(
      () => PositiveBitCounter.Count(-2),
      function isRangeError (error) {
        return (error instanceof RangeError)
      })
  })

  it('Should return zero occurrences for input = 0', function () {
    const expected = [0]
    const actual = PositiveBitCounter.Count(0)
    assert.deepEqual(actual, expected)
  })

  it('Should return the expected count for input = 1', function () {
    const expected = [1, 0]
    const actual = PositiveBitCounter.Count(1)
    assert.deepEqual(actual, expected)
  })

  it('Should return the expected count for input = 161', function () {
    const expected = [3, 0, 5, 7]
    const actual = PositiveBitCounter.Count(161)
    assert.deepEqual(actual, expected)
  })
})
