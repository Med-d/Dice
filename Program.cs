using System;

namespace Domino { 
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Dice v1.0beta by med-d\n");
            var game = new Game();
            game.Help();
            while (game.gameIsGoing)
            {
                var action = Console.ReadLine().Trim().ToLower();
                if (action == "who is moving")
                {
                    game.DoAction(Action.WhoIsMoving);
                }
                else if (action == "possible moves")
                {
                    game.DoAction(Action.PossibleMove);
                }
                else if(action == "take dice")
                {
                    game.DoAction(Action.TakeDiceFromBazaar);
                }
                else if (action == "whatch my dices")
                {
                    game.DoAction(Action.WhatchYourHand);
                }
                else if (action == "help")
                {
                    game.DoAction(Action.Help);
                }
                else if (action.Length >= 4 && action.Substring(0, 4) == "move")
                {
                     game.DoAction(Action.MakeMove, 
                        int.Parse(action.Substring(5, action.Length - 5)));
                }
                else if (action.Length == 0)
                {
                    continue;
                }
                else
                {
                    game.DoAction(Action.Default);
                }
            }
            Console.WriteLine("End");
        }
    }
}