using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal interface IPlayer
    {
        enum Status
        {
            Continue,
            Lose,
            Safe
        }
        void setStatus(IPlayer.Status s);
        void getCardFromDeck(); //uzima iz decka kartu
        int getCardStrength(); //pokazuje kartu
        ICard getCurrentCard();
        void swapHands(IPlayer playerAgainst);
        void setCard(ICard card);
        void play();

        Deck getDeck();
        bool isAlive();

        void addEnemy(IPlayer player);
        
        void removeEnemy(IPlayer player);

        int getTempCard();
        Game getGame();

        void removeKnownCard(IPlayer player);

        Dictionary<IPlayer, int> getDict();

        Status getStatus();

        int IPlayerToNumber();
    }
}
