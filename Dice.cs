using System;

namespace Domino
{
    public class Dice
    {
        public readonly int leftSide;
        public readonly int rightSide;

        public Dice(int a, int b)
        {
            leftSide = a;
            rightSide = b;
        }

        public override string ToString()
        {
            return leftSide.ToString() + "|" + rightSide.ToString();
        }

        public bool IsDouble()
        {
            return leftSide == rightSide;
        }
    }
}
