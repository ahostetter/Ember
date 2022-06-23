namespace Ember
{
    internal class Modifiers
    {
        public static string playerName()
        {
            string name = "Artemis";
            return name;
        }

        public static double maxPlayerHealth()
        {
            double health = 1500;
            return health;
        }

        public static double playerHealth()
        {
            double health = maxPlayerHealth();
            return health;
        }

        public static double playerStrength()
        {
            double strength = 10;
            return strength;
        }

        public static double playerCurrentDamage()
        {
            double currentDamage = 0;
            return currentDamage;
        }

        public static double playerBaseDamage()
        {
            double baseDamage = 100;
            return baseDamage;
        }

        public static double playerStartingLevel()
        {
            double startLevel = 1;
            return startLevel;
        }

        public static double playerXP()
        {
            double playerXP = 0;
            return playerXP;
        }

        public static double playerCritChance()
        {
            double critChance = .5;
            return critChance;
        }

        public static double playerCritDamage()
        {
            double critDamage = .2;
            return critDamage;
        }

        public static double playerEvasiveness()
        {
            double evasiveness = .5;
            return evasiveness;
        }

        public static double playerLuck()
        {
            double luck = .5;
            return luck;
        }

        public static bool playerAlive()
        {
            bool alive = true;
            return alive;
        }

        public static double scaleStrength()
        {
            double strengthScale = 3;
            return strengthScale;
        }

        public static double scaleLevel()
        {
            double levelScale = .1;
            return levelScale;
        }
    }
}
