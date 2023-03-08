using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Game
{
    public class railroad
    {
        
        //skunk works: 2, 5, 9, 15
        //slyfox: 2, 5, 10, 17
        //fat cat: 3, 7, 12, 19
        //big bear: 3, 7, 13, 21
        //top dog: 4, 9, 15, 23
        //tycoon: 4, 9, 16, 25
        public string? name { get; set; } 
        public int startingPrice { get; set; }
        public bool owned { get; set; }
        public string? owner { get; set; }
        public int startingVP { get; set; }

        public railroad(string? name, int startingPrice, bool owned, string? owner, int startingVP)
        {
            this.name = name;
            this.startingPrice = startingPrice;
            this.owned = owned;
            this.owner = owner;
            this.startingVP = startingVP;
        }
    }

    public class railroadDict
    {
        public static Dictionary<string, railroad> InitializeRailroad()
        {
            var railroads = new Dictionary<string, railroad>
            {
                { "skunkworks", new Game.railroad("Skunk Works", 2, false, null, 2) },
                { "slyfox", new Game.railroad("Sly Fox", 3, false, null, 2) },
                { "fatcat", new Game.railroad("Fat Cat", 4, false, null, 3) },
                { "bigbear", new Game.railroad("Big Bear", 5, false, null, 3) },
                { "topdog", new Game.railroad("Top Dog", 6, false, null, 4) },
                { "tycoon", new Game.railroad("Tycoon", 7, false, null, 4) }
            };
            return railroads;
        }
    }

}
