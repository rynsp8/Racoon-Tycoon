using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class building
    {
        public int price { get; }
        public bool owned { get; set; }
        public string? name { get; }
        public string? owner { get; set; }
        public string? ability { get; set; }

        public building(string name, int price, bool owned, string owner, string? ability)
        {
            this.name = name;
            this.price = price;
            this.owned = owned;
            this.owner = owner;
            this.ability = ability;
        }
        public override string ToString() => $"{name}: {price}";

        public static void displayBuildings()
        {
            var buildingTable = new Table();

            buildingTable.AddColumn(new TableColumn("Building").LeftAligned());
            buildingTable.AddColumn(new TableColumn("Price").Centered());
            buildingTable.AddColumn(new TableColumn("Owner").LeftAligned());
            buildingTable.AddColumn(new TableColumn("Ability").LeftAligned());

            foreach (var building in player.OwnedBuildings)
            {
                string name = building.Value.name;
                int price = building.Value.price;
                string owner = building.Value.owner;
                string ability = building.Value.ability;
                buildingTable.AddRow($"{name}", $"{price}", $"{owner}", $"{ability}");
            }


            AnsiConsole.Write(buildingTable);
            if (AnsiConsole.Confirm("Continue?"))
            {
                Console.Clear();
            };



        }
    }

    public class buildingDict
    {
        public static Dictionary<int, building> InitializeBuildings()
        {
            var buildings = new Dictionary<int, building>();
            buildings.Add(1, new building("Wheat Field", 4, true, null, "Produce Commodity Player Action +1 Wheat"));
            buildings.Add(2, new building("Lumber Yard", 4, true, null, "Produce Commodity Player Action +1 Lumber"));
            buildings.Add(3, new building("Coal Deposit", 5, true, null, "Produce Commodity Player Action +1 Coal"));
            buildings.Add(4, new building("Iron Deposit", 5, true, null, "Produce Commodity Player Action +1 Iron"));
            buildings.Add(5, new building("Tool & Die", 6, true, null, "Produce Commodity Player Action +1 Goods"));
            buildings.Add(6, new building("Vineyard", 6, true, null, "Produce Commodity Player Action +1 Luxury"));
            buildings.Add(7, new building("Warehouse", 10, true, null, "+3 total held commodities"));
            buildings.Add(8, new building("Freight Company", 25, true, null, "May sell 2 commodities"));
            buildings.Add(9, new building("Construction Company", 20, true, null, "May purchase 2 buildings"));
            buildings.Add(10, new building("Rail Baron", 30, true, null, "Each railroad = +1VP"));
            buildings.Add(11, new building("Governor's Mansion", 30, true, null, "Each twon = +1VP"));
            buildings.Add(12, new building("Trading Floor", 15, true, null, "Buy any commodity from another player at markey price"));
            buildings.Add(13, new building("Brick Works", 25, true, null, "Build towns with 1 fewer commodity"));
            buildings.Add(14, new building("Cottage Industry", 30, true, null, "Max commodity production = 4"));
            buildings.Add(15, new building("Export Company", 30, true, null, "Increase the price of a commodity $3 before selling"));
            buildings.Add(16, new building("Smuggler", 20, true, null, "Max hand size = 4"));
            buildings.Add(17, new building("Store House", 10, true, null, "+2 total held commodities"));
            buildings.Add(18, new building("Goods/Luxury Trading Firm", 10, true, null, "+$1 Goods or Luxury Sold"));
            buildings.Add(19, new building("Factory", 40, true, null, "Max commodity production = 5"));
            buildings.Add(20, new building("Coal/Iron Trading Firm", 10, true, null, "+$1 Coal or Iron Sold"));
            buildings.Add(21, new building("Foundary", 40, true, null, "Max commodity production = 5"));
            buildings.Add(22, new building("Mayor's Office", 30, true, null, "Each building = +1VP"));
            buildings.Add(23, new building("Bank", 30, true, null, "Each $20 = +1VP"));
            buildings.Add(24, new building("Auction House", 15, true, null, "$5 commission each auction held"));
            buildings.Add(25, new building("Lumber/Wheat Trading Firm", 10, false, null, "+$1 for Lumber or Wheat Sold"));
            buildings.Add(26, new building("Black Market", 30, false, null, "Max hand size = 5"));
            return buildings;
        }
    }

    

}



    


