const normalizerStrategies = require('./strategies')

class NormalizerManager {
  constructor (strategies) {
    this.strategies = strategies
  }
  /**
   * @param {*} data content to be normalized
   * @param {*} format type of data being introduced (csv, json, xml...)
   * @param {*} model Class of the model to be instantiated
   * @param {*} config configuration of the fields to be normalized
   */
  normalize (data, format, model, config) {
    for (let i = 0, n = this.strategies.length; i < n; i++) {
      if (this.strategies[i].canNormalize(format)) {
        return this.strategies[i].normalize(data, model, config)
      }
    }
    throw new Error(`There is no normalizer implemented for '${format}' data type`)
  }
}

const strategySingletons = Object.values(normalizerStrategies).map(Strategy => new Strategy())
const normalizeManagerSingleton = new NormalizerManager(strategySingletons)

module.exports = normalizeManagerSingleton
