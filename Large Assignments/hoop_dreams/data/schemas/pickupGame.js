const Schema = require('mongoose').Schema;

module.exports = new Schema({
  start: { type: String, required: true},
  end: { type: String, required: true},
  location: { type: String, required: true},
  registaredPlayers: { type: [String], required: true },
  host: { type: String, required: true},
});
