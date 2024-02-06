using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal class Guard : ICard
    {
        IPlayer player;
        public void discard()
        {
            player.setStatus(IPlayer.Status.Continue);
            player.getGame().removeKnowCardOfPlayer(player, 1);
            player.getDeck().cardsLeftOverall[1]--;
        }

        public void playCard(IPlayer playerAgainst)
        {
            player.setStatus(IPlayer.Status.Continue);
            


            int numOfTargetCards = 0;
            int targetedCard = 0;
            for (int i = 2; i < 9; i++)
            {
                if (player.getDeck().cardsLeftOverall[i] >= numOfTargetCards)
                {
                    targetedCard = i;
                    numOfTargetCards = player.getDeck().cardsLeftOverall[i];
                }
            }
            Console.WriteLine("Player " + player.IPlayerToNumber() + "(1, " + playerAgainst.IPlayerToNumber() + ", " + targetedCard + ")");
            if (targetedCard == playerAgainst.getCurrentCard().strenght())
            {
                playerAgainst.setStatus(IPlayer.Status.Lose);
                Console.WriteLine("Player " + playerAgainst.IPlayerToNumber() + " out!");
                player.getGame().removePlayer(playerAgainst);
            }

            player.getGame().removeKnowCardOfPlayer(player, 1);

            player.getDeck().cardsLeftOverall[1]--;
        }

        void ICard.setPlayer(IPlayer player)
        {
            this.player = player;
        }

        int ICard.strenght()
        {
            return 1;
        }

        public void playCard() { }
    }
}
