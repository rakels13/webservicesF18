const express = require('express');
const bodyParser = require('body-parser');
const router = express.Router();
const app = express();
const port = 3000;

const candyService = require('./services/candyService');
const offerService = require('./services/offerService');
const pinataService = require('./services/pinataService');

//get all candies
router.get('/candies', (req, res) => {
    return res.json(candyService.getAllCandies());
});

// get candy by Id
router.get('/candies/:id', (req, res) => {
    const { id } = req.params;
    const candy = candyService.getCandyById(id);
    if (candy === -1) { return res.status(404).send(); }
    return res.json(candy);
});

// create new Candy
router.post('/candies', (req, res) => {
    const { body } = req;
    var newCandy = candyService.createCandy(body);
    return res.status(201).send(newCandy);
});

//get all offers
router.get('/offers', (req, res) => {
    return res.json(offerService.getAllOffers());
});

//get all pinatas
router.get('/pinatas', (req, res) => {
    return res.json(pinataService.getAllPinatas());
});

// get pinata by Id
router.get('/pinatas/:id', (req, res) => {
    const { id } = req.params;
    const pinata = pinataService.getPinataById(id);
    if (pinata === -1) { return res.status(404).send(); }
    return res.json(pinata);
});

// create a new pinata
router.post('/pinatas', (req, res) => {
    const { body } = req;
    var pinata = pinataService.createPinata(body);
    return res.status(201).send(pinata);
});

// hit the pinata
router.put('/pinatas/:id/hit', (req, res) => {
    const { id } = req.params;
    const result = pinataService.hitPinata(id);
    if (result === "hit") { return res.status(204).send(); }
    else if (result === "lock") { return res.status(423).send(); }
    return res.status(200).send(result);
});

app.use(bodyParser.json());
app.use('/api', router);

app.listen(port || process.env.PORT, () => {
    console.log(`Listening on port ${port}`);
});
