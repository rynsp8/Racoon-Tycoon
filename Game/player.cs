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
        public static Dictionary<string, railroad> OwnedRailRoad = railroadDict.InitializeRailroad();

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
            
            //public Commodities()
            //{
            //    this.wheat;
            //    this.lumber = 0;
            //    this.iron = 0;
            //    this.coal = 0;
            //    this.goods = 0;
            //    this.luxury = 0;
            //}

            public int commodityCheck(string commodity)
            {
                string commodityNeed = commodity;

                switch (commodityNeed)
                {
                    case "wheat":
                    case "Wheat":
                        return this.wheat;
                        break;
                    case "lumber":
                    case "Lumber":
                        return this.lumber;
                        break;
                    case "iron":
                    case "Iron":
                        return this.iron;
                        break;
                    case "coal":
                    case "Coal":
                        return this.coal;
                        break;
                    case "goods":
                    case "Goods":
                        return this.goods;
                        break;
                    case "luxury":
                    case "Luxury":
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
                case "Wheat":
                    this.capital = Market.WheatPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
                case "lumber":
                case "Lumber":
                    this.capital = Market.LumberPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
                case "iron":
                case "Iron":
                    this.capital = Market.IronPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
                case "coal":
                case "Coal":
                    this.capital = Market.CoalPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
                case "goods":
                case "Goods":
                    this.capital = Market.GoodsPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
                case "luxury":
                case "Luxury":
                    this.capital = Market.LuxuryPrice * quantity;
                    Market.marketSell(commodity, quantity);
                    break;
            }
        }
        public void purchaseTown(string playerName) 
        {
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
            
        }
        public void railRoadAuction() 
        {

        }
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


    }
}
