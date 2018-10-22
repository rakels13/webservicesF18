const player = require('../data/db').Player;

module.exports = {
  queries: {
    allPlayers: () => {
      return player.find({}, (err, players) => {
        if (err) {throw new Error(err);}
        return players;
      });
    },
    player: (parent, args) => {
      player.findById(args, (err, player) => {
        if (err) {throw new Error(err);}
        return player;
      });
    }
  }
};
