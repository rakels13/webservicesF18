const Schema = require('mongoose').Schema;

module.exports = new Schema({
  name: { type: String, required: true},
  playedGames: { type: [Schema.ObjectId], required: true }
});
