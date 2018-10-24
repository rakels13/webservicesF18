const pickupGame = require('../data/db').PickupGame;

module.exports = {
  queries: {
    allPickupGames: () => {
      return new Promise((resolve, reject) => {
        pickupGame.find({}, (err, games) => {
          if (err) {
            reject(err);
          }
          resolve(games);
        });
      });
    },
    pickupGame: (parent, args) => {
      return pickupGame.findById(args.id, (err, game) => {
        if (err) {throw new Error(err);}
        return game;
      });
    }
  }
};
