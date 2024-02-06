using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal class Handmaid : ICard
    {
        IPlayer player;
        public void playCard()
        {
            Console.WriteLine("Player " + player.IPlayerToNumber() + " plays the handmaid(4)");
            player.setStatus(IPlayer.Status.Safe);
            player.getGame().removeKnowCardOfPlayer(player, 4);
            player.getDeck().cardsLeftOverall[4]--;
        }

        void ICard.discard()
        {
            player.setStatus(IPlayer.Status.Safe);
        }

        void ICard.playCard(IPlayer playerAgainst)
        {
            
        }

        void ICard.setPlayer(IPlayer player)
        {
            this.player = player;
        }

        int ICard.strenght()
        {
            return 4;
        }
    }
}
