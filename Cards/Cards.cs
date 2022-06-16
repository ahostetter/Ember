namespace Ember
{
    internal class Cards
    {
        public static void playCard(Player player, String playerCardChoice)
        {
            if (playerCardChoice == "vendetta")
            {
                vendetta(player);
            }
            else if (playerCardChoice == "vendetta1")
            {
                vendetta1(player);
            }
            else if (playerCardChoice == "vendetta2")
            {
                vendetta2(player);
            }
            else if (playerCardChoice == "vendetta3")
            {
                vendetta3(player);
            }
            else if (playerCardChoice == "vendetta4")
            {
                vendetta4(player);
            }
        }

        public static void vendetta(Player player)
        {
            player.alive = false;
            Console.WriteLine("you played card Vendetta");
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
