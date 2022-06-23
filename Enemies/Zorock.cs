using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ember.Enemies
{
    internal class Zorock : Enemy
    {
        public int cardsID = 20;

        public Zorock(double aHealth) : base(aHealth)
        {
            health = aHealth;
        }
    }
}
