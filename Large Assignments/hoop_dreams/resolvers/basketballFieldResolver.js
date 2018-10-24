const basketballFieldService = require('../services/basketballFieldService.js');

module.exports = {
  queries: {
    allBasketballFields: () => {
      return basketballFieldService.getAllBasketballFields();
    },
    basketballField: (parent, args) => {
      return basketballFieldService.getBasketballFieldById(args.id);
    }
  }
};
