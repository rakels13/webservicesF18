// Here the web service should be setup and routes declared
const express = require('express');
const bodyParser = require('body-parser');
const app = express();
const port = 3000;

const ArtService = require('./services/artService');
const ArtistService = require('./services/artistService');
const AuctionService = require('./services/auctionService');
const CustomerService = require('./services/customerService');

// Get all arts [GET] /api/arts
app.get('/api/arts', (req, res) => {
  const artService = new ArtService();

  artService.on(artService.events.GET_ALL_ARTS, data => {
    return res.json(data);
  });

  artService.getAllArts();
});

//Get an art by Id [GET] /api/arts/:id
app.get('/api/arts/:id', (req, res) => {
  const { id } = req.params;
  const artService = new ArtService();

  artService.on(artService.events.GET_ART_BY_ID, data => {
    return res.json(data);
  });

  artService.getArtById(id);
});

//Create new art [POST] /api/arts
app.post('/api/arts', (req, res) => {
  const { body } = req;
  const artService = new ArtService();

  artService.on(artService.events.GREATE_ART, data => {
    return res.status(201).send(data);
  });

  artService.createArt(body);
});

// Get all artists [GET] /api/artists
app.get('/api/artists', (req, res) => {
  const artistService = new ArtistService();

  artistService.on(artistService.events.GET_ALL_ARTISTS, data => {
    return res.json(data);
  });

  artistService.getAllArtists();
});

// Get an atrist by Id [GET] /api/artists/:id
app.get('/api/artists/:id', (req, res) => {
  const { id } = req.params;
  const artistService = new ArtistService();

  artistService.on(artistService.events.GET_ARTIST_BY_ID, data => {
    return res.json(data);
  });

  artistService.getArtistById(id);
});

// Create new artist [POST] /api/artists
app.post('/api/artists', (req, res) => {
  const { body } = req;
  const artistService = new ArtistService();

  artistService.on(artistService.events.GREATE_ARTIST, data => {
    return res.status(201).send(data);
  });

  artistService.createArtist(body);
});

// Get all customers [GET] /api/customers
app.get('/api/customers', (req, res) => {
  const customerService = new CustomerService();

  customerService.on(customerService.events.GET_ALL_CUSTOMERS, data => {
    return res.json(data);
  });

  customerService.getAllCustomers();
});

// Get customer by Id [GET] /api/customers/:id
app.get('/api/customers/:id', (req, res) => {
  const { id } = req.params;
  const customerService = new CustomerService();

  customerService.on(customerService.events.GET_CUSTOMER_BY_ID, data => {
    return res.json(data);
  });

  customerService.getCustomerById(id);
});

// Create new customer [POST] /api/customers
app.post('/api/customers', (req, res) => {
  const { body } = req;
  const customerService = new CustomerService();

  customerService.on(customerService.events.GREATE_CUSTOMER, data => {
    return res.status(201).send(data);
  });

  customerService.createCustomer(body);
});

// Get all auction bids associated with a customer [GET] //api/customers/:id/auction-bids
app.get('/api/customers/:id/auction-bids', (req, res) => {
    const { id } = req.params;
    const bids = customerService.getCustomerAuctionBids(id);
    if (bids === -1) { return res.status(404).send(); }
    return res.json(bids);
});

// Get all auctions [GET] /api/auctions
app.get('/api/auctions', (req, res) => {
  const auctionService = new AuctionService();

  auctionService.on(auctionService.events.GET_ALL_AUCTIONS, data => {
    return res.json(data);
  });

  auctionService.getAllAuctions();
});

// Get auction by Id [GET] /api/auctions/:id
app.get('/api/auctions/:id', (req, res) => {
  const { id } = req.params;
  const auctionService = new AuctionService();

  auctionService.on(auctionService.events.GET_AUCTION_BY_ID, data => {
    return res.json(data);
  });

  auctionService.getArtById(id);
});

// Get winner of auction [GET] /api/auctions/:id/winner
app.get('/api/auctions/:id/winner', (req, res) => {
    const { id } = req.params;
    const winner = auctionService.getAuctionWinner(id);
    if (winner === -1) { return res.status(404).send(); }
    return res.json(winner);
});

// Create new auction [POST] /api/auctions
app.post('/api/auctions', (req, res) => {
  const { body } = req;
  const auctionService = new AuctionService();

  auctionService.on(auctionService.events.GREATE_AUCTION, data => {
    return res.status(201).send(data);
  });

  auctionService.createAuction(body);
});

// Get all auction bids associated with an auction [GET] /api/auctions/:id/bids
app.get('/api/auctions/:id/bids', (req, res) => {
    const { id } = req.params;
    const bids = auctionService.getAuctionBidsWithinAuction(id);
    if (bids === -1) { return res.status(404).send(); }
    return res.json(bids);
});

// Create new auction bid [POST] /api/auctions/:id/bids
app.post('/api/auctions/:id/bids', (req, res) => {
    const { body } = req;
    var newBid = auctionService.placeNewBid(body);
    return res.status(201).send(newBid);
});

app.listen(port,() => {
    console.log(`Listening on port ${port}`);
});
