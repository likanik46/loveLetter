using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal class Countess : ICard
    {
        IPlayer player;
        int ICard.strenght()
        {
            return 7;
        }
        public void discard()
        {
            player.setStatus(IPlayer.Status.Continue);
            player.getGame().removeKnowCardOfPlayer(player, 7);
            player.getDeck().cardsLeftOverall[7]--;
        }

        public void playCard()
        {
            Console.WriteLine("Player " + player.IPlayerToNumber() + " discards the countess(7)");
            discard();
        }

        public void setPlayer(IPlayer player)
        {
            this.player = player;
        }

        void ICard.playCard(IPlayer playerAgainst)
        {
            
        }
    }
}
