using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowgamecard
{
    class Program
    {
        static void Main(string[] args)
        {
            players player1 = new players(1);
            players player2 = new players(2);
            Control.ready();
            Control.NewPlayers(player1, player2);
            Control.GiveADeck(player1, player2);

            Console.WriteLine("");
            Console.WriteLine("> STARTING GAME <");

            int result = 0;
            int turn = 1;
            do
            {
                Console.WriteLine("___ {Turn " + turn + " } ___ ");
               
                result = Control.CompareCardDeck(player1, player2);
                player1.ShowPlayerProperties();
                player2.ShowPlayerProperties();
                if (player1.deck.Cards.Count == 0)
                {
                    Console.WriteLine("[Summary] No more card left in the both players card deck");
                    break;
                }
                Console.WriteLine("");
                ++turn;
                //Console.ReadKey();
            } while (result != -1);
            Control.FinishedPlaying(player1, player2);
            Console.ReadKey();
        }
    }
}
