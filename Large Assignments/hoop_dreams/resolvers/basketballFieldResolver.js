module.exports = {
  queries: {
    allBasketballFields: (parent, args, context) => {
      return new Promise((resolve, reject) => {
        const games = context.basketballFieldService.getAllBasketballFields();
        resolve(games);
      });
    },
    /*allBasketballFields: (parent, args, context) => {
      return context.basketballFieldService.getAllBasketballFields();
    },*/
    basketballField: (parent, args, context) => {
      return new Promise((resolve, reject) => {
        const games = context.basketballFieldService.getBasketballFieldById(args.id);
        resolve(games);
      });
    },
    /*basketballField: (parent, args, context) => {
      return context.basketballFieldService.getBasketballFieldById(args.id);
    }*/
  },
  BasketballField: {
    pickupGames: basketballField => {
      return context.pickupGame.find({location: basketballField.id}, (err, games) => {
        return games;
      });
    },
  },
};
