const BasketballFieldClosedError = require('../errors.js').BasketballFieldClosedError;
const PickupGameExceedMaximumError = require('../errors.js').PickupGameExceedMaximumError;

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
    pickupGame: (parent, args, context) => {
      return context.pickupGame.findById(args.id, (err, game) => {
        if (err) {throw new Error(err);}
        return game;
      });
    }
  },
  types: {
    PickupGame: {
      location: (parent, args, context) => {
        return context.basketballFieldService.getBasketballFieldById(parent.location);
      },
      registeredPlayers: (parent, args, context) => {
        return context.player.find({id: {$in: parent.registeredPlayers }}, (err, players) => {
          return players;
        });
      },
      host: (parent, args, context) => {
        return context.player.find({host: parent.host}, (err, host) => {
          return host;
        });
      },
    },
  },
  mutations: {
    createPickupGame: async (parent, args, context) => {
        const basketballField = await context.basketballFieldService.getBasketballFieldById(args.input.basketballFieldId);
        const jsonBasketballField = JSON.parse(basketballField);
        if (jsonBasketballField.status === 'CLOSED') {
            throw new BasketballFieldClosedError();
        }
        return context.pickupGame.create({start: args.input.start, end: args.input.end, location: args.input.basketballFieldId, host: args.input.hostId});
    },
    removePickupGame: (parent, args, context) => {
      return new Promise((resolve, reject) => {
        context.pickupGame.deleteOne({"_id": args.id }, (err) => {
          if (err) { reject(err);}
          resolve(true);
        });
      });
    },
    addPlayerToPickupGame: async (parent, args, context) => {

      const game = await context.pickupGame.findById(args.input.pickupGameId);
      const basketballField = await context.basketballFieldService.getBasketballFieldById(game.location);
      const jsonBasketballField = JSON.parse(basketballField);

      if (game.registeredPlayers.lenght === jsonBasketballField.capacity) {
         throw new PickupGameExceedMaximumError();
      }
      
      return new Promise((resolve, reject) => {
        context.player.updateOne({_id: args.input.playerId},
          { $push: {playedGames: args.input.pickupGameId}}, (err) => {
            if (err) { reject(err); }
          });
        context.pickupGame.updateOne({_id: args.input.pickupGameId},
          { $push: {registeredPlayers: args.input.playerId}}, (err, game) => {
            if (err) { reject(err); }
          });
          context.pickupGame.findById(args.input.pickupGameId, (err, game) => {
            if (err) {throw new Error(err);}
            resolve(game);
          });
      });
    },
    removePlayerFromPickupGame: (parent, args, context) => {
      return new Promise((resolve, reject) => {
        context.player.updateOne({_id: args.playerId},
          { $pull: {playedGames: { $in: args.pickupGameId}}}, (err) => {
            if (err) { reject(err); }
          });
        context.pickupGame.updateOne({_id: args.pickupGameId},
          { $pull: {registeredPlayers: { $in: args.playerId}}}, (err, game) => {
            if (err) { reject(err); }
          });
          context.pickupGame.findById(args.pickupGameId, (err, game) => {
            if (err) {throw new Error(err);}
            resolve(game);
          });
      });
    }
  }
};
