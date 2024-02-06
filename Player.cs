using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal class Player : IPlayer
    {
        IPlayer.Status status;

        private Dictionary<IPlayer, int> knownCardOfEnemies = new Dictionary<IPlayer, int>();

        ICard? card = null;
        ICard? tempCard = null;

        private Deck deck;
        private Game game;

        public Player(Game game, Deck deck)
        {
            this.game = game;
            this.deck = deck;
        }
        public void getCardFromDeck()
        {
            if (card == null)
            {
                card = deck.pull();
                card.setPlayer(this);
            }
            else
            {
                tempCard = deck.pull();
                tempCard.setPlayer(this);
                if (tempCard.strenght() < card.strenght())
                {
                    ICard tmp = card;
                    card = tempCard;
                    tempCard = tmp;
                }
            }
            game.cardsLeft--;
        }

        
        void swapCardsInHand()
        {
            ICard temp = card;
            card = tempCard;
            tempCard = temp;
        }

        public void setStatus(IPlayer.Status s)
        {
            status = s;
        }

        int IPlayer.getCardStrength()
        {
            return card.strenght();
        }

        ICard IPlayer.getCurrentCard()
        {
            return card;
        }

        void IPlayer.setCard(ICard card)
        {
            this.card = card;
        }

        void IPlayer.swapHands(IPlayer playerAgainst)
        {
            ICard temp = card;
            card = playerAgainst.getCurrentCard();
            playerAgainst.setCard(temp);

        }

        public bool isAlive()
        {
            if (status == IPlayer.Status.Lose)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private IPlayer playerToAttack() //zaGarda
        {
            IPlayer player = null;
            foreach (var pair in knownCardOfEnemies)
            {
                if (player != null)
                {
                    if (pair.Value > knownCardOfEnemies[player])
                    {
                        player = pair.Key;
                    }
                }
                else
                {
                    if (pair.Value > -1)
                    {
                        player = pair.Key;
                    }
                }
            }
            if (player != null) return player;
            return knownCardOfEnemies.First().Key;
        }

        private IPlayer playerToSee() //zaPriesta
        {
            foreach (var pair in knownCardOfEnemies)
            {
                if (pair.Value == -1) return pair.Key;
            }
            return null;
        }

        private Tuple<IPlayer, int> toBaronAgainst()
        {
            if (tempCard.strenght() == 8)
            {
                return Tuple.Create(knownCardOfEnemies.First().Key, 3);

            }
            else
            {
                IPlayer target = null;
                foreach (var pair in knownCardOfEnemies)
                {
                    if (pair.Value < tempCard.strenght())
                    {
                        return Tuple.Create(pair.Key, tempCard.strenght());
                    }
                }
                int sumLess = 0, sumGreater = 0;
                for (int i = 1; i < tempCard.strenght(); i++)
                {
                    sumLess += deck.cardsLeftOverall[i];
                }
                for (int i = tempCard.strenght() + 1; i < 9; i++)
                {
                    sumGreater += deck.cardsLeftOverall[i];
                }

                if (sumLess > sumGreater)
                {
                    return Tuple.Create(knownCardOfEnemies.First().Key, 3);
                }
                else
                {
                    return Tuple.Create(knownCardOfEnemies.First().Key, tempCard.strenght());
                }

            }
        }

        private IPlayer toAttackWithPrice()
        {
            foreach (var pair in knownCardOfEnemies)
            {
                if (pair.Value == 8)
                {
                    return pair.Key;
                }
            }
            return knownCardOfEnemies.First().Key;
        }
        void IPlayer.play()
        {
            if (card.strenght() == 1)
            {
                swapCardsInHand(); //tempCard izbacujem
                tempCard.playCard(playerToAttack());
                tempCard = null;

            }
            else if (card.strenght() == 2)
            {
                swapCardsInHand();
                tempCard.playCard(playerToSee());
                tempCard = null;
            }
            else if (card.strenght() == 3)
            {
                Tuple<IPlayer, int> toAttack = toBaronAgainst();
                if (toAttack.Item2 != tempCard.strenght()) swapCardsInHand();
                if (tempCard.strenght() == 4 || tempCard.strenght() == 7)
                {
                    tempCard.playCard();
                }
                else
                {
                    tempCard.playCard(toAttack.Item1);
                }
                tempCard = null;
            }
            else if (card.strenght() == 4)
            {
                swapCardsInHand();
                tempCard.playCard();
                tempCard = null;
            }
            else if (card.strenght() == 5)
            {
                if (tempCard.strenght() == 7)
                {
                    tempCard.playCard();
                }
                else
                {
                    swapCardsInHand();
                    tempCard.playCard(toAttackWithPrice());

                }
                tempCard = null;
            }
            else
            {
                if (tempCard.strenght() == 7)
                {
                    tempCard.playCard();
                }
                else
                {
                    swapCardsInHand();
                    tempCard.playCard(knownCardOfEnemies.First().Key);
                }
                tempCard = null;
            }
        }

        void IPlayer.addEnemy(IPlayer p)
        {
            if (p != this) { knownCardOfEnemies[p] = -1; }
            
        }

        Deck IPlayer.getDeck()
        {
            return deck;
        }

        void IPlayer.removeEnemy(IPlayer player)
        {
            knownCardOfEnemies.Remove(player);
        }

        

        void IPlayer.removeKnownCard(IPlayer player)
        {
            player.getDict()[player] = -1;
        }

        Game IPlayer.getGame()
        {
            return game;
        }

        Dictionary<IPlayer, int> IPlayer.getDict()
        {
            return knownCardOfEnemies;
        }

        IPlayer.Status IPlayer.getStatus()
        {
            return status;
        }

        int IPlayer.IPlayerToNumber()
        {
            for (int i = 0; i < game.numberOfPlayers; i++)
            {
                if (game.players[i] == this)
                {
                    return i + 1;
                }
            }
            return 0;
        }

        int IPlayer.getTempCard()
        {
            return tempCard.strenght();
        }
    }
}
