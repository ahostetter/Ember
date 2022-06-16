using Ember;
using Spectre.Console;

bool wantToPlay = true;

while (wantToPlay)
{
    AnsiConsole.Write(
        new FigletText("    EMBER")
        .LeftAligned()
        .Color(Color.Red));

    // User Options
    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
            .AddChoices(new[] {
        "Start Game", "Exit",
            }));

    if (choice == "Start Game")
    {
        // Asynchronous
        await AnsiConsole.Progress()
            .AutoClear(true)
            .StartAsync(async ctx =>
            {
                // Define tasks
                var task1 = ctx.AddTask("[red]Loading Game[/]");

                while (!ctx.IsFinished)
                {
                    // Delay load
                    await Task.Delay(10);

                    // Increment
                    task1.Increment(2);
                }
            });
    }
    else if (choice == "Exit")
    {
        Console.WriteLine("Exiting Game");
        wantToPlay = false;
    }
    else
    {
        Console.WriteLine("You did not put in a correct choice");
    }

    if (wantToPlay == false)
    {
        break;
    }
    bool playerAlive = true;
    bool playerWin = false;

    while (playerAlive == true && playerWin == false)
    {
        // What Cards will the player Choose
        var cards = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title("Select your [green]cards[/]?")
                .NotRequired() // Not required to have a favorite fruit
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                .InstructionsText(
                    "[grey](Press [blue]<space>[/] to toggle a card, " +
                    "[green]<enter>[/] to accept)[/]")
                .AddChoices(new[] {
            "vendetta", "vendetta1", "vendetta2",
            "vendetta3", "vendetta4",
                }));

        // Write the selected fruits to the terminal
        //foreach (string card in cards)
        //{
        //    AnsiConsole.WriteLine(card);
        //}

        //Starting Deck Size
        int deckSize = 5;

        //var cards = new List<string>() { "vendetta", "vendetta1", "vendetta2", "vendetta3", "vendetta4" };

        // Initiates the starting deck
        Deck playerDeck = new Deck(deckSize, cards);

        // Loads the player with all of the base stats, and the player stores the inventory
        Player player = new Player(Modifiers.playerName(), Modifiers.maxPlayerHealth(), Modifiers.playerHealth(), Modifiers.playerStrength(), Modifiers.playerCurrentDamage(),
            Modifiers.playerBaseDamage(), Modifiers.playerStartingLevel(), Modifiers.playerXP(), Modifiers.playerCritChance(), Modifiers.playerCritDamage(),
            Modifiers.playerEvasiveness(), Modifiers.playerLuck(), playerDeck, Modifiers.playerAlive());

        // User Options
        var cardChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
                .AddChoices((cards)));

        Cards.playCard(player, cardChoice);

        // Load state of player after first level
        //player = Level.Level1(player);

        // Checks to make sure player is still alive and if he is then load state of player into Second Level
        if (player.alive)
        {
            // Asynchronous
            await AnsiConsole.Progress()
                .AutoClear(true)
                .StartAsync(async ctx =>
                {
                    // Define tasks
                    var task1 = ctx.AddTask("[red]Loading 2nd Level[/]");

                    while (!ctx.IsFinished)
                    {
                        // Delay load
                        await Task.Delay(10);

                        // Increment
                        task1.Increment(2);
                    }
                });
            //Loads player state into Level 2
            //Level.Level2(player);
        }

        if (!player.alive)
        {
            playerAlive = false;
        }

        if (player.alive)
        {
            playerWin = true;
        }

        if (playerWin)
        {
            Console.WriteLine("You beat the Game!!!");
        }
        else
        {
            Console.WriteLine("You Died...");
        }
    }
}
