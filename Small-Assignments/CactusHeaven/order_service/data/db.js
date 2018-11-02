const orderSchema = require("./schema/order");
const orderItemSchema = require("./schema/orderItem");
const mongoose = require("mongoose");

const connection = mongoose.createConnection(
  "mongodb://s4:cactus123@ds227939.mlab.com:27939/cactus_heaven",
  {
    useNewUrlParser: true
  }
);

module.exports = {
  Order: connection.model("Order", orderSchema),
  OrderItem: connection.model("OrderItem", orderItemSchema)
};
