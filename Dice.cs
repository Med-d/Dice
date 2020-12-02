using System;

namespace Domino
{
    public class Dice
    {
        private int leftSide;
        public int Left
        {
            get => leftSide;
            private set
            {
                leftSide = value;
            }
        }

        private int rightSide;
        public int Right
        {
            get => rightSide;
            private set
            {
                rightSide = value;
            }
        }

        public Dice(int a, int b)
        {
            leftSide = a;
            rightSide = b;
        }

        public void Rotate()
        {
            (leftSide, rightSide) = (rightSide, leftSide);
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
