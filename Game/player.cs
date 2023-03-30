using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Game.player;

namespace Game
{
    public class player
    {
        public player.Commodities OwnedCommodities = new player.Commodities();
        public static Dictionary<int, building> OwnedBuildings = buildingDict.InitializeBuildings();
        public static Dictionary<int, towns> OwnedTowns = townDict.InitializeTowns();
        public static Dictionary<string, railroad> OwnedRailRoad = railroadDict.InitializeRailroad();

        public string name = "";
        public int playerposition;
        public int capital = 100;

        public class count
        {
            public static int counter = 1;
        }
        public class Commodities
        {
            public int wheat, lumber, iron, coal, goods, luxury;
            
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
                        AnsiConsole.MarkupLine($"You produced [yellow]wheat[/]!");
                        this.OwnedCommodities.wheat++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                    case "lumber":
                        AnsiConsole.MarkupLine($"You produced [yellow]lumber[/]!");
                        this.OwnedCommodities.lumber++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                    case "iron":
                        AnsiConsole.MarkupLine($"You produced [yellow]iron[/]!");
                        this.OwnedCommodities.iron++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                    case "coal":
                        AnsiConsole.MarkupLine($"You produced [yellow]coal[/]!");
                        this.OwnedCommodities.coal++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                    case "goods":
                        AnsiConsole.MarkupLine($"You produced [yellow]goods[/]!");
                        this.OwnedCommodities.goods++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                    case "luxury":
                        AnsiConsole.MarkupLine($"You produced [yellow]luxury[/]!");
                        this.OwnedCommodities.luxury++;
                        Market.marketProduce(commoditiesArray[randIndex]);
                        break;
                }
            }
            
        }
        public void sellCommodities(string commodity, int quantity) 
        {
            switch (commodity)
            {
                case "wheat":
                case "Wheat":
                    this.capital = this.capital + (Market.WheatPrice * quantity);
                    Market.marketSell(commodity, quantity);
                    this.OwnedCommodities.wheat = this.OwnedCommodities.wheat - quantity;
                    break;
                case "lumber":
                case "Lumber":
                    this.capital = this.capital + (Market.LumberPrice * quantity);
                    Market.marketSell(commodity, quantity);
                    this.OwnedCommodities.lumber = this.OwnedCommodities.lumber - quantity;
                    break;
                case "iron":
                case "Iron":
                    this.capital = this.capital + (Market.IronPrice * quantity);
                    Market.marketSell(commodity, quantity);
                    this.OwnedCommodities.iron = this.OwnedCommodities.iron - quantity;
                    break;
                case "coal":
                case "Coal":
                    this.capital = this.capital + (Market.CoalPrice * quantity);
                    Market.marketSell(commodity, quantity);
                    this.OwnedCommodities.coal = this.OwnedCommodities.coal - quantity;
                    break;
                case "goods":
                case "Goods":
                    this.capital = this.capital + (Market.GoodsPrice * quantity);
                    Market.marketSell(commodity, quantity);
                    this.OwnedCommodities.goods = this.OwnedCommodities.goods - quantity;
                    break;
                case "luxury":
                case "Luxury":
                    this.capital = this.capital + (Market.LuxuryPrice * quantity);
                    Market.marketSell(commodity, quantity);
                    this.OwnedCommodities.luxury = this.OwnedCommodities.luxury - quantity;
                    break;
            }
        }
        public void purchaseTown(string playerName) 
        {
            string answer;
            int playerOwnedCommodity = this.OwnedCommodities.commodityCheck(player.OwnedTowns[count.counter].commodity);
            int townCommodityPrice = player.OwnedTowns[count.counter].commodityPrice;
            string commodity = player.OwnedTowns[count.counter].commodity;

            Console.WriteLine($"\nSo you're looking to purchase {player.OwnedTowns[count.counter].name}?\n");
            if(AnsiConsole.Confirm($"That'll be {player.OwnedTowns[count.counter].price}? Will you purchase that town? Y/n: "))
            {
                if (playerOwnedCommodity >= townCommodityPrice)
                {
                    this.OwnedCommodities.townPurchase(commodity, townCommodityPrice);
                    player.OwnedTowns[count.counter].owned = true;
                    player.OwnedTowns[count.counter].owner = playerName;
                    AnsiConsole.MarkupLine($"\n\nCongratulation {this.name}, you purchased {player.OwnedTowns[count.counter].name}! " +
                        $"and earned {player.OwnedTowns[count.counter].victoryPoints} victory points!\n\n");
                    count.counter++;
                    if (AnsiConsole.Confirm("\nContinue?"))
                    {
                        Console.Clear();
                    };
                }
                else if(playerOwnedCommodity < townCommodityPrice) 
                {
                    AnsiConsole.MarkupLine($"\n\nUnfortunately {this.name}, you do not have enough resources to purchase {player.OwnedTowns[count.counter].name}...\n\n");
                    if (AnsiConsole.Confirm("\nContinue?"))
                    {
                        Console.Clear();
                    };
                }
            }
            else 
            {
                AnsiConsole.MarkupLine($"\n\nThat's ok {this.name}!! Owning a town isn't for everyone...\n\n");
                if (AnsiConsole.Confirm("\nContinue?"))
                {
                    Console.Clear();
                };
            }
            

        }
        public void railRoadAuction() 
        {

        }

        public bool purchaseBuilding()
        {
            int check = player.OwnedBuildings.Count;
            foreach (var b in player.OwnedBuildings)
            {
                if (b.Value.owned)
                {
                    check--;
                }
                if (check == 0)
                {
                    AnsiConsole.MarkupLine("Looks like there are [red]no[/] more buildings to purchase.");
                    if (AnsiConsole.Confirm("\nContinue?"))
                    {
                        Console.Clear();
                        return false;
                    };
                }
            }

            string[] buildingArray = new string[5];

            var nonOwnedBuildings =
                from b in player.OwnedBuildings
                where b.Value.owned == false
                orderby b.Key 
                select b;

            if (nonOwnedBuildings.Count() > 4)
            {
                for (int i = 0; i < 5; i++)
                {
                    Random rnd = new Random();
                    int randomEl = rnd.Next(0, nonOwnedBuildings.Count());
                    string buildingName = nonOwnedBuildings.ElementAt(randomEl).Value.name;
                    bool buildingOwned = nonOwnedBuildings.ElementAt(randomEl).Value.owned;

                    if (buildingOwned)
                    {
                        i--;
                        continue;
                    }
                    else if (Array.IndexOf(buildingArray, buildingName) > -1)
                    {
                        i--;
                        continue;
                    }
                    else
                    {
                        buildingArray[i] = buildingName;
                    }

                };
            }
            else if (nonOwnedBuildings.Count() < 5)
            {
                for (int i = 0; i < nonOwnedBuildings.Count(); i++)
                {
                    Random rnd = new Random();
                    int randomEl = rnd.Next(0, nonOwnedBuildings.Count());
                    string buildingName = nonOwnedBuildings.ElementAt(randomEl).Value.name;
                    bool buildingOwned = nonOwnedBuildings.ElementAt(randomEl).Value.owned;

                    if (buildingOwned)
                    {
                        i--;
                        continue;
                    }
                    else if (Array.IndexOf(buildingArray, buildingName) > -1)
                    {
                        i--;
                        continue;
                    }
                    else
                    {
                        buildingArray[i] = buildingName;
                    }

                };
            }

            var building = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Building List")
                .PageSize(10)
                .AddChoices(buildingArray)
                );

            foreach (var b in OwnedBuildings)
            {
                if (building == b.Value.name)
                {
                    if (b.Value.owned == true)
                    {
                        AnsiConsole.MarkupLine($"Sorry, {this.name}, this building is owned by {b.Value.owner}");
                        if (AnsiConsole.Confirm("\nContinue?"))
                        {
                            Console.Clear();
                        };
                        return false;
                    }
                    else if (this.capital < b.Value.price)
                    {
                        AnsiConsole.MarkupLine($"Sorry, {this.name}, this building costs ${b.Value.price}, and you only have ${this.capital}");
                        if (AnsiConsole.Confirm("\nContinue?"))
                        {
                            Console.Clear();
                        };
                        return false;
                    }
                    else 
                    {
                        b.Value.owned = true;
                        b.Value.owner = this.name;
                        this.capital = this.capital - b.Value.price;
                        AnsiConsole.Markup($"Congratulations {this.name}!  You now own {b.Value.name}!\n");
                        return true;
                    }
                }
            }
            return true;
        }

        public void displayPortfolio()
        {
            var produceTable = new Table();
            produceTable.AddColumn("Commodity");
            produceTable.AddColumn(new TableColumn("Owned Shares").Centered());
            produceTable.AddRow(new Markup("Lumber"), new Markup($"{this.OwnedCommodities.lumber}"));
            produceTable.AddRow(new Markup("Wheat"), new Markup($"{this.OwnedCommodities.wheat}"));
            produceTable.AddRow(new Markup("Coal"), new Markup($"{this.OwnedCommodities.coal}"));
            produceTable.AddRow(new Markup("Iron"), new Markup($"{this.OwnedCommodities.iron}"));
            produceTable.AddRow(new Markup("Goods"), new Markup($"{this.OwnedCommodities.goods}"));
            produceTable.AddRow(new Markup("Luxury"), new Markup($"{this.OwnedCommodities.luxury}"));

            var townTable = new Table();

            townTable.AddColumn(new TableColumn("Owned Towns").LeftAligned());
            foreach (var town in player.OwnedTowns)
            {
                if (town.Value.owner == this.name)
                {
                    townTable.AddRow($"{town.Value.name}");
                }
            }

            var buildingTable = new Table();
            buildingTable.AddColumn(new TableColumn("Owned Buildings").LeftAligned());
            foreach (var building in player.OwnedBuildings)
            {
                if (building.Value.owner == this.name)
                {
                    buildingTable.AddRow($"{building.Value.name}");
                }
            }

            var layout = new Layout("Root")
                .SplitColumns(
                    new Layout("Left")
                    .SplitRows(
                        new Layout("Capital"),
                        new Layout("Towns")),
                    new Layout("Right")
                    .SplitRows(
                        new Layout("Commodities"),
                        new Layout("Buildings")
                        )
                );

            layout["Capital"].Update(
                new Panel(Align.Left(new Markup($"Capital: ${this.capital}"))).Expand()).Size(15);
            layout["towns"].Update(
                new Panel(townTable).Expand()).Size(30);
            layout["Commodities"].Update(
                new Panel(produceTable).Expand()).Size(15);
            layout["Buildings"].Update(
                new Panel(buildingTable).Expand()).Size(30);


            AnsiConsole.Write( layout );
            
        }


    }
}
