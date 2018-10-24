const { ApolloServer } = require('apollo-server');
const typeDefs = require('./schema');
const resolvers = require('./resolvers');
const player = require('./data/db').Player;
const pickupGame = require('./data/db').PickupGame;

const server = new ApolloServer({
  typeDefs,
  resolvers,
  context: {
    player,
    pickupGame
  }
    /*
        Add typeDefs
        Add resolvers
    */
});

server.listen()
    .then(({ url }) => console.log(`GraphQL Service is running on ${ url }`));
