using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal class Princess : ICard
    {
        IPlayer player;

        int ICard.strenght()
        {
            return 8;
        }

        public void discard()
        {
            player.setStatus(IPlayer.Status.Lose);
            player.getGame().removeKnowCardOfPlayer(player, 8);
            player.getDeck().cardsLeftOverall[8]--;
            player.getGame().removePlayer(player);
        }

        public void playCard()
        {
            Console.WriteLine("Player " + player.IPlayerToNumber() + " discards the princess(8)");
            Console.WriteLine("Player " + player.IPlayerToNumber() + "out!");
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
