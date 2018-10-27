const request = require("request");

const basketballFieldService = () => {

  var url = "http://basketball-fields.herokuapp.com/api/basketball-fields";

  const getAllBasketballFields = (status) => {
    return new Promise((resolve, reject) => {
      if (status) {
        requestedUrl = url + '?status=' + status;
      }
      else {
        requestedUrl = url;
      }
      console.log(requestedUrl);
      request.get(requestedUrl, (err, res, body) => {
          if(err) {
              reject(err);
          }
          resolve(JSON.parse(JSON.stringify(body)));
      });
    });
  }

  const getBasketballFieldById = (id) => {
    url = url + '/' + id;
    return new Promise((resolve, reject) => {
      request.get(url, (err, res, body) => {
          if(err) {
              reject(err);
          }
          resolve(JSON.parse(JSON.stringify(body)));
      });
    });
  }

  return {
    getAllBasketballFields,
    getBasketballFieldById
  };
};

module.exports = basketballFieldService();
