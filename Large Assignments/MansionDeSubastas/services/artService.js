const EventEmitter = require('events');
const Art = require('../data/db').Art;

class ArtService extends EventEmitter {
    constructor() {
        super();
        this.events = {
            GET_ALL_ARTS: 'GET_ALL_ARTS',
            GET_ART_BY_ID: 'GET_ART_BY_ID',
            CREATE_ART: 'CREATE_ART',
            NOT_FOUND: 'NOT_FOUND'
        };
    }
    getAllArts() {
        // Finding all arts and emitting the proper event when the data is available
        Art.find({}, (err, arts) => {
          if (err){ throw new Error(err); }
          this.emit(this.events.GET_ALL_ARTS, arts);
        });
    };

    getArtById(id) {
        // Finding art by the given id and emitting the proper event when it is found
        Art.findById(id, (err, art) => {
          if (err) { throw new Error(err); }
          this.emit(this.events.GET_ART_BY_ID, art);
        });
    };

    createArt(art) {
        // Creating a new art item and emitting the proper event when it has been created
        Art.create({
          title: art.title,
          artistId: art.artistId,
          date: art.date,
          images: art.images,
          description: art.description,
          isAuctionItem: art.isAuctionItem
        }, err => {
          if (err) { throw new Error(err); }
          this.emit(this.events.CREATE_ART, art);
        });
    };
};

module.exports = ArtService;
