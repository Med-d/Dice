using System;
using System.Collections.Generic;

namespace Domino
{
    public class Bazaar
    {
        private List<Dice> bazaar;
        public Bazaar()
        {
            bazaar = new List<Dice>();
            for (var i = 0; i < 7; ++i)
            {
                for (var j = 0; j <= i; ++j)
                {
                    bazaar.Add(new Dice(i, j));
                }
            }
        }

        public Dice GetDice()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Bazaar is empty!");
                return null;
            }
            var randomDice = bazaar[new Random().Next(bazaar.Count)];
            if (!bazaar.Remove(randomDice))
                throw new Exception("Can`t remove element");
            return randomDice;
        }

        public bool IsEmpty()
        {
            return bazaar.Count == 0;
        }
    }
}
