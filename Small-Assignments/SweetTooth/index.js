const express = require('express');
const bodyParser = require('body-parser');
const router = express.Router();
const app = express();
const port = 3000;

const candyService = require('./services/candyService');
const offerService = require('./services/offerService');
const pinataService = require('./services/pinataService');

//candies
router.get('/candies', (req, res) => {
    return res.json(candyService.getAllCandies());
});

router.get('/candies/:id', (req, res) => {
    const { id } = req.params;
    const candy = candyService.getCandyById(id);
    if (candy === -1) { return res.status(404).send(); }
    return res.json(candy);
});

router.post('/candies', (req, res) => {
    const { body } = req;
    candyService.createCandy(body);
    return res.status(201).send();
});

//offers
router.get('/offers', (req, res) => {
    return res.json(offerService.getAllOffers());
});

//pinatas
router.get('/pinatas', (req, res) => {
    return res.json(pinataService.getAllPinatas());
});

router.get('/pinatas/:id', (req, res) => {
    const { id } = req.params;
    const pinata = pinataService.getPinataById(id);
    if (pinata === -1) { return res.status(404).send(); }
    return res.json(pinata);
});

router.post('/pinatas', (req, res) => {
    const { body } = req;
    pinataService.createPinata(body);
    return res.status(201).send();
});

router.put('/pinatas/:id', (req, res) => {
    const { body } = req;
    const { id } = req.params;
    const result = pinataService.changePinata(id, body);
    if (result === -1) { return res.status(404).send(); }
    return res.status(204).send();
});



app.use(bodyParser.json());
app.use('/api', router);

app.listen(port || process.env.PORT, () => {
    console.log(`Listening on port ${port}`);
});
