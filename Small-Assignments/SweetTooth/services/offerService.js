const offers = require('../data/offers').offers;
const candyService = require('./candyService');

const offerService = () => {
    const getAllOffers = () => {
      // constructing a new element/offer
      function returnOffer(id, name, candies) {
          this.id = id;
          this.name = name;
          //New array to hold candies in offer
          const newCandies = [];
          candies.forEach(function(element) {
            newCandies.push(candyService.getCandyById(element));
          });
          this.candies = newCandies;
      };
      // Constructing a new array to return all the offers
      const  returnOffers = [];

      offers.forEach(function(element) {
        // Populating the array with the offers from data
        returnOffers.push(new returnOffer(element.id, element.name, element.candies));
        //console.log(element.candies);
      });
      return returnOffers;
    };

    return {
      getAllOffers
    };
};

module.exports = offerService();
