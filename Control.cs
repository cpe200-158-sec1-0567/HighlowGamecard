using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowgamecard
{
    class Control
    {
        static Deck _deck;
        public static void ready()
        {
            _deck = new Deck(13, 4);
            _deck.Shuffle();
            //base_deck.ViewCardsinDeck();
            Console.WriteLine("READY");
        }
        public static void NewPlayers(players Player1, players Player2, string PlayerName1 = "pae", string PlayerName2 = "challen")
        {
            Console.WriteLine("Creating new two players");
            Console.Write("[" + Player1.name + "] What's your name? : ");
            PlayerName1 = Console.ReadLine();
            Console.Write("[" + Player2.name + "] What's your name? : ");
            PlayerName2 = Console.ReadLine();
            Player1.name = PlayerName1;
            Player2.name = PlayerName2;
            Console.WriteLine("[player1] is " + Player1.name);
            Console.WriteLine("[player2] is " + Player2.name);
        }
        public static void GiveADeck(players Player1, players Player2)
        {
            for (int i = 0; i < 26; i++)
            {
                Player1.deck.Cards.Add(_deck.Cards[i]);
            }
            for (int i = 0; i < 26; i++)
            {
                Player2.deck.Cards.Add(_deck.Cards[i + 26]);
            }
           
        }
        public static void RemoveCards(players Player1, players Player2, int range)
        {
            int LastCard = Player1.deck.Cards.Count - 1;
            Player1.deck.Cards.RemoveRange(LastCard - range + 1, range);
            Player2.deck.Cards.RemoveRange(LastCard - range + 1, range);
            //Console.WriteLine("[Remove] " + range + " card(s) of both players card deck");
        }
        public static void PlayerWinTurn(players Player, int NumberofCards = 1)
        {
            Player.count += (NumberofCards) * 2;
            Console.WriteLine("[WIN][" + Player.name + "] get 2 card ");
        }
        public static void newshuffle(players Player1, players Player2)
        {
            Console.WriteLine("[Tie] Reshuffle the both players card deck");
            Player1.deck.Shuffle();
            Player2.deck.Shuffle();
        }
        public static int CompareCardDeck(players Player1,players Player2)
        {
            if (Player1.deck.Cards.Count == 0) // No longer be playing
            {
                Console.WriteLine("[Summary] No more card left in the both players card deck");
                return -1;
            }
            int LastCard = Player1.deck.Cards.Count - 1;
            int Player1_last = Player1.deck.Cards[LastCard].number;
            int Player2_last = Player2.deck.Cards[LastCard].number;
            Console.WriteLine("[" + Player1.name + "] \thas " + Player1.deck.Cards[LastCard]);
            Console.WriteLine("[" + Player2.name + "] \thas " + Player2.deck.Cards[LastCard]);
            if  (Player1.deck.Cards.Count == 1 && Player1.deck.Cards[LastCard].number == Player2.deck.Cards[LastCard].number) { 

                return -1;
            }
            if (Player1_last == Player2_last)
            {
                bool Continue_Game = true;
                for (int i = 0; i <= LastCard; i++)
                {
                    for (int j = 0; j <= LastCard; j++)
                    {
                        if (Player1.deck.Cards[i].number> Player2.deck.Cards[j].number)
                        {
                            Continue_Game = false;
                        }
                        else
                        {
                            Continue_Game = true;
                        }
                    }
                }
                if (!Continue_Game)
                {
                    Console.WriteLine("== [" + Player1.name + "] Card deck is containing these cards :");
                   
                    Console.WriteLine("== [" + Player2.name + "] Card deck is containing these cards :");
                   
                    return -1;
                }
                int NumberFromLastCard = Player1_last;
                if (NumberFromLastCard > LastCard) 
                {
                    newshuffle(Player1, Player2);
                    
                    return 0;
                }
                Console.WriteLine("[" + Player1.name + "] has " + Player1.deck.Cards[NumberFromLastCard]);
                Console.WriteLine("[" + Player2.name + "] has " + Player2.deck.Cards[NumberFromLastCard]);
                int pPlayer1_fromlast = Player1.deck.Cards[NumberFromLastCard].number;
                int pPlayer2_fromlast = Player2.deck.Cards[NumberFromLastCard].number;
                if (pPlayer1_fromlast < pPlayer2_fromlast) 
                {
                    PlayerWinTurn(Player1, NumberFromLastCard);
                    RemoveCards(Player1, Player2, NumberFromLastCard);
                    return 1;
                }
                else if (pPlayer1_fromlast > pPlayer2_fromlast) // Player 2 WIN
                {
                    PlayerWinTurn(Player2, NumberFromLastCard);
                    RemoveCards(Player1, Player2, NumberFromLastCard);
                    return 2;
                }
                else 
                {
                    newshuffle(Player1, Player2);
                    return 0;
                }
            }
           
            else if (Player1_last < Player2_last)
            {
                PlayerWinTurn(Player1);
                RemoveCards(Player1, Player2, 1);
                return 1;
            }
            // Player 2 WIN
            else if (Player1_last > Player2_last)
            {
                PlayerWinTurn(Player2);
                RemoveCards(Player1, Player2, 1);
                return 2;
            }
            return -1;
        }

        public static void FinishedPlaying(players Player1, players Player2)
        {
            Console.WriteLine("");
            Console.WriteLine("=== [ The winner is " + (Player1.count > Player2.count ? Player1.name : Player2.name) + " ] ===");
        }
    }
}

    

