const pickupGame = require('../data/db').PickupGame;

module.exports = {
  queries: {
    allPickupGames: () => {
      return pickupGame.find({}, (err, games) => {
        if (err) {throw new Error(err);}
        return games;
      });
    },
    pickupGame: (parent, args) => {
      player.findById(args, (err, game) => {
        if (err) {throw new Error(err);}
        return game;
      });
    }
  }
};
