using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public class towns
    {
        public string? name { get; }
        public string? price { get; }
        public int victoryPoints { get; }
        public bool owned { get; set; }
        public string? owner { get; set; }
        public string? commodity { get; set; }
        public int commodityPrice { get; set; }
        public int anyPrice { get; }
            
        public towns(string? name, string? price, int victoryPoints, bool owned, string? owner, string? commodity, int commodityPrice, int anyPrice)
        {
            this.name = name;
            this.price = price;
            this.victoryPoints = victoryPoints;
            this.owned = owned;
            this.owner = owner;
            this.commodity = commodity;
            this.commodityPrice = commodityPrice;
            this.anyPrice = anyPrice;
        }
    }

    public class townDict
    {
        //towns.townPrice townPrice = new towns.townPrice();
        
        public static Dictionary<int, towns> InitializeTowns()
        {
            var towns = new Dictionary<int, towns>();
            towns.Add(1, new Game.towns("Black Friar", "2 lumps of coal or 4x any commodity", 2, false, null, "coal", 2, 4));
            towns.Add(2, new Game.towns("Beaver Ford", "2 flumes of lumber or 4x any commodity", 2, false, null, "lumber", 2, 4));
            towns.Add(3, new Game.towns("Molehill", "2 ingots of iron or 4x any commodity", 2, false, null, "iron", 2, 4));
            towns.Add(4, new Game.towns("Bridgewater", "2 bushels of wheat or 4x any commodity", 2, false, null, "wheat", 2, 4));
            towns.Add(5, new Game.towns("Marketshire", "3 yachts of luxury or 5x any commodity", 3, false, null, "luxury", 3, 5));
            towns.Add(6, new Game.towns("Newgate", "3 bushels of wheat or 5x any commodity", 3, false, null, "wheat", 3, 5));
            towns.Add(7, new Game.towns("Trinity", "3 bundles of goods or 5x any commodity", 3, false, null, "luxury", 3, 5));
            towns.Add(8, new Game.towns("Foxwoods", "3 flumes of lumber or 5x any commodity", 3, false, null, "lumber", 3, 5));
            towns.Add(9, new Game.towns("Badger Downs", "4 bushels of wheat or 6x any commodity", 4, false, null, "wheat", 4, 6));
            towns.Add(10, new Game.towns("Bishop's Glen", "4 ingots of iron or 6x any commodity", 4, false, null, "iron", 4, 6));
            towns.Add(11, new Game.towns("Dunmoor", "4 lumps of coal or 6x any commodity", 4, false, null, "coal", 4, 6));
            towns.Add(12, new Game.towns("Wild Grove", "4 flumes of lumber or 6x any commodity", 4, false, null, "lumber", 4, 6));
            towns.Add(13, new Game.towns("Drover Crossing", "5 bundles of goods or 8x any commodity", 5, false, null, "luxury", 5, 8));
            towns.Add(14, new Game.towns("Canterbury Woods", "5 flumes of lumber or 8x any commodity", 5, false, null, "lumber", 5, 8));
            towns.Add(15, new Game.towns("River Ridge", "5 bushels of wheat or 8x any commodity", 5, false, null, "wheat", 5, 8));
            towns.Add(16, new Game.towns("Land's End", "5 yachts of luxury or 8x any commodity", 5, false, null, "luxury", 5, 8));

            return towns;
        }
    }
}
