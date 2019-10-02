
const {applyNormalizationPipe} = require('../common-normalizers')
class CsvNormalizerStrategy {
  /**
   * Decides if a strategy is applicable
   * @param {*} format format of the data
   */
  canNormalize (format) {
    return format === 'csv'
  }
  /**
   * @param {*} data data to be normalized
   * @param {*} config config of the columns
   * @param {*} model desired object to be instantiated
   */
  normalize (data, config, model) {
    return data.split('\n').map(line => this.csvLineNormalizer(line, config, model))
  }

  csvLineNormalizer (line, Model, config) {
    const cols = line.split(',')
    if (cols.length !== config.length) {
      const expectedColumns = config.map(col => col.prop).join(', ')
      throw new Error(`CSV line expects to have ${config.length} columns. But ${cols.length} were found. The columns are the following:\n${expectedColumns}`)
    }
    const obj = new Model()
    // Set each obj property from the columns normalizing when necessary
    cols.forEach((value, index) => {
      const colConfig = config[index]
      if (colConfig.normalizationPipe) {
        value = applyNormalizationPipe(value, colConfig.normalizationPipe)
      }
      obj[colConfig.prop] = value
    })
    return obj
  }
}

module.exports = CsvNormalizerStrategy
