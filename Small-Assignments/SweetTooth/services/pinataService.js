const pinatas = require('../data/pinatas').pinatas;

const pinataService = () => {
    //getAll
    const getAllPinatas = () => pinatas;
    //getId
    const getPinataById = (id) => {
      const pinata = pinatas.filter(p => p.id == id);
      if (pinata.length === 0){ return -1; }
      return pinata[0];
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
