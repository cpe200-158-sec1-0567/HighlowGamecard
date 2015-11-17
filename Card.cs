using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowgamecard
{
    class Card
    {
        private int _number;
        private int _suit;

        public int number
        {
            get { return _number; }
            set { _number = value; }
        }
        public int suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        protected string[] Suit = {"Clubs","Diamond","Heart","spades" };
        protected string[] Face = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };

        public Card()
        {
            number = 0;
            suit = 0;
        }
        public override string ToString()
        {
            return "[CARD]: Value: " + Face[number - 1] +  Suit[suit- 1] ;
        }


    }
}
