using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class player
    {
        public player.Commodities OwnedCommodities = new player.Commodities();
        public static Dictionary<string, building> OwnedBuildings = buildingDict.InitializeBuildings();
        public static Dictionary<int, towns> OwnedTowns = townDict.InitializeTowns();

        public string name = "";
        public int playerposition;
        public int capital = 10;

        public class count
        {
            public static int counter = 1;
        }
        public class Commodities
        {
            public int wheat, lumber, iron, coal, goods, luxury;
            
            public Commodities()
            {
                this.wheat = 10;
                this.lumber = 10;
                this.iron = 10;
                this.coal = 10;
                this.goods = 10;
                this.luxury = 10;
            }

            public int commodityCheck(string commodity)
            {
                switch (commodity)
                {
                    case "wheat":
                        return this.wheat;
                        break;
                    case "lumber":
                        return this.lumber;
                        break;
                    case "iron":
                        return this.iron;
                        break;
                    case "coal":
                        return this.coal;
                        break;
                    case "goods":
                        return this.goods;
                        break;
                    case "luxury":
                        return this.luxury;
                        break;
                }
                return 0;
            }

            public void townPurchase(string commodity, int price)
            {
                switch (commodity)
                {
                    case "wheat":
                        this.wheat = this.wheat - price;
                        break;
                    case "lumber":
                        this.lumber = this.lumber - price;
                        break;
                    case "iron":
                        this.iron = this.iron - price;
                        break;
                    case "coal":
                        this.coal = this.coal - price;
                        break;
                    case "goods":
                        this.goods = this.goods - price;
                        break;
                    case "luxury":
                        this.luxury = this.luxury - price;
                        break;
                }
            }
            
        }
            
        public void produceCommodities()
        {   
            string[] commoditiesArray = {"wheat", "lumber", "iron", "coal", "goods", "luxury"};

            Random rand = new Random();
                
            for (int i = 0; i < 3; i++)
            {
                int index = rand.Next(commoditiesArray.Length);
                int randIndex = rand.Next(commoditiesArray.Length);
                switch (commoditiesArray[index])
                {
                    case "wheat":
                        this.OwnedCommodities.wheat++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                    case "lumber":
                        this.OwnedCommodities.lumber++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                    case "iron":
                        this.OwnedCommodities.iron++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                    case "coal":
                        this.OwnedCommodities.coal++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                    case "goods":
                        this.OwnedCommodities.goods++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                    case "luxury":
                        this.OwnedCommodities.luxury++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                }
            }
            if (player.OwnedBuildings["wheatfield"].owned == true && player.OwnedBuildings["wheatfield"].owner == this.name)
            {
                this.OwnedCommodities.wheat++;
                Console.WriteLine($"Congrats {this.name}, you earned an extra bushel of wheat!");
            }
            if (player.OwnedBuildings["lumberyard"].owned == true && player.OwnedBuildings["lumberyard"].owner == this.name)
            {
                this.OwnedCommodities.lumber++;
                Console.WriteLine($"Congrats {this.name}, you earned an extra flume of lumber!");
            }
            if (player.OwnedBuildings["coaldeposit"].owned == true && player.OwnedBuildings["coaldeposit"].owner == this.name)
            {
                this.OwnedCommodities.coal++;
                Console.WriteLine($"Congrats {this.name}, you earned an extra lump of coal!");
            }
            if (player.OwnedBuildings["irondeposit"].owned == true && player.OwnedBuildings["irondeposit"].owner == this.name)
            {
                this.OwnedCommodities.iron++;
                Console.WriteLine($"Congrats {this.name}, you earned an extra ingot of iron!");
            }
            if (player.OwnedBuildings["toolanddie"].owned == true && player.OwnedBuildings["toolanddie"].owner == this.name)
            {
                this.OwnedCommodities.goods++;
                Console.WriteLine($"Congrats {this.name}, you earned an extra bundle of goods!");
            }
            if (player.OwnedBuildings["vineyard"].owned == true && player.OwnedBuildings["vineyard"].owner == this.name)
            {
                this.OwnedCommodities.luxury++;
                Console.WriteLine($"Congrats {this.name}, you earned an extra yacht of luxury!");
            }
        }
        public void sellCommodities(string commodity, int quantity) 
        {
            switch (commodity)
            {
                case "wheat":
                    this.capital = Market.WheatPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
                case "lumber":
                    this.capital = Market.LumberPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
                case "iron":
                    this.capital = Market.IronPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
                case "coal":
                    this.capital = Market.CoalPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
                case "goods":
                    this.capital = Market.GoodsPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
                case "luxury":
                    this.capital = Market.LuxuryPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
            }
        }
        public void purchaseTown(string playerName) 
        {
            count count = new count();
            string answer;
            int playerOwnedCommodity = this.OwnedCommodities.commodityCheck(player.OwnedTowns[count.counter].commodity);
            int townCommodityPrice = player.OwnedTowns[count.counter].commodityPrice;
            string commodity = player.OwnedTowns[count.counter].commodity;


            Console.WriteLine($"So you're looking to purchase {player.OwnedTowns[count.counter].name}?");
            Console.Write($"That'll be {player.OwnedTowns[count.counter].price}? Will you purchase that town? Y/n: ");
            answer = Console.ReadLine();
            if (answer == "Y")
            {
                if (playerOwnedCommodity >= townCommodityPrice)
                {
                    this.OwnedCommodities.townPurchase(commodity, townCommodityPrice);
                    player.OwnedTowns[count.counter].owned = true;
                    player.OwnedTowns[count.counter].owner = playerName;
                }
            }

            count.counter++;

            Console.WriteLine($"\n\nCONGRATULATIONS {playerName}, you've purchased {player.OwnedTowns[count.counter].name}!!\n\n");
            Console.WriteLine($"\n\n{player.OwnedTowns[count.counter].name} is owned by {player.OwnedTowns[count.counter].owner} and is {player.OwnedTowns[count.counter].owned}");

        }
        public void railRoadAuction() { }
        public void purchaseBuilding(string buildingName, string playerName) 
        {
            if (player.OwnedBuildings[buildingName].owned == false && this.capital >= player.OwnedBuildings[buildingName].price)
            {
                        this.capital = this.capital - player.OwnedBuildings[buildingName].price;
                        player.OwnedBuildings[buildingName].owned = true;
                        player.OwnedBuildings[buildingName].owner = playerName;

                        Console.WriteLine($"\nCongrats {this.name}! You purchased a {player.OwnedBuildings[buildingName].name}!!\n");
            }
            else 
            {
                        Console.WriteLine($"\nI'm sorry {this.name}, {OwnedBuildings[buildingName].owner} already owns this building.\n");
            }
                

            
        }

        public void townTest(string playerName)
        {
            for (int i = i; i < OwnedTowns.Count; i++)
            {
                Console.WriteLine($"Town owner is: {OwnedTowns[i].owner}");
                player.OwnedTowns[i].owner = playerName;
                Console.WriteLine($"Town owner is now: {OwnedTowns[i].owner}");
            }
        }

    }
}
