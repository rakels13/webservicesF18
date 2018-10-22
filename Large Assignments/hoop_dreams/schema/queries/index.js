//// TODO: add to qurey allBasketballFields
/*Should return a collection of all basketball fields. Contains a
field argument called status which is of type BasketballFieldStatus (enum) and should
be used to filter the data based on the status of the basketball field*/
module.exports = `
  type Query {
    allBasketballFields(status: BasketballFieldStatus): [BasketballField!]!
    allPickupGames: [PickupGame!]!
    allPlayers: [Player!]!
    basketballField(id: Int!): BasketballField!
    pickupGame(id: Int!): PickupGame!
    player(id: Int!): Player!
  }
`;
