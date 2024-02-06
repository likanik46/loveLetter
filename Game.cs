using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loveLetter
{
    internal class Game
    {
        private Deck deck;
        public IPlayer[] players;
        private int turn = 0;
        public int numberOfPlayers;
        public int leftoverPlayers;
        public int cardsLeft = 15;

        public Game(int numOfPlayers)
        {
            deck = new Deck();
            players = new IPlayer[numOfPlayers];
            leftoverPlayers = numOfPlayers;
            this.numberOfPlayers = numOfPlayers;
            for (int i = 0; i < numOfPlayers; i++)
            {
                players[i] = new Player(this, deck);
                players[i].getCardFromDeck();
                //Console.WriteLine(players[i].getCardStrength());
            }
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfPlayers; j++)
                {
                    if (i == j) continue;
                    players[i].addEnemy(players[j]);
                }
            }
        }

        
        public void start()
        {
            while (cardsLeft > 0 && leftoverPlayers > 1)
            {
                if (players[turn].isAlive() == false)
                {
                    turn = (turn + 1) % numberOfPlayers;
                    continue;
                }

                players[turn].getCardFromDeck();
                Console.WriteLine("Player " + players[turn].IPlayerToNumber() + " turn");
                Console.WriteLine("Cards: " + players[turn].getCardStrength() + ", " + players[turn].getTempCard());
                players[turn].play();
                Console.Write('\n');


                turn = (turn + 1) % numberOfPlayers;
            }

            if (leftoverPlayers == 1)
            {
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    if (players[i].isAlive() == true)
                    {
                        Console.WriteLine("Player " + (i + 1) + " won by eliminations");
                    }
                }
            }
            else
            {
                int max = 0;
                int player = 0;
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    if (players[i].isAlive())
                    {
                        if (players[i].getCurrentCard().strenght() > max)
                        {
                            max = players[i].getCurrentCard().strenght();
                            player = i + 1;
                        }
                    }
                }
                Console.WriteLine("Player " + (player) + " won by points");
            }

        }


        public void removePlayer(IPlayer player)
        {
            for (int i = 0; i <  numberOfPlayers; i++)
            {
                if (players[i].isAlive() == false) continue;
                players[i].removeEnemy(player);
                
            }
            leftoverPlayers--;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Number of players?");
            Game game = new Game(int.Parse(Console.ReadLine()));
            game.start();

        }

        internal void removeKnowCardOfPlayer(IPlayer player, int cardValue)
        {
            for (int i = 0;i < numberOfPlayers;i++)
            {
                if (players[i].isAlive() == false || players[i] == player) continue;
                players[i].removeKnownCard(player);
            }
        }
    }
}
