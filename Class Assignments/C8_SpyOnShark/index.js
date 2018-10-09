const { Area, Shark, Attack, connection } = require('./data/db');
const { TIGER_SHARK, HAMMERHEAD_SHARK, GREAT_WHITE_SHARK, BULL_SHARK } = require('./constants');
const ObjectId = require('mongoose').Types.ObjectId;

// 1.1. Get all sharks
Shark.find({}, (err, sharks) => {
    if (err) { throw new Error(err); }
    console.log('All sharks' + sharks + '\n');
});

// 1.2. Get all tiger sharks
Shark.find({ species: TIGER_SHARK }, (err, shark) => {
    if (err) { throw new Error(err); }
    console.log('All tiger sharks' + shark + '\n');
});

// 1.3. Get all tiger and bull sharks
Shark.find({ species: { $in: [TIGER_SHARK, BULL_SHARK]}}, (err, shark) => {
    if (err) { throw new Error(err); }
    console.log('All tiger and bull sharks' + shark + '\n');
});
// 1.4. Get all sharks except great white sharks
Shark.find({species: { $ne: GREAT_WHITE_SHARK}}, (err, sharks) => {
    if (err) { throw new Error(err); }
    console.log('All sharks except great white sharks:' + sharks + '\n');
});
// 1.5. Get all sharks that have been known to attack
Attack.distinct("sharkId", (err, sharks) => {
  if (err) { throw new Error(err); }
  Shark.find({ _id : { $in: sharks}}, (erro, shark) => {
    if (erro) {throw new Error(erro); }
    console.log('Known attackers:' + shark + '\n')
  });
});
// 1.6. Get all areas with registered attacks
Attack.distinct("areaId", (err, areas) => {
  if (err) { throw new Error(err); }
  Area.find({ _id : { $in: areas}}, (erro, area) => {
    if (erro) {throw new Error(erro); }
    console.log('Areas with registerd attacks:' + area + '\n')
  });
});
// 1.7. Get all areas with more than 5 registered attacks

Attack.aggregate([
  {$group: {_id: "$areaId", count: {$sum: 1}}},
  {$match: { count: {$gt: 5}}}
]).exec((_, area) => {
    Area.find({_id : {$in: area}}, (err, areas) => {
      if (err) {throw new Error(err); }
      console.log('Area with more than 5 registered attacks: ' + areas + '\n');
    });
});
// 1.8. Get the area with the most registered shark attacks
Attack.aggregate([
  {$group: {_id: "$areaId", count: {$sum: 1}}},
  {$match: { $max : "$count"}}
]).exec((_, area) => {
    Area.find({_id : {$in: area}}, (err, areas) => {
      if (err) {throw new Error(err); }
      console.log('Area with most registered attacks: ' + areas + '\n');
    });
});
// 1.9. Get the total count of great white shark attacks
Attack.aggregate([
  {$group: {_id: "$sharkId", count: {$sum: 1}}},
]).exec((_, shark) => {
  Shark.find({_id : {$in: shark}}, {species: GREAT_WHITE_SHARK} , (err, gwshark) => {
    if (err) {throw new Error(err); }
    console.log('Total count or great white shark attacks: ' + $count)
  });
});

// 1.10. Get the total count of hammerhead and tiger shark attacks
