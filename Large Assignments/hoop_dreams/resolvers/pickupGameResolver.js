module.exports = {
  queries: {
    allPickupGames: (parent, args, context) => {
      return new Promise((resolve, reject) => {
        context.pickupGame.find({}, (err, games) => {
          if (err) {
            reject(err);
          }
          resolve(games);
        });
      });
    },
    pickupGame: (parent, args) => {
      return context.pickupGame.findById(args.id, (err, game) => {
        if (err) {throw new Error(err);}
        return game;
      });
    }
  }
};
