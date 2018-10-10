const EventEmitter = require('events');
const Art = require('../data/db').Art;
const connection = require('../data/db').connection;

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
          if (err){ throw new Error(err); }
          this.emit(this.events.GET_ALL_ARTS, arts);
        });
    };

    getArtById(id) {
        // Your implementation goes here
        // Should emit a GET_ART_BY_ID event when the data is available
        Art.findById(id, (err, art) => {
          if (err) { throw new Error(err); }
          this.emit(this.events.GET_ART_BY_ID, art);
        });
    };

    createArt(art) {
        // Your implementation goes here
        // Should emit a CREATE_ART event when the data is available
    };
};

module.exports = ArtService;
