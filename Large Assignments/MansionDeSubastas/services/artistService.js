const EventEmitter = require('events');
const Artist = require('../data/db').Artist;

class ArtistService extends EventEmitter {
    constructor() {
        super();
        this.events = {
            GET_ALL_ARTISTS: 'GET_ALL_ARTISTS',
            GET_ARTIST_BY_ID: 'GET_ARTIST_BY_ID',
            CREATE_ARTIST: 'CREATE_ARTIST'
        };
    }
    getAllArtists() {
        // Your implementation goes here
        // Should emit a GET_ALL_ARTISTS event when the data is available
        Artist.find({}, (err, artists) => {
          if (err) { throw new Error(err); }
          this.emit(this.events.GET_ALL_ARTISTS, artists);
        });
    };

    getArtistById(id) {
        // Your implementation goes here
        // Should emit a GET_ARTIST_BY_ID event when the data is available
        Artist.findById(id, (err, artist) => {
          if (err) { throw new Error(err); }
          this.emit(this.events.GET_ARTIST_BY_ID, artist);
        });
    };

    createArtist(artist) {
        // Your implementation goes here
        // Should emit a CREATE_ARTIST event when the data is available
        Artist.create({
          name: artist.name,
          nickname: artist.nickname,
          address: artist.address,
          memberSince: artist.memberSince
        }, err => {
          if (err) { throw new Error(err); }
          this.emit(this.events.CREATE_ARTIST, artist);
        });
    };
};

module.exports = ArtistService;
