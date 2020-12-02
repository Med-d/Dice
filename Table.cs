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
            if (leftValue == dice.Left)
                return true;
            else if (leftValue == dice.Right)
                return true;
            else if (rightValue == dice.Left)
                return true;
            else if (rightValue == dice.Right)
                return true;
            return false;
        }

        public bool MakeMove(Dice dice)
        {
            if (dices.Count == 0)
            {
                (leftValue, rightValue) = (dice.Left, dice.Right);
                dices.Add(dice);
                return true;
            }
            for (var i = 0; i < 2; ++i)
            {
                if (dice.Left == rightValue)
                {
                    rightValue = dice.Right;
                    dices.Add(dice);
                    return true;
                }
                else if (dice.Right == leftValue)
                {
                    leftValue = dice.Left;
                    dices.Insert(0, dice);
                    return true;
                }
                dice.Rotate();
            }
            return false;
        }

        public void ShowTable()
        {
            if (dices.Count == 0)
            {
                Console.WriteLine("There is no dices");
                return;
            }
            foreach(var dice in dices)
            {
                Console.Write("|{0}|", dice.ToString());
            }
            Console.WriteLine("");
        }
    }
}
