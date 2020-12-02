using System;
using System.Collections.Generic;

namespace Domino
{
    public class Game
    {
        Table table;
        Bazaar bazaar;
        List<Player> players;
        int whichPlayerIsMoving;
        public bool gameIsGoing;

        public Game()
        {
            gameIsGoing = true;
            table = new Table();
            bazaar = new Bazaar();
            players = new List<Player>();
            players.Add(new Player(table, bazaar));
            players.Add(new Player(table, bazaar));

            var firstPlayerHand = players[0].hand;
            var secondPlayerHand = players[1].hand;
            var smallestDouble = 7;
            for (var i = 0; i < 7; ++i)
            {
                if (firstPlayerHand[i].IsDouble() && firstPlayerHand[i].Left != 0)
                {
                    smallestDouble = firstPlayerHand[i].Left;
                    whichPlayerIsMoving = 0;
                }
                if (secondPlayerHand[i].IsDouble() && secondPlayerHand[i].Left != 0 
                    && secondPlayerHand[i].Left < smallestDouble)
                {
                    smallestDouble = secondPlayerHand[i].Left;
                    whichPlayerIsMoving = 1;
                }
            }
        }

        public void Help()
        {
            Console.WriteLine(
                @"Welcome! This is the worst console-using game ever! Yeah, it is a dice on one PC
You can use next commands to play:

Who is moving: if you don`t know which player move now, you can write this command
Possible moves: show possible moves
Take dice: takes one dice from bazaar (if bazaar not empty)
Watch my dices: show dices in your hand whith there index
Move <index>: put dice whith <index> on table
Show table: show line of dices on table
Help: write this if you want to see this message again");
        }

        private void WhoIsMoving()
        {
            Console.WriteLine(whichPlayerIsMoving == 0 ?
                "First player is moving" :
                "Second player is moving");
        }

        private void ChangeMovingPlayer()
        {
            whichPlayerIsMoving = whichPlayerIsMoving == 0 ? 1 : 0;
            WhoIsMoving();
        }

        private bool IsFish()
        {
            bool fish = true;
            if (!bazaar.IsEmpty())
                return false;
            for (var i = 0; i < 2; ++i)
            {
                foreach (var dice in players[i].hand)
                {
                    if (table.PossibleMove(dice))
                        fish = false;
                }
            }
            return fish;
        }

        private bool CheckEnding()
        {
            if (bazaar.IsEmpty())
            {
                if (players[0].hand.Count == 0)
                {
                    Console.WriteLine("First player win!");
                    return true;
                }
                if (players[1].hand.Count == 0)
                {
                    Console.WriteLine("Second player win!");
                    return true;
                }
                if (IsFish())
                {
                    Console.WriteLine("Fish!");
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CanPlayerMove()
        {
            if(CheckEnding())
                gameIsGoing = false;
            if (!bazaar.IsEmpty())
                return;
            foreach(var dice in players[whichPlayerIsMoving].hand)
            {
                if (table.PossibleMove(dice))
                    return;
            }
            Console.WriteLine("This player can`t move\nChanging player");
            ChangeMovingPlayer();
        }

        public void DoAction(Action action, params int[] param)
        {
            switch (action)
            {
                case Action.WhoIsMoving:
                    WhoIsMoving();
                    break;
                case Action.PossibleMove:
                    table.PossibleMove();
                    break;
                case Action.TakeDiceFromBazaar:
                    if (!players[whichPlayerIsMoving].TakeDiceFromBazaar())
                        return;
                    break;
                case Action.WatchYourHand:
                    players[whichPlayerIsMoving].WatchYourHand();
                    break;
                case Action.MakeMove:
                    if (!players[whichPlayerIsMoving].MakeMove(param[0]))
                        return;
                    ChangeMovingPlayer();
                    break;
                case Action.ShowTable:
                    table.ShowTable();
                    break;
                case Action.Help:
                    Help();
                    break;
                default:
                    Console.WriteLine("Unregistred action\nTry again!");
                    return;
            }
            if (CheckEnding())
                gameIsGoing = false;
        }
    }
}
