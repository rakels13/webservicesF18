module.exports = {
  queries: {
    allPlayers: (parent, args, context) => {
      return context.player.find({}, (err, players) => {
        if (err) { throw new Error(err); }
        return players;
      });
    },
    player: (parent, args, context) => {
      console.log("args: " + args.id);
      return context.player.findById(args.id, (err, player) => {
        if (err) { throw new Error(err); }
        return player;
      });
    }
  }
};
