using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.BL
{
    class Card
    {
        private int Value;
        private int Suit;
        public Card(int Value, int Suit)
        {
            this.Value = Value;
            this.Suit = Suit;
        }
        public int GetValue()
        {
            return Value;
        }
        public int GetSuit()
        {
            return Suit;
        }
        public string GetValueAsString()
        {
            string value;
            if (Value == 1)
            {
                value = "Ace";
            }
            else if (Value == 11)
            {
                value = "Jack";
            }
            else if (Value == 12)
            {
                value = "Queen";
            }
            else if (Value == 13)
            {
                value = "King";
            }
            else
            {
                value = Value.ToString();
            }
            return value;
        }
        public string GetSuitAsString()
        {
            string suit;
            if (Suit == 1)
            {
                suit = "Clubs";
            }
            else if (Suit == 2)
            {
                suit = "Diamonds";
            }
            else if (Suit == 3)
            {
                suit = "Spades";
            }
            else
            {
                suit = "Hearts";
            }
            return suit;
        }
        public string CardName()
        {
            return GetValueAsString() + " of " + GetSuitAsString();
        }
    }
}
