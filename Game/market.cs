using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/******************************************************************************/
/*  The market.cs class is a global static class which serves each player
 *  class and mimics a supply/demand relationship between the price/scacity
 *  of a commodity.
 *  
 *  marketProduce - when a player takes the produceCommodity() method it 
 *                  calls the Global.marketProduce(string commodity) method
 *                  which will update the price of the randomly selected
 *                  commodity so long it remains below the assigned
 *                  threshold.
 *                  
 *  marketSell    - when a player take the sellCommodity() method is calls
 *                  the Global.marketSell(string commodity, int quantity)
 *                  method which will sell 1 selected commodity owned by a 
 *                  player and how many units of that commodity.  The 
 *                  method will then lower the price of the commodity based
 *                  off the quantity paramter.
 *  
/******************************************************************************/
namespace Game
{
    static class Market
    {
        public static int LuxuryPrice = 3;
        public static int GoodsPrice = 3;
        public static int CoalPrice = 2;
        public static int IronPrice = 2;
        public static int WheatPrice = 1;
        public static int LumberPrice = 1;

        public static void marketProduce(string commodity)
        {
            switch (commodity)
            {
                case "wheat":
                    if (WheatPrice == 12) break;
                    WheatPrice++;
                    break;
                case "lumber":
                    if (LumberPrice == 12) break;
                    LumberPrice++;
                    break;
                case "iron":
                    if (IronPrice == 13) break;
                    IronPrice++;
                    break;
                case "coal":
                    if (CoalPrice == 13) break;
                    CoalPrice++;
                    break;
                case "goods":
                    if (GoodsPrice == 14) break;
                    GoodsPrice++;
                    break;
                case "luxury":
                    if (LuxuryPrice == 14) break;
                    LuxuryPrice++;
                    break;
            }
        }
        public static void marketSell(string commodity, int quantity)
        {
            switch (commodity)
            {
                case "wheat":
                    WheatPrice = WheatPrice - quantity;
                    break;
                case "lumber":
                    LumberPrice = LumberPrice - quantity;
                    break;
                case "iron":
                    IronPrice = IronPrice - quantity;
                    break;
                case "coal":
                    CoalPrice = CoalPrice - quantity;
                    break;
                case "goods":
                    GoodsPrice = GoodsPrice - quantity;
                    break;
                case "luxury":
                    LuxuryPrice = GoodsPrice - quantity;
                    break;
            }
        }

        public static void displayMarket()
        {
            AnsiConsole.Write(new BarChart()
                .Width(60)
                .Label("[green bold underline]Commodities Market[/]")
                .CenterLabel()
                .AddItem("Lumber", LumberPrice, Color.Khaki1)
                .AddItem("Wheat", WheatPrice, Color.Gold1)
                .AddItem("Iron", IronPrice, Color.Grey)
                .AddItem("Coal", CoalPrice, Color.DarkSlateGray1)
                .AddItem("Goods", GoodsPrice, Color.DarkGreen)
                .AddItem("Luxury", LuxuryPrice, Color.DarkRed)
                ) ;
        }

    };
}
