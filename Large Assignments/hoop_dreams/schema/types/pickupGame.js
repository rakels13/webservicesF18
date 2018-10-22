module.exports = `
  type PickupGame {
    id: ID!
    start: Int!
    end: Int!
    location: BasketballField!
    registeredPlayers: [Player!]!
    host: Player!
  }
`;
