module.exports = {
  queries: {
    allPlayers: (parent, args, context) => {
      return context.player.find({}, (err, players) => {
        if (err) { throw new Error(err); }
        return players;
      });
    },
    player: (parent, args, context) => {
      return context.player.findById(args.id, (err, player) => {
        if (err) { throw new Error(err); }
        return player;
      });
    },
  },
  types: {
    Player: {
      playedGames: (parent, args, context) => {
        return context.pickupGame.find({id: {$in: parent.playedGames }}, (err, games) => {
          return games;
        });
      }
    }
  },
  mutations: {
    createPlayer: (parent, args, context) => {
      return context.player.create({
        name: args.input.name
      });
    },
    updatePlayer: (parent, args, context) => {
      return new Promise((resolve, reject) => {
        context.player.findById(args.id, (err, player ) => {
          if (err) { reject(err); }
          player.name = args.input.name;
          player.save();
          resolve(player);
        });
      });
    },
    removePlayer: (parent, args, context) => {
      return new Promise((resolve, reject) => {
        context.player.deleteOne({"_id" : args.id}, (err) => {
          if (err) { reject(err); }
          resolve(true);
        })
      })
    }
  }
};
