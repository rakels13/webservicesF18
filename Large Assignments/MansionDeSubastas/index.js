// Here the web service should be setup and routes declared
const express = require('express');
const bodyParser = require('body-parser');
const router = express.Router();
const app = express();
const port = 5000;

const artService = require('./services/artService');
const artistService = require('./services/artistService');
const auctionService = require('./services/auctionService');
const customerService = require('./services/customerService');

// Get all arts [GET] /api/arts
router.get('/arts', (req, res) => {
  return res.json(artService.getAllArts());
});

//Get an art by Id [GET] /api/arts/:id
router.get('/arts/:id', (req, res) => {
    const { id } = req.params;
    const art = artService.getArtById(id);
    if (art === -1) { return res.status(404).send(); }
    return res.json(art);
});

//Create new art [POST] /api/arts
router.post('/arts', (req, res) => {
    const { body } = req;
    var newArt = artService.createArt(body);
    return res.status(201).send(newArt);
});

// Get all artists [GET] /api/artists
router.get('/artists', (req, res) => {
  return res.json(artistService.getAllArtists());
});

// Get an atrist by Id [GET] /api/artists/:id
router.get('/artists/:id', (req, res) => {
    const { id } = req.params;
    const artist = artistService.getArtistById(id);
    if (artist === -1) { return res.status(404).send(); }
    return res.json(artist);
});

// Create new artist [POST] /api/artists
router.post('/artists', (req, res) => {
    const { body } = req;
    var newArtist = artistService.createArtist(body);
    return res.status(201).send(newArtist);
});

// Get all customers [GET] /api/customers
router.get('/customers', (req, res) => {
  return res.json(customerService.getAllCustomers());
});

// Get customer by Id [GET] /api/customers/:id
router.get('/customers/:id', (req, res) => {
    const { id } = req.params;
    const customer = customerService.getCustomerById(id);
    if (customer === -1) { return res.status(404).send(); }
    return res.json(customer);
});

// Create new customer [POST] /api/customers
router.post('/customers', (req, res) => {
    const { body } = req;
    var newCustomer = customerService.createCustomer(body);
    return res.status(201).send(newCustomer);
});

// Get all auction bids associated with a customer [GET] //api/customers/:id/auction-bids
router.get('/customers/:id/auction-bids', (req, res) => {
    const { id } = req.params;
    const bids = customerService.getCustomerAuctionBids(id);
    if (bids === -1) { return res.status(404).send(); }
    return res.json(bids);
});

// Get all auctions [GET] /api/auctions
router.get('/auctions', (req, res) => {
  return res.json(auctionService.getAllAuctions());
});

// Get auction by Id [GET] /api/auctions/:id
router.get('/auctions/:id', (req, res) => {
    const { id } = req.params;
    const auction = auctionService.getAuctionById(id);
    if (auction === -1) { return res.status(404).send(); }
    return res.json(auction);
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
    var newAuction = auctionService.createAuction(body);
    return res.status(201).send(newAuction);
});

// Get all auction bids associated with an auction [GET] /api/auctions/:id/bids
router.get('/auctions/:id/bids', (req, res) => {
    const { id } = req.params;
    const bids = auctionService.getAuctionBidsWithinAuction(id);
    if (bids === -1) { return res.status(404).send(); }
    return res.json(bids);
});

// Create new auction bid [POST] /api/auctions/:id/bids
router.post('/auctions/:id/bids', (req, res) => {
    const { body } = req;
    var newBid = auctionService.placeNewBid(body);
    return res.status(201).send(newBid);
});

app.use(bodyParser.json());
app.use('/api', router);

app.listen(port || process.env.PORT, () => {
    console.log(`Listening on port ${port}`);
});
