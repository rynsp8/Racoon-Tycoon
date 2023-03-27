RACCOON TYCOON

Project Outline:
	This project is based off of the board game, Raccoon Tycoon, originally created by Dan Glover.
	It is a game that my sons and I enjoy, mostly, and provided a simple but challenging game play structure that I
	could replicate within the C# language.  Raccoon Tycoon is an economic game where in the players compete to earn
	the most victory points.  Victory points are earned by buy towns, buildings, or winning RailRoad auctions. At the
	end of the game, all points are added up. The player with the most points wins.

	At this time, player actions include the below:
		- View Price of Commodities
		- Produce Commodities
		- Sell Commodities
		- Purchase a Building
		- Purchase a Town
		- Start a rail road auction
		- Quit
		
Three Features
	Master Loop - the master loop is used to create a List<T> of player objects. A while loop is used to hold a FOREACH loop that cycles
	through the player list to give each player the opportunity to choose a player action.

	Classes - each player action has it's own class that are encapsulated within the player parent class. Further, each class has properties
	and methods that fall within the confines of the actual board game, though not perfectly recreated.

	List - the player List<T> is created first to hold the amount of players who want to play the game.
	
Special Instructions
	NONE