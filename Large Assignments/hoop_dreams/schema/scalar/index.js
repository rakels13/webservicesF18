const moment = require('moment');

moment.locale('is');
moment().format('llll');

module.exports = `
  scalar Moment
`;
