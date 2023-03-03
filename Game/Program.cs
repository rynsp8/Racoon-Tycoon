using Game;
using Spectre.Console;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    
    static void Main()
    {
        player Player1 = new player();
        player Player2 = new player();
        Player1.name = "Ryan";
        Player2.name = "Milo";

        Player1.purchaseTown(Player1.name);


        //Console.WriteLine($"\n\nWelcome to the Raccoon Tycoon Market! Starting Prices are below!\n" +
        //    $"Wheat is ${Market.WheatPrice}\n" +
        //    $"Lumber is ${Market.LumberPrice}\n" +
        //    $"Iron is ${Market.IronPrice} \n" +
        //    $"Coal is ${Market.CoalPrice} \n" +
        //    $"Goods are ${Market.GoodsPrice} \n" +
        //    $"Luxury is ${Market.LuxuryPrice}  \n\n");

        //for (int i = 0; i < 8; i++)
        //{
        //    Player1.produceCommodities();
        //    Player2.produceCommodities();
        //}

        //Console.WriteLine($"Welcome {Player1.name}.  Record of commodities you own:\n" +
        //    $"{Player1.OwnedCommodities.wheat} Wheat\n" +
        //    $"{Player1.OwnedCommodities.lumber} Lumber\n" +
        //    $"{Player1.OwnedCommodities.iron} Iron\n" +
        //    $"{Player1.OwnedCommodities.coal} Coal\n" +
        //    $"{Player1.OwnedCommodities.goods} Goods\n" +
        //    $"{Player1.OwnedCommodities.luxury} Luxury\n" +
        //    $"and you have ${Player1.capital} in capital\n\n");

        //Console.WriteLine($"Welcome {Player2.name}.  Record of commodities you own:\n" +
        //    $"{Player2.OwnedCommodities.wheat} Wheat\n" +
        //    $"{Player2.OwnedCommodities.lumber} Lumber\n" +
        //    $"{Player2.OwnedCommodities.iron} Iron\n" +
        //    $"{Player2.OwnedCommodities.coal} Coal\n" +
        //    $"{Player2.OwnedCommodities.goods} Goods\n" +
        //    $"{Player2.OwnedCommodities.luxury} Luxury\n" +
        //    $"and you have ${Player2.capital} in capital\n\n");

        //Player1.purchaseTown(Player1.name);
        //Console.WriteLine($"After purchasing a town {Player1.name} owns:\n" +
        //    $"{Player1.OwnedCommodities.wheat} Wheat\n" +
        //    $"{Player1.OwnedCommodities.lumber} Lumber\n" +
        //    $"{Player1.OwnedCommodities.iron} Iron\n" +
        //    $"{Player1.OwnedCommodities.coal} Coal\n" +
        //    $"{Player1.OwnedCommodities.goods} Goods\n" +
        //    $"{Player1.OwnedCommodities.luxury} Luxury\n" +
        //    $"and you have ${Player1.capital} in capital\n\n");


        //Player2.purchaseTown(Player2.name);
        //Console.WriteLine($"After purchasing a town {Player2.name} owns:\n" +
        //    $"{Player2.OwnedCommodities.wheat} Wheat\n" +
        //    $"{Player2.OwnedCommodities.lumber} Lumber\n" +
        //    $"{Player2.OwnedCommodities.iron} Iron\n" +
        //    $"{Player2.OwnedCommodities.coal} Coal\n" +
        //    $"{Player2.OwnedCommodities.goods} Goods\n" +
        //    $"{Player2.OwnedCommodities.luxury} Luxury\n" +
        //    $"and you have ${Player2.capital} in capital\n\n");

        


        //Console.WriteLine($"\n\nAfter producing commodities, we now see that the prices have grown!\n" +
        //    $"Wheat is ${Market.WheatPrice}\n" +
        //    $"Lumber is ${Market.LumberPrice}\n" +
        //    $"Iron is ${Market.IronPrice} \n" +
        //    $"Coal is ${Market.CoalPrice} \n" +
        //    $"Goods are ${Market.GoodsPrice} \n" +
        //    $"Luxury is ${Market.LuxuryPrice}  \n\n");

        //Player1.sellCommodities("wheat", 1);
        //Player2.sellCommodities("coal", 1);

        //Console.WriteLine($"{Player1.name} now has ${Player1.capital}!\n");
        //Console.WriteLine($"{Player2.name} now has ${Player2.capital}!\n");

        //Player1.purchaseBuilding("wheatfield", Player1.name);
        //Player1.buildingtest("wheatfield");
        //Player2.purchaseBuilding("toolanddie", Player2.name);
        //Player1.produceCommodities();
        //Player2.produceCommodities();

        //Player2.buildingtest("wheatfield");
        //var ownedbuildings = buildingDict.InitializeBuildings();
        //Console.WriteLine($"There are {ownedbuildings.Count} builidngs for sale");
        //Console.WriteLine($"{ownedbuildings["wheatfield"].name} is sold at ${ownedbuildings["wheatfield"].price}");



    }
}



