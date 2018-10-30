module.exports = `
  type Mutation {
    createPickupGame(input: PickupGameInput!): PickupGame!
    createPlayer(input: PlayerInput!): Player!
    updatePlayer(id: ID! input: PlayerInput!): Player!
    removePickupGame(id: ID!): Boolean!
    removePlayer(id: ID!): Boolean!
    addPlayerToPickupGame(input: SignupPlayerInput!): PickupGame!
    removePlayerFromPickupGame(playerId: ID! pickupGameId: ID!): PickupGame!
  }
`;
