using Spectre.Console;

namespace Ember
{
    internal class Cards
    {
        public string name;
        public double damage;

        public Cards(string aName, double aDamage)
        {
            name = aName;
            damage = aDamage;
        }

        public static void winCard(Player player)
        {
            if (true)
            {
                //if certain goals are met then add new card potential cards to start game.
                player.deck.cards.Add("testCard");
                player.deck.cards.ForEach(card => Console.Write(card + ","));

            }
        }

        public static Deck chooseCard(Player player, int deckSize)
        {
            bool playFair = false;

            while (playFair == false)
            {
                // What Cards will the player Choose
                var cards = AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                    .Title("Select your [green]cards[/]?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more cards)[/]")
                    .InstructionsText(
                        "[grey](Press [blue]<space>[/] to toggle a card, " +
                        "[green]<enter>[/] to accept)[/]")
                    .AddChoices(new[] {
            "vendetta", "vendetta1", "vendetta2",
            "vendetta3", "vendetta4",
                    }));

                if (cards.Count <= deckSize)
                {
                    playFair = true;
                    player.deck = new Deck(deckSize, cards);
                }
                else
                {
                    Console.WriteLine("You selected too many cards!");
                }
            }

            return player.deck;

        }
        public static void playCard(Player player, String playerCardChoice)
        {
            if (playerCardChoice == "vendetta")
            {
                vendetta(player);
                player.deck.cards.Remove(playerCardChoice);
                //player.deck.cards.ForEach(card => Console.Write(card + ","));
            }
            else if (playerCardChoice == "vendetta1")
            {
                vendetta1(player);
                player.deck.cards.Remove(playerCardChoice);
            }
            else if (playerCardChoice == "vendetta2")
            {
                vendetta2(player);
                player.deck.cards.Remove(playerCardChoice);
            }
            else if (playerCardChoice == "vendetta3")
            {
                vendetta3(player);
                player.deck.cards.Remove(playerCardChoice);
            }
            else if (playerCardChoice == "vendetta4")
            {
                vendetta4(player);
                player.deck.cards.Remove(playerCardChoice);
            }
        }

        public static void vendetta(Player player)
        {
            Cards card = new Cards("Vendetta", 300);

            player.alive = false;

            Console.WriteLine("You played card Vendetta");

            // Create a table
            var table = new Table();

            table.Width(35).Border(TableBorder.DoubleEdge);

            // Add some columns
            //table.AddColumn("Vendetta");
            table.AddColumn(new TableColumn(card.name).Centered());

            // Add some rows
            //table.AddRow("Baz", "[green]Qux[/]");
            table.AddRow(new Markup("[blue]No one messes with your people. You attack with more strength then you know you have.[/]"));//, new Panel("Waldo"));

            // Render the table to the console
            AnsiConsole.Write(table);
        }

        public static void vendetta1(Player player)
        {
            player.alive = false;
            Console.WriteLine("you played card Vendetta1");
        }

        public static void vendetta2(Player player)
        {
            player.alive = false;
            Console.WriteLine("you played card Vendetta2");
        }

        public static void vendetta3(Player player)
        {
            player.alive = false;
            Console.WriteLine("you played card Vendetta3");
        }

        public static void vendetta4(Player player)
        {
            player.alive = false;
            Console.WriteLine("you played card Vendetta4");
        }
    }
}
