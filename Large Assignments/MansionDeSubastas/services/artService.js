const EventEmitter = require('events');
const Art = require('../data/db');

class ArtService extends EventEmitter {
    constructor() {
        super();
        this.events = {
            GET_ALL_ARTS: 'GET_ALL_ARTS',
            GET_ART_BY_ID: 'GET_ART_BY_ID',
            CREATE_ART: 'CREATE_ART'
        };
    }
    getAllArts() {
        // Your implementation goes here
        // Should emit a GET_ALL_ARTS event when the data is available
        Art.find({}, (err, arts) => {
          if (err) {throw new Error(err);}
          
          return(arts);
        });
    };

    getArtById(id) {
        // Your implementation goes here
        // Should emit a GET_ART_BY_ID event when the data is available
    };

    createArt(art) {
        // Your implementation goes here
        // Should emit a CREATE_ART event when the data is available
    };
};

module.exports = ArtService;
