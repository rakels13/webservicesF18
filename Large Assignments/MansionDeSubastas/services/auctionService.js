const EventEmitter = require('events');
const Auction = require('../data/db').Auction;
const AuctionBid = require('../data/db').AuctionBid;
const Art = require('../data/db').Art;

class AuctionService extends EventEmitter {
	constructor() {
		super();
		this.events = {
			GET_ALL_AUCTIONS: 'GET_ALL_AUCTIONS',
			GET_AUCTION_BY_ID: 'GET_AUCTION_BY_ID',
			GET_AUCTION_WINNER: 'GET_AUCTION_WINNER',
			CREATE_AUCTION: 'CREATE_AUCTION',
			GET_AUCTION_BIDS_WITHIN_AUCTION: 'GET_AUCTION_BIDS_WITHIN_AUCTION',
			PLACE_NEW_BID: 'PLACE_NEW_BID',
			ITEM_NOT_AUCTIONITEM: 'ITEM_NOT_AUCTIONITEM',
			PRICE_LOWER_THAN_MINIMUM_PRICE: 'PRICE_LOWER_THAN_MINIMUM_PRICE',
			AUCTION_IS_PAST_END_DATE: 'AUCTION_IS_PAST_END_DATE'
		};
	}

	getAllAuctions() {
		// Your implementation goes here
        // Should emit a GET_ALL_AUCTIONS event when the data is available
				Auction.find({}, (err, auctions) => {
					if (err) { throw new Error(err); }
					this.emit(this.events.GET_ALL_AUCTIONS, auctions);
				});
	};

	getAuctionById(id) {
		// Your implementation goes here
    // Should emit a GET_AUCTION_BY_ID event when the data is available
		Auction.findById(id, (err, auction) => {
			if (err) { throw new Error(err); }
			this.emit(this.events.GET_AUCTION_BY_ID, auction);
		});
	};

	getAuctionWinner(auctionId) {
		// Your implementation goes here
        // Should emit a GET_AUCTION_WINNER event when the data is available
	};

	createAuction(auction) {
		// Your implementation goes here
        // Should emit a CREATE_AUCTION event when the data is available
				Art.findOne({ _id: auction.artId }, (err, art) => {
					if (err) { throw new Error(err); }
					else if (art.isAuctionItem === false) {
						this.emit(this.events.ITEM_NOT_AUCTIONITEM, "ArtItem is not an Auction Item");
						return;
					}
					Auction.create({
						artId: auction.artId,
						minimumPrice: auction.minimumPrice,
						endDate: auction.endDate,
						auctionWinner: auction.auctionWinner
					}, err => {
						if (err) { throw new Error(err); }
						this.emit(this.events.CREATE_AUCTION, auction);
					});
				});
	};

	getAuctionBidsWithinAuction(aId) {
		// Your implementation goes here
    // Should emit a GET_AUCTION_BIDS_WITHIN_AUCTION event when the data is available
		AuctionBid.find({auctionId: aId}, (err, bids) => {
			if (err) { throw new Error(err); }
			this.emit(this.events.GET_AUCTION_BIDS_WITHIN_AUCTION, bids);
		});
	};

	placeNewBid(auctionId, customerId, price) {
		// Your implementation goes here
    // Should emit a PLACE_NEW_BID event when the data is available
		// Finding the auction to place the bid
		Auction.findById(auctionId, (err, auction) =>
		{
			var date = new Date();
			console.log('finding minimum price')
			if (err) { throw new Error(err); }
			// checking if the bid is lower than the minimum bid
			else if ( price < auction.minimumPrice ) {
				this.emit(this.events.PRICE_LOWER_THAN_MINIMUM_PRICE, 'Bid is lower than minimum price');
				return;
			}
			else if ( date > auction.endDate ) {
				this.emit(this.events.AUCTION_IS_PAST_END_DATE, 'Auction has ended')
			}
			console.log('end date is ' + auction.endDate);
			console.log('current date is ' + date);

			var self = this;
			//Finding the highest bid currently.
			console.log('Finding highest bid')
			AuctionBid.findOne({ auctionId: auctionId}).sort({'price' : -1}).limit(1).exec(function (err, high)
			{
				console.log('highest bid is: ' + high.price)
				if (err) { throw new Error(err); }
				else if (price < high.price) {
					console.log('emitting event')
					self.emit(self.events.PRICE_LOWER_THAN_MINIMUM_PRICE, 'Bid is lower than current highest bid');
					return;
				}
				AuctionBid.create({
					auctionId: auctionId,
					customerId: customerId,
					price: price
				}, err => {
					if (err) { throw new Error(err); }
					self.emit(self.events.PLACE_NEW_BID);
				});
			});
		});
	};
};

module.exports = AuctionService;
