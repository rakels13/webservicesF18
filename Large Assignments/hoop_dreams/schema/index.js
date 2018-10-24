const enums = require('./enums');
const input = require('./input');
const queries = require('./queries');
const scalar = require('./scalar');
const types = require('./types');

module.exports = `
  ${enums}
  ${input}
  ${queries}
  ${scalar}
  ${types}
`;
