const EventEmitter = require('events');
const Customer = require('../data/db').Customer;

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

    getCustomerAuctionBids(customerId) {
        // Your implementation goes here
        // Should emit a GET_CUSTOMER_AUCTION_BIDS event when the data is available
    };

    createCustomer(customer) {
        // Your implementation goes here
        // Should emit a CREATE_CUSTOMER event when the data is available
    };
};

module.exports = CustomerService;
