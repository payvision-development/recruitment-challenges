const {streetReplacements, stateReplacements} = require('../configs/common.normalizer.config')

function replaceByMap (string, map) {
  for (let search in map) {
    string = string.replace(search, map[search])
  }
  return string
}
function num (n) {
  return Number(n)
}
function lowercase (str) {
  return str.toLowerCase()
}
function email (email) {
  return email.replace(/\+.+@/g, '@')
}

function street (street) {
  return replaceByMap(street, streetReplacements)
}

function state (state) {
  return replaceByMap(state, stateReplacements)
}

const normalizers = {state, street, email, num, lowercase}

function applyNormalizationPipe (value, pipe) {
  if (!Array.isArray(pipe)) {
    throw new Error('Column map normalizationPipe must be an array')
  }

  pipe.forEach(name => {
    if (typeof normalizers[name] === 'undefined') {
      throw new Error(`There is no common normalizer named '${name}'`)
    }
    if (typeof normalizers[name] !== 'function') {
      throw new Error(`The normalizer for '${name}' is not a function`)
    }
    value = normalizers[name](value)
  })
  return value
}

module.exports = { normalizers, applyNormalizationPipe }
