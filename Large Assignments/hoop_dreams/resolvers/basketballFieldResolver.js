module.exports = {
  queries: {
    allBasketballFields: (parent, args, context) => {
      return context.basketballFieldService.getAllBasketballFields();
    },
    basketballField: (parent, args, context) => {
      return context.basketballFieldService.getBasketballFieldById(args.id);
    }
  }
};
