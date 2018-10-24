const request = require("request");

const basketballFieldService = () => {

  var url = "http://basketball-fields.herokuapp.com/api/basketball-fields/";

  const getAllBasketballFields = () => {
    return new Promise((resolve, reject) => {
      request.get(url, (err, res, body) => {
          if(err) {
              reject(err);
          }
          resolve(JSON.parse(body));
      });
    });
  }

  const getBasketballFieldById = (id) => {
    console.log("bfield id " + id);
    url = url + id;
    return new Promise((resolve, reject) => {
      request.get(url, (err, res, body) => {
        console.log("bfield is")
          console.log(body);
          if(err) {
              reject(err);
          }
          resolve(JSON.parse(body));
      });
    });
  }

  return {
    getAllBasketballFields,
    getBasketballFieldById
  };
};

module.exports = basketballFieldService();
