using System;
using System.Collections.Generic;

namespace Domino {
    public class Table
    {
        private int leftValue;
        private int rightValue;
        private List<Dice> dices;

        public Table()
        {
            dices = new List<Dice>();
        }

        public void PossibleMove()
        {
            if (dices.Count == 0)
            {
                Console.WriteLine("There is no dices\nMake first move");
                return;
            }
            Console.WriteLine("Left side: {0}\nRight side: {1}", leftValue, rightValue);
        }

        public bool PossibleMove(Dice dice)
        {
            if (leftValue == dice.leftSide)
                return true;
            else if (leftValue == dice.rightSide)
                return true;
            else if (rightValue == dice.leftSide)
                return true;
            else if (rightValue == dice.rightSide)
                return true;
            return false;
        }

        public bool MakeMove(Dice dice)
        {
            if (dices.Count == 0)
                (leftValue, rightValue) = (dice.leftSide, dice.rightSide);
            else if (leftValue == dice.leftSide)
                leftValue = dice.rightSide;
            else if (leftValue == dice.rightSide)
                leftValue = dice.leftSide;
            else if (rightValue == dice.leftSide)
                rightValue = dice.rightSide;
            else if (rightValue == dice.rightSide)
                rightValue = dice.leftSide;
            else
                return false;
            dices.Add(dice);
            return true;
        }
    }
}
