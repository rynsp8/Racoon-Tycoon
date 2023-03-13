using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class title
    {
        public void titleDisplay() 
        {
            //Start the application with a splash screen and menu options

            var gameStart = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Welcome to Raccoon Tycoon!")
                    .PageSize(3)
                    .AddChoices(new[] {
                        "Start New Game",
                        "Quit"
                    }));

            

            if (gameStart == "Quit")
            {
                AnsiConsole.Markup("[Bold]You're really missing out.[/]");
                Thread.Sleep(5000);
                System.Environment.Exit(0);
            }

            var layout = new Layout("Root")
                .SplitRows(
                    new Layout("Top")
                    .SplitRows(
                        new Layout("rootTitle"),
                        new Layout("rootCreator")),
                    new Layout("Bottom")
                );
            //Raccoon Tycoon title
            var rootTitle = new Panel(new FigletText("Raccoon Tycoon!")
                .Color(Color.Red).Centered());
            rootTitle.Border = BoxBorder.None;
            rootTitle.Expand = false;

            //Raccoon Tycoon creator
            var rootAuthor = new Panel(
                Align.Center(
                    new Markup("[green]by Glenn Drover[/]"))
                );
            rootAuthor.Border = BoxBorder.None;
            rootAuthor.Expand = false;

            //Bottom panel
            var bottomPanel = new Panel("");
            bottomPanel.Border = BoxBorder.None;

            layout["rootTitle"].Update(
                rootTitle
                ).Ratio(1);
            layout["rootCreator"].Update(
                rootAuthor
                ).Ratio(1);
            layout["Bottom"].Update(
                bottomPanel
                );

            Thread.Sleep(5000);


            AnsiConsole.Write(layout);

            

        }
    }
}
