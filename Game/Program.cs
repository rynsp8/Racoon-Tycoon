using Game;
using Spectre.Console;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

public class Program
{

    static void Main()
    {
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Fill);
        title splash = new title();

        splash.titleDisplay();

        int numberOfPlayers = AnsiConsole.Ask<int>("How many people will be playing today?");
        AnsiConsole.MarkupLine($"Good, we have [green]{numberOfPlayers}[/] players today\n\n");

        var player = new List<player>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            var playerName = AnsiConsole.Ask<string>($"What is player{i + 1}'s name?");
            player.Add(new player() {playerposition = i + 1, name = playerName});
        }
        
        foreach (var person in player)
        {
            Console.WriteLine("Player{0} is {1}", person.playerposition, person.name);
        }

        bool quit = false;

        while (!quit) 
        {
            foreach (var person in player)
            {
                AnsiConsole.MarkupLine("Player{0}, {1}, it is your turn.  " +
                    "Please choose from the below player actions", person.playerposition, person.name);
                var playerAction = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Player Turn Action[/]?")
                        .PageSize(10)
                        .AddChoices(new[] {
                            "Produce Commodities",
                            "Sell Commodities",
                            "Purchase a Building",
                            "Purchase a Town",
                            "Start a railroad auction"
                        }));

                switch (playerAction) 
                {
                    case "Produce Commodities":
                        AnsiConsole.MarkupLine("You are producing commodities!");
                        person.produceCommodities();
                        var table = new Table();
                        table.AddColumn("Commodity");
                        table.AddColumn(new TableColumn("Owned Shares").Centered());
                        //table.AddColumn("Owned Commodity");
                        //table.AddRow("Lumber", person.OwnedCommodities.lumber);
                        //table.AddRow("Wheat", person.OwnedCommodities.wheat);
                        //table.AddRow("Coal", person.OwnedCommodities.coal);
                        //table.AddRow("Iron", person.OwnedCommodities.iron);
                        //table.AddRow("Goods", person.OwnedCommodities.goods);
                        //table.AddRow("Luxury", person.OwnedCommodities.luxury);

                        break;
                    case "Sell Commodities":
                        AnsiConsole.MarkupLine("You are selling commodities!");
                        var commoditiy = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Which commodity will you sell?")
                            .PageSize(10)
                            .AddChoices(new[] {
                                "Lumber",
                                "Wheat",
                                "Coal",
                                "Iron",
                                "Goods",
                                "Luxury"
                            }));
                        var ownedCommoditiy = person.OwnedCommodities.commodityCheck(commoditiy);
                        Console.WriteLine("Very good {1}, now how many of your commodity will you sell?", person.name);
                        Console.WriteLine($"You own {ownedCommoditiy} shares of {commoditiy}");
                        var commodityAmount = AnsiConsole.Ask<int>("How many?");
                        person.sellCommodities(commoditiy, commodityAmount);
                        break;
                    case "Purchase a Building":
                        AnsiConsole.MarkupLine("You are purchasing a building!");
                        //person.purchaseBuilding();
                        break;
                    case "Purchase a Town":
                        AnsiConsole.MarkupLine("You are purchasing a town!");
                        //person.purchaseTown();
                        break;
                    case "Start a railroad auction":
                        AnsiConsole.MarkupLine("You are starting a railroad auction!");
                        break;
                }
            }
        }




        Thread.Sleep(5000);

        






    }
}



