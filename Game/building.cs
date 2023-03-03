using System;
using System.Collections.Generic;
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

        public building(string name, int price, bool owned, string owner)
        {
            this.name = name;
            this.price = price;
            this.owned = owned;
            this.owner = owner;
        }
        public override string ToString() => $"{name}: {price}";
    }

    public class buildingDict
    {
        public static Dictionary<string, building> InitializeBuildings()
        {
            var buildings = new Dictionary<string, building>();
            buildings.Add("wheatfield", new building("Wheat Field", 4, false, null));
            buildings.Add("lumberyard", new building("Lumber Yard", 4, false, null));
            buildings.Add("coaldeposit", new building("Coal Deposit", 5, false, null));
            buildings.Add("irondeposit", new building("Iron Deposit", 5, false, null));
            buildings.Add("toolanddie", new building("Tool & Die", 6, false, null));
            buildings.Add("vineyard", new building("Vineyard", 6, false, null));
            buildings.Add("warehouse", new building("Warehouse", 10, false, null));
            buildings.Add("freightcompany", new building("Freight Company", 25, false, null));
            buildings.Add("constructioncompany", new building("Construction Company", 20, false, null));
            buildings.Add("railbarson", new building("Rail Baron", 30, false, null));
            buildings.Add("governorsmansion", new building("Governor's Mansion", 30, false, null));
            buildings.Add("tradingfloor", new building("Trading Floor", 15, false, null));
            buildings.Add("brickworks", new building("Brick Works", 25, false, null));
            buildings.Add("cottageindustry", new building("Cottage Industry", 30, false, null));
            buildings.Add("exportcompany", new building("Export Company", 30, false, null));
            buildings.Add("smuggler", new building("Smuggler", 20, false, null));
            buildings.Add("storehouse", new building("Store House", 10, false, null));
            buildings.Add("goodsluxurytradingfirm", new building("Goods/Luxury Trading Firm", 10, false, null));
            buildings.Add("factory", new building("Factory", 40, false, null));
            buildings.Add("coalirontradingfirm", new building("Coal/Iron Trading Firm", 10, false, null));
            buildings.Add("foundry", new building("Foundary", 40, false, null));
            buildings.Add("mayorsoffice", new building("Mayor's Office", 30, false, null));
            buildings.Add("bank", new building("Bank", 30, false, null));
            buildings.Add("auctionhouse", new building("Auction House", 15, false, null));
            buildings.Add("lumberwheattradingfirm", new building("Lumber/Wheat Trading Firm", 10, false, null));
            buildings.Add("blackmarket", new building("Black Market", 30, false, null));
            return buildings;
        }



    }
}



    


