using System;
using System.Collections.Generic;

namespace Domino
{
    public class Player
    {
        public List<Dice> hand;
        private Table table;
        private Bazaar bazaar;

        public Player(Table table, Bazaar bazaar)
        {
            this.table = table;
            this.bazaar = bazaar;
            hand = new List<Dice>();
            for (var i = 0; i < 7; ++i)
                hand.Add(this.bazaar.GetDice());
        }

        public void WatchYourHand()
        {
            var i = 1;
            foreach (var dice in hand)
            {
                Console.WriteLine("{0} - {1}", i, dice.ToString());
                i++;
            }
        }

        public bool MakeMove(int diceNumber)
        {
            if(!table.MakeMove(hand[diceNumber - 1]))
            {
                Console.WriteLine("Wrong move\nTry again!");
                return false;
            }
            hand.RemoveAt(diceNumber - 1);
            return true;
        }

        public bool TakeDiceFromBazaar()
        {
            if (bazaar.IsEmpty())
            {
                Console.WriteLine("Bazaar is empty!");
                return false;
            }
            var newDice = bazaar.GetDice();
            if (newDice != null)
                hand.Add(newDice);
            else
                Console.WriteLine("Somthing went wrong!");
            return true;
        }
    }
}
