using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal interface ICard
    {
        int strenght();
        void setPlayer(IPlayer player);
        void discard();
        void playCard(IPlayer playerAgainst);
        void playCard();

    }
}
