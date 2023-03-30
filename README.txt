RACCOON TYCOON

Project Outline:
	This project is based off of the board game, Raccoon Tycoon, originally created by Dan Glover.
	It is a game that my sons and I enjoy, mostly, and provided a simple but challenging game play structure that I
	could replicate within the C# language.  Raccoon Tycoon is an economic game wherein the players compete to earn
	the most victory points.  Victory points are earned by buying towns, buildings, or winning RailRoad auctions. At the
	end of the game, all points are added up. The player with the most points wins.

	At this time, player actions include the below:
		- View Player Portfolio
		- View Price of Commodities
		- Produce Commodities
		- Sell Commodities
		- View Buildings
		- Purchase a Building
		- Purchase a Town
		- Start a rail road auction (not available)
		- Quit
		
Three Features
	Master Loop - the master loop is used to create a List<T> of player objects. A while loop is used to hold a FOREACH loop that cycles
	through the player list to give each player the opportunity to choose a player action.

	Classes - each player action has it's own class that are encapsulated within the player parent class. Further, each class has properties
	and methods that fall within the confines of the actual board game, though not perfectly recreated.

	List - the player List<T> is created first to hold the amount of players who want to play the game.
	
	Dictionaries - three classes and three dictionaries are used to define the Buildings, Towns, and railroads.
	
Special Instructions
	NONE

Work to be Completed
	The player action "Start a rail road auction" has not been completed at this time. When a player chooses to start a railroad aution bidding will begin at the 
	initial price point. Each player will have the opportunity to bid. The genearl order of events for this player action is below:
	1. Player chooses to start auction on a randomly selected railroad agreeing to pay the initial big price contained in the dictionary.
	2. Bidding will start
		a. The next player will be given the option first, to bid
		b. If the player wants to bid they will be asked the amount they wish to pay
		c. If the player does not want to bid, they should not be asked again while the auction continues.
	3. If the Player starting the auction wins they get the railroad and the assigned victory points.
	4. If the Player starting the auction loses the auction they get to retake their turn and the winning player pays their bid price as well as gains the assigned 
	   victory points.