const amqp = require("amqplib/callback_api");
const Order = require("./data/db").Order;
const OrderItem = require("./data/db").OrderItem;

const messageBrokerInfo = {
  exchanges: {
    order: "order_exchange"
  },
  queues: {
    orderQueue: "order_queue"
  },
  routingKeys: {
    createOrder: "create_order"
  }
};

const createMessageBrokerConnection = () =>
  new Promise((resolve, reject) => {
    amqp.connect(
      "amqp://localhost",
      (err, conn) => {
        if (err) {
          reject(err);
        }
        resolve(conn);
      }
    );
  });

const createChannel = connection =>
  new Promise((resolve, reject) => {
    connection.createChannel((err, channel) => {
      if (err) {
        reject(err);
      }
      resolve(channel);
    });
  });

const configureMessageBroker = channel => {
  const { order } = messageBrokerInfo.exchanges;
  const { orderQueue } = messageBrokerInfo.queues;
  const { createOrder } = messageBrokerInfo.routingKeys;

  channel.assertExchange(order, "direct", { durable: true });
  channel.assertQueue(orderQueue, { durable: true });
  channel.bindQueue(orderQueue, order, createOrder);
};

(async () => {
  const messageBrokerConnection = await createMessageBrokerConnection();
  const channel = await createChannel(messageBrokerConnection);

  configureMessageBroker(channel);

  const { order } = messageBrokerInfo.exchanges;
  const { orderQueue } = messageBrokerInfo.queues;
  const { createOrder } = messageBrokerInfo.routingKeys;

  channel.consume(
    orderQueue,
    data => {
      //parsing the data to work with
      const orderData = JSON.parse(data.content.toString());
      // Calculating the total Price
      var total = 0;
      orderData.items.forEach(element => {
        total += element.unitPrice * element.quantity;
      });
      //Creating the order
      Order.create(
        {
          customerEmail: orderData.email,
          totalPrice: total,
          orderDate: new Date()
        },
        (err, createdOrder) => {
          if (err) {
            throw new Error(err);
          }
          orderData.items.forEach(element => {
            OrderItem.create(
              {
                description: element.description,
                quantity: element.quantity,
                unitPrice: element.unitPrice,
                rowPrice: element.quantity * element.unitPrice,
                orderId: createdOrder._id
              },
              error => {
                if (error) {
                  throw new Error(erro);
                }
              }
            );
          });
        }
      );
      console.log("Order created");
    },
    { noAck: true }
  );
})().catch(e => console.error(e));
