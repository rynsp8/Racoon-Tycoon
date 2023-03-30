using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Game.player;

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
            int profit = Market.profit(commodity, quantity);
            AnsiConsole.Markup($"You have made [green]${profit}[/] in profit!\n");
            switch (commodity)
            {
                case "wheat":
                case "Wheat":
                    
                    for (int i = 0; i < quantity; i++)
                    {
                        if (WheatPrice == 1)
                        {
                            break;
                        }
                        else
                        {
                            WheatPrice--;
                        }
                    }
                    break;
                case "lumber":
                case "Lumber":
                    for (int i = 0; i < quantity; i++)
                    {
                        if (LumberPrice == 1)
                        {
                            break;
                        }
                        else
                        {
                            LumberPrice--;
                        }
                    }
                    break;
                case "iron":
                case "Iron":
                    for (int i = 0; i < quantity; i++)
                    {
                        if (IronPrice == 2)
                        {
                            break;
                        }
                        else
                        {
                            IronPrice--;
                        }
                    }
                    break;
                case "coal":
                case "Coal":
                    for (int i = 0; i < quantity; i++)
                    {
                        if (CoalPrice == 2)
                        {
                            break;
                        }
                        else
                        {
                            CoalPrice--;
                        }
                    }
                    break;
                case "goods":
                case "Goods":
                    for (int i = 0; i < quantity; i++)
                    {
                        if (GoodsPrice == 2)
                        {
                            break;
                        }
                        else
                        {
                            GoodsPrice--;
                        }
                    }
                    break;
                case "luxury":
                case "Luxury":
                    for (int i = 0; i < quantity; i++)
                    {
                        if (LuxuryPrice == 2)
                        {
                            break;
                        }
                        else
                        {
                            LuxuryPrice--;
                        }
                    }
                    break;
            }
        }

        public static void displayMarket()
        {
            AnsiConsole.Write(new BarChart()
                .Width(60)
                .Label("[green bold underline]Commodities Market[/]")
                .CenterLabel()
                .AddItem("Lumber", LumberPrice, Color.Gold1)
                .AddItem("Wheat", WheatPrice, Color.Wheat1)
                .AddItem("Iron", IronPrice, Color.Silver)
                .AddItem("Coal", CoalPrice, Color.Grey)
                .AddItem("Goods", GoodsPrice, Color.Green)
                .AddItem("Luxury", LuxuryPrice, Color.Red)
                ) ;
            if (AnsiConsole.Confirm("Continue?"))
            {
                Console.Clear();
            }
        }

        public static int profit(string commodity, int share) 
        {
            switch(commodity) 
            {
                case "lumber":
                case "Lumber":
                    return share * LumberPrice;
                    break;
                case "wheat":
                case "Wheat":
                    return share * WheatPrice;
                    break;
                case "coal":
                case "Coal":
                    return share * CoalPrice;
                    break;
                case "iron":
                case "Iron":
                    return share * IronPrice;
                    break;
                case "goods":
                case "Goods":
                    return share * GoodsPrice;
                    break;
                case "luxury":
                case "Luxury":
                    return share * LuxuryPrice;
                    break;
            }
            return 0;
        }

    };
}
