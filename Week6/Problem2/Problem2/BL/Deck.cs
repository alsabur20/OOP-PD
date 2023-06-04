using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.BL
{
    class Deck
    {
        private int Count;
        private Card[] Cards = new Card[52];
        public Deck()
        {
            Count = 0;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 13; y++)
                {
                    Cards[Count] = new Card(y, x);
                    Count++;
                }
            }
        }
        public void Shuffle()
        {
            System.Random rand = new Random();
            Card temp;
            for (int i = 0; i < 52; i++)
            {
                int num = rand.Next(0, 51);
                temp = Cards[num];
                Cards[num] = Cards[i];
                Cards[i] = temp;
            }
            Count = 52;
        }

        public Card GetCard()
        {
            if (Count > 0)
            {
                Count--;
                return Cards[Count];
            }
            else
            {
                return null;
            }
        }
        public int CardsLeft()
        {
            return Count;
        }
    }
}
