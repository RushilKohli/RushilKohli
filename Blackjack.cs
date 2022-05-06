using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack2022
{
    class Blackjack
    {
        List<Card> shoe = new List<Card>();
        public List<Card> playerDeck = new List<Card>();
        public List<Card> dealerDeck = new List<Card>();

        public void GiveToPlayer()
        {
            DealTo(playerDeck);
        }
        public void GiveToDealer()
        {
            DealTo(dealerDeck);
        }
        private void DealTo(List<Card> deck)
        {
            if (shoe.Count < 1)
            {
                throw new Exception("Trying to deal from empty shoe");
            }

            Card c = shoe[0];
            deck.Add(c);
            shoe.RemoveAt(0);
        }

        public void InitShoe()
        {
            string[] suits = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };

            // Create 52 cards and place them into the shoe/dispenser
            for (int k = 0; k < 4; k++)
            {
                for (int i = 1; i < 14; i++)
                {
                    Card c = new Card();
                    c.Suit = suits[k];
                    c.Rank = i;
                    shoe.Add(c);
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < shoe.Count; i++)
            {
                int num = random.Next(51);
                Card temp = shoe[num];
                shoe[num] = shoe[i];
                shoe[i] = temp;
            }

        }
        public void Start()
        {
            GiveToPlayer();
            GiveToDealer();
            GiveToPlayer();
            GiveToDealer();
        }

        public int Hit()
        {
            GiveToPlayer();

            if(GetPlayerSum() > 21)
            {
                return -1;
            }
            return 0;
        }

        public int Stand()
        {
            // By the casino's rule: Dealer must hit
            // until he is more than 15
            while (GetDealerSum() < 15)
            {
                GiveToDealer();
            }

            // Dealer may get busted while hitting
            if (GetDealerSum() > 21)
            {
                return -1;
                // Dealer busted
            }

            else if (GetPlayerSum() > 21)
            {
                return 1;
                // Player busted
            }
            else if (GetDealerSum() < GetPlayerSum())
            {
                return -2;
                // Player won
            }
            else if(GetDealerSum() > GetPlayerSum())
            {
                return 1;
                // Dealer won
            }
            else if(GetDealerSum() == GetPlayerSum())
            {
                return 2;
                // Match Tied
            }
            return 0;
        }

        public int GetPlayerSum()
        {
            int sum = 0;
            foreach (Card c in playerDeck)
            {
                sum += c.GetBlackjackValue();
            }
            return sum;
        }

        public int GetDealerSum()
        {
            int sum = 0;
            foreach (Card c in dealerDeck)
            {
                sum += c.GetBlackjackValue();
            }
            return sum;
        }

        public void Reset()
        {
            playerDeck = new List<Card>();
            dealerDeck = new List<Card>();

        }
    }
}