const offers = require('../data/offers').offers;
const candies = require('./candyService');

const offerService = () => {
    const getAllOffers = () => {
      const { id, name, candies} = offer;
      offers.forEach((offer, ind, offerArray) => {
        const currentOffer = offerArray[index];
        currentOffer.forEach((element, ind, myArr) => {
          console.log(myArr[ind]);
        });

      });
    };

    return {
      getAllOffers
    };
};

module.exports = offerService();
