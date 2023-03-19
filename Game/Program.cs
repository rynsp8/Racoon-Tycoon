using Game;
using SixLabors.ImageSharp;
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
                var playerName = person.name;
                var playerNumber = person.playerposition;              

                AnsiConsole.MarkupLine("[green]Player{0}, {1}[/], it is your turn.  " +
                    "Please choose from the below player actions", person.playerposition, person.name);

                Console.Clear();

                repeatPlayerAction:
                var playerAction = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title($"Player{playerNumber}, {playerName}'s Turn Action?")
                        .PageSize(10)
                        .AddChoices<string>(new[] {
                            "View Price of Commodities",
                            "Produce Commodities",
                            "Sell Commodities",
                            "Purchase a Building",
                            "Purchase a Town",
                            "Start a railroad auction",
                            "Quit Game"
                        }));

                switch (playerAction) 
                {
                    case "View Price of Commodities":
                        Market.displayMarket();
                        goto repeatPlayerAction;

                    case "Produce Commodities":
                        person.produceCommodities();

                        var produceTable = new Table();
                        produceTable.AddColumn("Commodity");
                        produceTable.AddColumn(new TableColumn("Owned Shares").Centered());
                        produceTable.AddRow(new Markup("Lumber"), new Markup($"{person.OwnedCommodities.lumber}"));
                        produceTable.AddRow(new Markup("Wheat"), new Markup($"{person.OwnedCommodities.wheat}"));
                        produceTable.AddRow(new Markup("Coal"), new Markup($"{person.OwnedCommodities.coal}"));
                        produceTable.AddRow(new Markup("Iron"), new Markup($"{person.OwnedCommodities.iron}"));
                        produceTable.AddRow(new Markup("Goods"), new Markup($"{person.OwnedCommodities.goods}"));
                        produceTable.AddRow(new Markup("Luxury"), new Markup($"{person.OwnedCommodities.luxury}"));

                        AnsiConsole.MarkupLine($"{person.name}, you have produced commodities!");
                        AnsiConsole.Write(produceTable);
                        if(AnsiConsole.Confirm("Continue?"))
                        {
                            continue; 
                        }
                       
                        break;

                    case "Sell Commodities":
                        AnsiConsole.MarkupLine("You are selling commodities!");
                        var sellTable = new Table();
                        sellTable.AddColumn("Commodity");
                        sellTable.AddColumn(new TableColumn("Owned Shares").Centered());
                        sellTable.AddRow(new Markup("Lumber"), new Markup($"{person.OwnedCommodities.lumber}"));
                        sellTable.AddRow(new Markup("Wheat"), new Markup($"{person.OwnedCommodities.wheat}"));
                        sellTable.AddRow(new Markup("Coal"), new Markup($"{person.OwnedCommodities.coal}"));
                        sellTable.AddRow(new Markup("Iron"), new Markup($"{person.OwnedCommodities.iron}"));
                        sellTable.AddRow(new Markup("Goods"), new Markup($"{person.OwnedCommodities.goods}"));
                        sellTable.AddRow(new Markup("Luxury"), new Markup($"{person.OwnedCommodities.luxury}"));
                        AnsiConsole.Write(sellTable);

                        var commoditiy = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title($"Which commodity will you sell, {person.name}?")
                            .PageSize(10)
                            .AddChoices(new[] {
                                "Lumber",
                                "Wheat",
                                "Coal",
                                "Iron",
                                "Goods",
                                "Luxury"
                            }));
                        int ownedCommoditiy = person.OwnedCommodities.commodityCheck(commoditiy);
                        Console.WriteLine($"Very good {playerName}, now how many shares of {commoditiy} will you sell?");
                        Console.WriteLine($"You own {ownedCommoditiy} shares of {commoditiy}");
                        var commodityAmount = AnsiConsole.Ask<int>("How many?");
                        person.sellCommodities(commoditiy, commodityAmount);

                        int profit = Market.profit(commoditiy, commodityAmount);
                        if (AnsiConsole.Confirm("Continue?"))
                        {
                            continue;
                        }
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
                if (playerAction == "Quit Game")
                {
                    if (AnsiConsole.Confirm("Are you [red]sure[/] you want to quit!?"))
                    {
                        AnsiConsole.MarkupLine("Well [red]good day[/] to you then!");
                        Thread.Sleep(3000);
                        System.Environment.Exit(0);
                    }
                }
            }
        }
    }
}



