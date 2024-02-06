using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal class Baron : ICard
    {
        IPlayer player;

        int ICard.strenght()
        {
            return 3;
        }
        public void discard()
        {
            player.setStatus(IPlayer.Status.Continue);
            player.getGame().removeKnowCardOfPlayer(player, 3);
            player.getDeck().cardsLeftOverall[3]--;
        }

        public void playCard(IPlayer playerAgainst)
        {
            Console.WriteLine("Player " + player.IPlayerToNumber() + " tries baron(3) against " + playerAgainst.IPlayerToNumber());
            if (player.getCurrentCard().strenght() < playerAgainst.getCurrentCard().strenght())
            {
                Console.WriteLine("Player " + player.IPlayerToNumber() + "out!");
                player.setStatus(IPlayer.Status.Lose);
                player.getGame().removeKnowCardOfPlayer(player, 3);
                player.getDeck().cardsLeftOverall[3]--;
                player.getGame().removePlayer(player);
            }
            else
            {
                Console.WriteLine("Player " + playerAgainst.IPlayerToNumber() + "out!");
                playerAgainst.setStatus(IPlayer.Status.Lose);
                player.getGame().removePlayer(playerAgainst);
                player.getGame().removeKnowCardOfPlayer(player, 3);
                player.getDeck().cardsLeftOverall[3]--;
            }
            
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
