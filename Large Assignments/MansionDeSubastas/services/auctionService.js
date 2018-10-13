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
			AUCTION_IS_PAST_END_DATE: 'AUCTION_IS_PAST_END_DATE',
			AUCTION_HAS_NOT_ENDED: 'AUCTION_HAS_NOT_ENDED',
			NO_BIDS: 'NO_BIDS',
			NOT_FOUND: 'NOT_FOUND'
		};
	}

	getAllAuctions() {
		// Finding all auctions and emitting the proper event when the data is available
		Auction.find({}, (err, auctions) => {
			if (err) { throw new Error(err); }
			if (auctions === null) {
				this.emit(this.events.NOT_FOUND, '');
				return;
			}
			this.emit(this.events.GET_ALL_AUCTIONS, auctions);
		});
	};

	getAuctionById(id) {
		// Finding auction by given id and emitting the proper event when it is found
		Auction.findById(id, (err, auction) => {
			if (err) { throw new Error(err); }
			if (customers === null) {
				this.emit(this.events.NOT_FOUND, '');
				return;
			}
			this.emit(this.events.GET_AUCTION_BY_ID, auction);
		});
	};

	getAuctionWinner(auctionId) {
		// Finding auctionWinner by given Id
		Auction.findById(auctionId, (err, auction) =>{
			if (err) { throw new Error(err); }
			if ( auction === null ) {
				this.emit(this.events.NOT_FOUND, '');
				return;
			}
			// Variable to hold the current date
			var date = new Date();
			// Checking if the auction is ongoing and does not have a winner yet
			if ( date < auction.endDate ) {
				this.emit(this.events.AUCTION_HAS_NOT_ENDED, 'The auction is ongoing and therefore does not have a winner');
				return;
			}
			// Checking if the auction has ended with no bids
			if ( date > auction.endDate && auction.auctionWinner === null ) {
				this.emit(this.events.NO_BIDS, 'This auction had no bids.');
				return;
			}
			// Returning the auction winner
			else {
				this.emit(this.events.GET_AUCTION_WINNER, auction.auctionWinner);
			}
		});
	};

	createAuction(auction) {
		// Finding the art to be auctioned
		Art.findOne({ _id: auction.artId }, (err, art) => {
			if (err) { throw new Error(err); }
			// Checking if the art item is an auctionItem
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
		// Finding the auctionbids within the auction
		AuctionBid.find({auctionId: aId}, (err, bids) => {
			if (err) { throw new Error(err); }
			this.emit(this.events.GET_AUCTION_BIDS_WITHIN_AUCTION, bids);
		});
	};

	placeNewBid(auctionId, customerId, price) {
		// Variable to hold a reference to this
		var self = this;
		// Finding the highest auctionbid
		AuctionBid.findOne({ auctionId : auctionId }).sort({'price' : -1}).limit(1).exec(function (err, high)
		{
			if (err) { throw new Error(err); }
			if(high){
				// Checking if the bid amount is lower than the current highest bid
				if (price <= high.price) {
					self.emit(self.events.PRICE_LOWER_THAN_MINIMUM_PRICE, 'Bid is lower than current highest bid');
					return;
				}
			}
			// Finding the auction to place the bid
			Auction.findById(auctionId, (err, auction) =>
			{
				// Variable to hold the current date
				var date = new Date();
				if (err) { throw new Error(err); }
				if ( auction === null ) {
					this.emit(this.events.NOT_FOUND, '');
					return;
				}
				// Checking if the bid is lower than the minimum bid
				else if ( price < auction.minimumPrice ) {
					self.emit(self.events.PRICE_LOWER_THAN_MINIMUM_PRICE, 'Bid is lower than minimum price');
					return;
				}
				// Checking if the auction has ended
				else if ( date > auction.endDate ) {
					self.emit(self.events.AUCTION_IS_PAST_END_DATE, 'Auction has ended')
					return;
				}
				// Updating the Auction Winner
				auction.auctionWinner = customerId;
				auction.save();
				// Creating the auctionbid
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
