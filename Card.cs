﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack2022
{
    public class Card
    {
        // Suit can be: Hearts or Diamonds or Clubs or Spades
        public String Suit;

        // Rank can be: 1 (Ace), 2, 3, ..., 10,
        // 11(Jack), 12(Queen), 13 (King)
        public int Rank;

        public int GetRank()
        {
            string blackjackRank = Rank.ToString();
            
            if (blackjackRank == "Ace")
            {
                Rank = 1;
            }
            else if (blackjackRank == "Jack")
            {
                Rank = 11;
            }
            else if (blackjackRank == "Queen")
            {
                Rank = 12;
            }
            else if (blackjackRank == "King")
            {
                Rank = 13;
            }

            return Rank;
        }

        public string GetFileName()
        {
            string blackjackRank = Rank.ToString();
            if (Rank == 1)
            {
                blackjackRank = "ace";
            }
            else if (Rank == 11)
            {
                blackjackRank = "jack";
            }
            else if (Rank == 12)
            {
                blackjackRank = "queen";
            }
            else if (Rank == 13)
            {
                blackjackRank = "king";
            }

            return blackjackRank + "_of_" + Suit + ".png";
        }

        public int GetBlackjackValue()
        {
            /*
             * Simplifying Assumption: Ace is always counte
             * as 1 instead of 11
             */
            if (Rank > 10)
            {
                return GetRank();
            }
            return GetRank();
        }
    }
}
