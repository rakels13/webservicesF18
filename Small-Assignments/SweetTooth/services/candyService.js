const candies = require('../data/candies').candies;

const candyService = () => {
    // get all candies
    const getAllCandies = () => candies;

    // get candy by Id
    const getCandyById = (id) => {
      // find the right candy
      const candy = candies.filter(c => c.id == id);
      // return if not found
      if (candy.length === 0){ return -1; }
      // return the candy
      return candy[0];
    };

    // create new candy
    const createCandy = (candy) => {
      // variable to hold the highest id
      let highId = 0;
      // looping through and determine the highest Id
      candies.forEach(c => { if (c.id > highId) { highId = c.id; }});
      // give the new candy id one higher than the highest
      candy.id = highId + 1;
      // add the candy to the data
      candies.push(candy);
      // returning the newly created candy
      return new returnCandy(candy.id, candy.name, candy.description);
    };

    // constructing a copy of candy to return
    function returnCandy(id, name, description) {
        this.id = id;
        this.name = name;
        this.description = description;
    };

    return {
      getAllCandies,
      getCandyById,
      createCandy
    };
};

module.exports = candyService();
