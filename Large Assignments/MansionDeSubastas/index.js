// Here the web service should be setup and routes declared
const express = require('express');
const bodyParser = require('body-parser');
const router = express.Router();
const app = express();
const port = 3000;

const ArtService = require('./services/artService');
const ArtistService = require('./services/artistService');
const AuctionService = require('./services/auctionService');
const CustomerService = require('./services/customerService');

// Get all arts [GET] /api/arts
router.get('/arts', (req, res) => {
  const artService = new ArtService();

  artService.on(artService.events.GET_ALL_ARTS, data => {
    return res.json(data);
  });

  artService.getAllArts();
});

//Get an art by Id [GET] /api/arts/:id
router.get('/arts/:id', (req, res) => {
  const { id } = req.params;
  const artService = new ArtService();

  artService.on(artService.events.GET_ART_BY_ID, data => {
    return res.json(data);
  });

  artService.getArtById(id);
});

//Create new art [POST] /api/arts
router.post('/arts', (req, res) => {
  const { body } = req;
  const artService = new ArtService();

  artService.on(artService.events.CREATE_ART, data => {
    return res.status(201).send(data);
  });

  artService.createArt(body);
});

// Get all artists [GET] /api/artists
router.get('/artists', (req, res) => {
  const artistService = new ArtistService();

  artistService.on(artistService.events.GET_ALL_ARTISTS, data => {
    return res.json(data);
  });

  artistService.getAllArtists();
});

// Get an atrist by Id [GET] /api/artists/:id
router.get('/artists/:id', (req, res) => {
  const { id } = req.params;
  const artistService = new ArtistService();

  artistService.on(artistService.events.GET_ARTIST_BY_ID, data => {
    return res.json(data);
  });

  artistService.getArtistById(id);
});

// Create new artist [POST] /api/artists
router.post('/artists', (req, res) => {
  const { body } = req;
  const artistService = new ArtistService();

  artistService.on(artistService.events.CREATE_ARTIST, data => {
    return res.status(201).send(data);
  });

  artistService.createArtist(body);
});

// Get all customers [GET] /api/customers
router.get('/customers', (req, res) => {
  const customerService = new CustomerService();

  customerService.on(customerService.events.GET_ALL_CUSTOMERS, data => {
    return res.json(data);
  });

  customerService.getAllCustomers();
});

// Get customer by Id [GET] /api/customers/:id
router.get('/customers/:id', (req, res) => {
  const { id } = req.params;
  const customerService = new CustomerService();

  customerService.on(customerService.events.GET_CUSTOMER_BY_ID, data => {
    return res.json(data);
  });

  customerService.getCustomerById(id);
});

// Create new customer [POST] /api/customers
router.post('/customers', (req, res) => {
  const { body } = req;
  const customerService = new CustomerService();

  customerService.on(customerService.events.CREATE_CUSTOMER, data => {
    return res.status(201).send(data);
  });

  customerService.createCustomer(body);
});

// Get all auction bids associated with a customer [GET] //api/customers/:id/auction-bids
router.get('/customers/:id/auction-bids', (req, res) => {
  const { id } = req.params;
  const customerService = new CustomerService();

  customerService.on(customerService.events.GET_CUSTOMER_AUCTION_BIDS, data => {
    return res.json(data);
  });

  customerService.getCustomerAuctionBids(id);
});

// Get all auctions [GET] /api/auctions
router.get('/auctions', (req, res) => {
  const auctionService = new AuctionService();

  auctionService.on(auctionService.events.GET_ALL_AUCTIONS, data => {
    return res.json(data);
  });

  auctionService.getAllAuctions();
});

// Get auction by Id [GET] /api/auctions/:id
router.get('/auctions/:id', (req, res) => {
  const { id } = req.params;
  const auctionService = new AuctionService();

  auctionService.on(auctionService.events.GET_AUCTION_BY_ID, data => {
    return res.json(data);
  });

  auctionService.getAuctionById(id);
});

// Get winner of auction [GET] /api/auctions/:id/winner
router.get('/auctions/:id/winner', (req, res) => {
    const { id } = req.params;
    const winner = auctionService.getAuctionWinner(id);
    if (winner === -1) { return res.status(404).send(); }
    return res.json(winner);
});

// Create new auction [POST] /api/auctions
router.post('/auctions', (req, res) => {
  const { body } = req;
  const auctionService = new AuctionService();

  auctionService.on(auctionService.events.CREATE_AUCTION, data => {
    return res.status(201).send(data);
  });
  auctionService.on(auctionService.events.ITEM_NOT_AUCTIONITEM, data => {
    return res.status(412).send(data);
  });

  auctionService.createAuction(body);
});

// Get all auction bids associated with an auction [GET] /api/auctions/:id/bids
router.get('/auctions/:id/bids', (req, res) => {
  const { id } = req.params;
  const auctionService = new AuctionService();

  auctionService.on(auctionService.events.GET_AUCTION_BIDS_WITHIN_AUCTION, data => {
    return res.json(data);
  });

  auctionService.getAuctionBidsWithinAuction(id);
});

// Create new auction bid [POST] /api/auctions/:id/bids
router.post('/auctions/:id/bids', (req, res) => {
  const { id } = req.params;
  const { body } = req;
  const auctionService = new AuctionService();

  auctionService.on(auctionService.events.PLACE_NEW_BID, data => {
    return res.json(data);
  });
  auctionService.on(auctionService.events.PRICE_LOWER_THAN_MINIMUM_PRICE, data => {
    return res.status(412).send(data);
  });
  auctionService.on(auctionService.events.AUCTION_IS_PAST_END_DATE, data => {
    return res.status(403).send(data);
  });

  auctionService.placeNewBid(id, body.customerId, body.price);
});

app.use(bodyParser.json());
app.use('/api', router);

app.listen(port || process.env.PORT, () => {
    console.log(`Listening on port ${port}`);
});
