const { GraphQLScalarType } = require('graphql');
const playerResolver = require('./playerResolver');
const pickupGameResolver = require('./pickupGameResolver');
const basketballFieldResolver = require('./basketballFieldResolver');
const moment = require('moment');

moment.locale('is');

module.exports = {
  Query: {
    ...playerResolver.queries,
    ...pickupGameResolver.queries,
    ...basketballFieldResolver.queries
  },
  Mutation: {
    ...playerResolver.mutations,
    ...pickupGameResolver.mutations
  },
  ...pickupGameResolver.types,
  ...basketballFieldResolver.types,

  Moment: new GraphQLScalarType({
    name: 'Moment',
    description: 'Parsing date and time with Moment',
    serialize(value) {
      return value;
    },
    parseValue(value) {
      let parseResult = moment(value);
      return parseResult.format('llll');
    },
    parseLiteral(ast) {
      let parseResult = moment(ast.value);
      return parseResult.format('llll');
    }
  })
};
