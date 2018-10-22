const mongoose = require('mongoose');
const playerSchema = require('./schemas/player');
const pickupGamesSchema = require('./schemas/pickupGame');

const connection = mongoose.createConnection('mongodb://vefth18:veft123@ds237363.mlab.com:37363/hoop_dreams', { useNewUrlParser: true });

module.exports = {
    Player: connection.model('Player', playerSchema),
    PickupGames: connection.model('PickupGames', pickupGamesSchema),
    connection
};
