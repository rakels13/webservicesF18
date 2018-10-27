module.exports = {
  queries: {
    allBasketballFields: (parent, args, context) => {
      return new Promise((resolve, reject) => {
        const games = context.basketballFieldService.getAllBasketballFields(args.status);
        resolve(games);
      });
    },
    basketballField: (parent, args, context) => {
      return new Promise((resolve, reject) => {
        const games = context.basketballFieldService.getBasketballFieldById(args.id);
        resolve(games);
      });
    },
  },
  types: {
    BasketballField: {
      pickupGames: (parent, args, context) => {
        return context.pickupGame.find({location: parent.id}, (err, games) => {
          return games;
        });
      },
    },
  },
};
