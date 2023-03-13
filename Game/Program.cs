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

        var numberOfPlayers = 0;

        var numberOfPlayers2 = AnsiConsole.Ask<string>("How many people will be playing today?");
        AnsiConsole.MarkupLine($"Good, we have [green]{numberOfPlayers}[/] players today");

        var player = new List<player>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            var playerName = AnsiConsole.Ask<string>($"What is player{i + 1}'s name?");
            new player() {playerposition = i, name = playerName};

        }

        player.ForEach(e  => Console.WriteLine(e));


        Thread.Sleep(10000);

        






    }
}



