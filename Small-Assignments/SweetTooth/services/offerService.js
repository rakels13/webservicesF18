const offers = require('../data/offers').offers;
const candyService = require('./candyService');

const offerService = () => {
    const getAllOffers = () => {
      // constructing a new element/offer
      function returnOffer(id, name, candies) {
          this.id = id;
          this.name = name;
          const newCandies = [];
          candies.forEach(function(element) {
            newCandies.push(candyService.getCandyById(element));
          });
          this.candies = newCandies;
      };

      const  returnOffers = [];

      offers.forEach(function(element) {
        returnOffers.push(new returnOffer(element.id, element.name, element.candies));
        console.log(element.candies);
      });
      return returnOffers;

      /*const { id, name, candies} = offer;
      offers.forEach((offer, ind, offerArray) => {
        const currentOffer = offerArray[index];
        currentOffer.forEach((element, ind, myArr) => {
          console.log(myArr[ind]);
        });

      });*/
    };

    return {
      getAllOffers
    };
};

module.exports = offerService();
