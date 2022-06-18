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

        //Starting Deck Size
        int deckSize = 4;

        //Initiate empty starting deck
        List<string> deck = new List<string>();

        // Initiates the starting deck
        Deck playerDeck = new Deck(deckSize, deck);

        // Loads the player with all of the base stats, and the player has the deck
        Player player = new Player(Modifiers.playerName(), Modifiers.maxPlayerHealth(), Modifiers.playerHealth(), Modifiers.playerStrength(), Modifiers.playerCurrentDamage(),
            Modifiers.playerBaseDamage(), Modifiers.playerStartingLevel(), Modifiers.playerXP(), Modifiers.playerCritChance(), Modifiers.playerCritDamage(),
            Modifiers.playerEvasiveness(), Modifiers.playerLuck(), playerDeck, Modifiers.playerAlive());

        //Load the deck with cards
        Cards.chooseCard(player, deckSize);

        // User Options
        var cardChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
                .AddChoices((player.deck.cards)));

        Cards.playCard(player, cardChoice);

        Cards.winCard(player);

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
