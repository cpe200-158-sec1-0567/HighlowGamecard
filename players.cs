using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowgamecard
{
    class players
    {
        private Deck _deck;
        private int _count;
        private string _name;
        private int _order = 0;

        public Deck deck
        {
            get { return _deck; }
            set { _deck = value; }
        }
        public int count
        {
            get { return _count; }
            set { _count = value; }
        }
        public string name
        {
            get;
            set;
        }
        public int order
        {
            get;
            set;
        }
        public  players(int porder )
        {
            deck = new Deck();
            count = 0;
            name = "unknow";
            order = porder;

        }
        public void ShowPlayerProperties()
        {
            Console.WriteLine("[" + name + "] | " + _deck.Cards.Count + " playing card(s) |, | " + count + " win |");
        }
    }
}
