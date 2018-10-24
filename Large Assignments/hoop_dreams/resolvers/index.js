const { GraphQLScalarType } = require('graphql');
const playerResolver = require('./playerResolver');
const pickupGameResolver = require('./pickupGameResolver');
const basketballFieldResolver = require('./basketballFieldResolver');
const moment = require('moment');


//Moment.locale('is');
//Moment().format('llll');
const Moment = new GraphQLScalarType({
  name: 'Moment',
  description: 'Parsing date and time with Moment',
  serialize(value) {
    // Implement your own behavior here by setting the 'result' variable
    return new moment(value);
  },
  parseValue(value) {
    // Implement your own behavior here by setting the 'result' variable
    return value.moment();
  },
  parseLiteral(ast) {
    return new moment(ast.value);
      // Implement your own behavior here by returning what suits your needs
      // depending on ast.kind
  }
});

module.exports = {
  Query: {
    ...playerResolver.queries,
    ...pickupGameResolver.queries,
    ...basketballFieldResolver.queries
  },
  Moment
};
