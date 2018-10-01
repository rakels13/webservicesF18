const pinatas = require('../data/pinatas').pinatas;

const pinataService = () => {
    //getAll
    const getAllPinatas = () => {
      const pinatasToReturn = [];
      pinatas.forEach(function(element) {
        pinatasToReturn.push(new returnPinata(element.id, element.name, element.maximumHits, 0));
      });
      return pinatasToReturn;
    };

    function returnPinata(id, name, maximumHits, currentHits) {
        this.id = id;
        this.name = name;
        this.maximumHits = maximumHits;
        this.currentHits = currentHits;
    };

    //getId
    const getPinataById = (id) => {
      const pinata = pinatas.filter(p => p.id == id);
      if (pinata.length === 0){ return -1; }
      var pin = pinata[0];
      const pinataToReturn = new returnPinata(pin.id, pin.name, pin.maximumHits, 0);
      return pinataToReturn;
    };

    function returnPinata(id, name, maximumHits, currentHits) {
        this.id = id;
        this.name = name;
        this.maximumHits = maximumHits;
        this.currentHits = currentHits;
    };
    //create
    const createPinata = (pinata) => {
      let highId = 0;
      pinatas.forEach(c => { if (p.id > highId) { highId = p.id; }});
      pinata.id = highId + 1;
      pinatas.push(pinata);
    };
    //hit
    /*const hitPinata = (id, pinata) => {

    }*/


    return {
      getAllPinatas,
      getPinataById,
      createPinata
    };
};

module.exports = pinataService();
