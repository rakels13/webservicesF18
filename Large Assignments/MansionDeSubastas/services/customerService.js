const EventEmitter = require('events');
const Customer = require('../data/db').Customer;
const AuctionBid = require('../data/db').AuctionBid;

class CustomerService extends EventEmitter {
    constructor() {
        super();
        this.events = {
            GET_ALL_CUSTOMERS: 'GET_ALL_CUSTOMERS',
            GET_CUSTOMER_BY_ID: 'GET_CUSTOMER_BY_ID',
            GET_CUSTOMER_AUCTION_BIDS: 'GET_CUSTOMER_AUCTION_BIDS',
            CREATE_CUSTOMER: 'CREATE_CUSTOMER',
            NOT_FOUND: 'NOT_FOUND'
        };
    }
    getAllCustomers() {
      // Finding all customers and emitting the proper event when the data is available
      Customer.find({}, (err, customers) => {
        if (err) { throw new Error(err); }
        if (customers === null) {
          this.emit(this.events.NOT_FOUND, 'No customers found');
          return;
        }
        this.emit(this.events.GET_ALL_CUSTOMERS, customers);
      });
    };

    getCustomerById(id) {
      // Finding customer by given Id and emitting the proper event when found
      Customer.findById(id, (err, customer) => {
        if (err) { throw new Error(err); }
        if (customer === null) {
          this.emit(this.events.NOT_FOUND, 'No customer found by given customerId');
          return;
        }
        this.emit(this.events.GET_CUSTOMER_BY_ID, customer);
      });
    };

    getCustomerAuctionBids(cId) {
      // Finding all bids a customer has made
      AuctionBid.find({ customerId: { $in: cId} }, (err, bids) => {
        if (err) { throw new Error(err); }
        if (bids === null) {
          this.emit(this.events.NOT_FOUND, 'No auctionBids found for given customerId');
          return;
        }
        this.emit(this.events.GET_CUSTOMER_AUCTION_BIDS, bids);
      });
    };

    createCustomer(customer) {
      // Creating new customer and emitting the proper event when it has been created
      Customer.create({
        name: customer.name,
        username: customer.username,
        email: customer.email,
        address: customer.address
      }, err => {
        if (err) { throw new Error(err); }
        this.emit(this.events.CREATE_CUSTOMER, customer);
      });
    };
};

module.exports = CustomerService;
