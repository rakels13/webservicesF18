const playerResolver = require('./playerResolver');
const pickupGameResolver = require('./pickupGameResolver');
module.exports = {
  Query: {
    ...playerResolver.queries,
    ...pickupGameResolver.queries
  }
};
