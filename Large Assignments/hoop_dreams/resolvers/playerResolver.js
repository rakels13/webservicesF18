const player = require('../data/db').Player;

module.exports = {
  queries: {
    allPlayers: () => {
      return player.find({}, (err, players) => {
        if (err) { throw new Error(err); }
        return players;
      });
    },
    player: (parent, args) => {
      console.log("args: " + args.id);
      return player.findById(args.id, (err, player) => {
        if (err) { throw new Error(err); }
        return player;
      });
    }
  }
};
