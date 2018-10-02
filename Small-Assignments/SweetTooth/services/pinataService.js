const pinatas = require('../data/pinatas').pinatas;

const pinataService = () => {
    //getAllPinatas
    const getAllPinatas = () => {
      // cosntructing an array to return pinatas
      const pinatasToReturn = [];
      // populating the return array with pinatas from data folder without surprise property
      pinatas.forEach(function(element) {
        pinatasToReturn.push(new returnPinata(element.id, element.name, element.maximumHits, element.currentHits));
      });
      // returning the array contain all pinatast
      return pinatasToReturn;
    };

    // constructor function to copy information from pinatas to new pinata propert excluding surprise
    function returnPinata(id, name, maximumHits, currentHits) {
        this.id = id;
        this.name = name;
        this.maximumHits = maximumHits;
        this.currentHits = currentHits;
    };

    //get pinata by id
    const getPinataById = (id) => {
      // finding the right pinata
      const pinata = pinatas.filter(p => p.id == id);
      // return if pinata not found
      if (pinata.length === 0){ return -1; }
      // picking out the pinata we need
      var pin = pinata[0];
      // constructing a new pinata without surprise property
      const pinataToReturn = new returnPinata(pin.id, pin.name, pin.maximumHits, pin.currentHits);
      // return the pinata
      return pinataToReturn;
    };

    //create
    const createPinata = (pinata) => {
      // setting a variable to hold the highest ID in the data
      let highId = 0;
      // looping through the data to determine the highest Id
      pinatas.forEach(p => { if (p.id > highId) { highId = p.id; }});
      // The id for the new pinata is one higher than the highest
      pinata.id = highId + 1;
      // Add the new pinata to the data(repository)
      pinatas.push(pinata);
      // returning the newly created pinata
      return new returnPinata(pinata.id, pinata.name, pinata.maximumHits, pinata.currentHits);
    };

    //hit pinata
    const hitPinata = (id) => {
      // find the pinata that is getting hit
      var pinata = getPinataWithSurprise(id);
      // checking if the pinata is still available to hit
      if( pinata.currentHits < pinata.maximumHits-1) {
        pinata.currentHits = pinata.currentHits +1;
        return "hit";
      }
      // checking if this is the hit that ends in surprise
      else if (pinata.currentHits === pinata.maximumHits-1) {
        pinata.currentHits = pinata.currentHits +1;
        return pinata.surprise;
      }
      // locking the pinata
      return "lock";
    };

    // getting a pinata with the surprise property
    const getPinataWithSurprise = (id) => {
      // finding the right pinata to return
      const pinata = pinatas.filter(p => p.id == id);
      // returning if no pinata found
      if (pinata.length === 0){ return -1; }
      // return the pinata
      return pinata[0];
    };

    return {
      getAllPinatas,
      getPinataById,
      createPinata,
      hitPinata
    };
};

module.exports = pinataService();
