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
            CREATE_CUSTOMER: 'CREATE_CUSTOMER'
        };
    }
    getAllCustomers() {
        // Your implementation goes here
        // Should emit a GET_ALL_CUSTOMERS event when the data is available
        Customer.find({}, (err, customers) => {
          if (err) { throw new Error(err); }
          this.emit(this.events.GET_ALL_CUSTOMERS, customers);
        });
    };

    getCustomerById(id) {
        // Your implementation goes here
        // Should emit a GET_CUSTOMER_BY_ID event when the data is available
        Customer.findById(id, (err, customer) => {
          if (err) { throw new Error(err); }
          this.emit(this.events.GET_CUSTOMER_BY_ID, customer);
        });
    };

    getCustomerAuctionBids(cId) {
        // Your implementation goes here
        // Should emit a GET_CUSTOMER_AUCTION_BIDS event when the data is available
        AuctionBid.find({ customerId: { $in: cId} }, (err, bids) => {
          if (err) { throw new Error(err); }
          this.emit(this.events.GET_CUSTOMER_AUCTION_BIDS, bids);
        });
    };

    createCustomer(customer) {
        // Your implementation goes here
        // Should emit a CREATE_CUSTOMER event when the data is available
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
