const mongoose = require('mongoose');
const sharkSchema = require('../schemas/sharkSchema');
const attackSchema = require('../schemas/attackSchema');
const areaSchema = require('../schemas/areaSchema');

const connection = mongoose.createConnection('mongodb://veftc8:vefth18@ds125713.mlab.com:25713/c8-spy-on-shark', {
    useNewUrlParser: true
});

module.exports = {
    Shark: connection.model('Shark', sharkSchema),
    Attack: connection.model('Attack', attackSchema),
    Area: connection.model('Area', areaSchema),
    connection
};
