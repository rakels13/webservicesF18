const candies = require('../data/candies').candies;

const candyService = () => {
    const getAllCandies = () => candies;

    const getCandyById = (id) => {
      const candy = candies.filter(c => c.id == id);
      if (candy.length === 0){ return -1; }
      return candy[0];
    };

    const createCandy = (candy) => {
      let highId = 0;
      candies.forEach(c => { if (c.id > highId) { highId = c.id; }});
      candy.id = highId + 1;
      candies.push(candy);
    };

    return {
      getAllCandies,
      getCandyById,
      createCandy
    };
};

module.exports = candyService();
