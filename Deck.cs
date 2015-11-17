using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowgamecard
{
    class Deck
    {
        public List<Card> Cards;
        public Deck()
        {
            Cards = new List<Card>();
        }
        public Deck (int dnumber =13,int dsuit = 4) : this()
        {
            for(int i = 0; i < dnumber; i++)
            {
                for(int j=0; j < dsuit; j++)
                {
                    Cards.Add(new Card { number = i + 1, suit = j + 1 });
                }
            }
        }
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                var j = random.Next(i, Cards.Count);
                var temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }

    }
}
