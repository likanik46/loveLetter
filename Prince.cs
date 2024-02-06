using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal class Prince : ICard
    {
        IPlayer player;
        int ICard.strenght()
        {
            return 5;
        }


        public void discard()
        {
            player.setStatus(IPlayer.Status.Continue);
            player.getGame().removeKnowCardOfPlayer(player, 5);
            player.getDeck().cardsLeftOverall[5]--;
        }

        public void playCard(IPlayer playerAgainst)
        {
            Console.WriteLine("Player " + player.IPlayerToNumber() + " plays the prince(5) against player " + playerAgainst.IPlayerToNumber());
            player.setStatus(IPlayer.Status.Continue);
            playerAgainst.getCurrentCard().discard();
            if (playerAgainst.getStatus() == IPlayer.Status.Lose)
            {
                //player.getGame().removePlayer(playerAgainst);
                return;
            }
            playerAgainst.getCardFromDeck();
            player.getGame().removeKnowCardOfPlayer(player, 5);
            player.getDeck().cardsLeftOverall[5]--;

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
