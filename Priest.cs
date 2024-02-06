using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal class Priest : ICard
    {
        IPlayer player;
        int ICard.strenght()
        {
            return 2;
        }

        public void discard()
        {
            player.setStatus(IPlayer.Status.Continue);
            player.getGame().removeKnowCardOfPlayer(player, 2);
            player.getDeck().cardsLeftOverall[2]--;
        }

        public void playCard(IPlayer playerAgainst)
        {
            Console.WriteLine("Player " + player.IPlayerToNumber() + " looks upon(2) player " + playerAgainst.IPlayerToNumber());
            player.setStatus(IPlayer.Status.Continue);
            player.getDict()[playerAgainst] = playerAgainst.getCardStrength();
            player.getGame().removeKnowCardOfPlayer(player, 2);
            player.getDeck().cardsLeftOverall[2]--;
        }

        public void setPlayer(IPlayer player)
        {
            this.player = player;
        }

        void ICard.playCard() { }
    }
}
