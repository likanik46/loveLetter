using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal class King : ICard
    {
        IPlayer player;
        int ICard.strenght()
        {
            return 6;
        }

        public void discard()
        {
            player.setStatus(IPlayer.Status.Continue);
            player.getGame().removeKnowCardOfPlayer(player, 6);
            player.getDeck().cardsLeftOverall[6]--;
        }

        public void playCard(IPlayer playerAgainst)
        {
            Console.WriteLine("Player " + player.IPlayerToNumber() + " swaps hands(6) with player " + playerAgainst.IPlayerToNumber());
            player.swapHands(playerAgainst);
        }

        public void setPlayer(IPlayer player)
        {
            this.player = player;
        }

        void ICard.playCard()
        {
            
        }
    }
}
