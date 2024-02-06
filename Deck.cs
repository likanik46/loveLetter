using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal class Deck
    {
        public ICard[] cards = new ICard[16] {
            new Guard(),
            new Guard(),
            new Guard(),
            new Guard(),
            new Guard(),
            new Priest(),
            new Priest(),
            new Baron(),
            new Baron(),
            new Handmaid(),
            new Handmaid(),
            new Prince(),
            new Prince(),
            new King(),
            new Countess(),
            new Princess(),
        };

        public static Random random = new Random();
        public int[] cardsLeftOverall = new int[9] { 0, 5, 2, 2, 2, 2, 1, 1, 1 };

        private int top = 0;
        public ICard pull()
        {
            return cards[top++];
        }

        public Deck()
        {
            for (int i = 15; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                ICard temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
         
        }

    }
}
