const EventEmitter = require('events');
const Artist = require('../data/db').Artist;

class ArtistService extends EventEmitter {
    constructor() {
        super();
        this.events = {
            GET_ALL_ARTISTS: 'GET_ALL_ARTISTS',
            GET_ARTIST_BY_ID: 'GET_ARTIST_BY_ID',
            CREATE_ARTIST: 'CREATE_ARTIST',
            NOT_FOUND: 'NOT_FOUND'
        };
    }

    getAllArtists() {
        // Finding all artists and emitting the proper event when the data is available
        Artist.find({}, (err, artists) => {
          if (err) { throw new Error(err); }
          if ( artists === null ) {
            this.emit(this.events.NOT_FOUND, '');
            return;
          }
          this.emit(this.events.GET_ALL_ARTISTS, artists);
        });
    };

    getArtistById(id) {
        // Finding the artist by the given id and emitting the proper event when it is found
        Artist.findById(id, (err, artist) => {
          if (err) { throw new Error(err); }
          if ( artist === null ) {
            this.emit(this.events.NOT_FOUND, '');
            return;
          }
          this.emit(this.events.GET_ARTIST_BY_ID, artist);
        });
    };

    createArtist(artist) {
        // Creating the new artist and emitting the proper event when it has been created
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
