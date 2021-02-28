using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.OOPS.DeckOfCards
{
    /*Assume
     * 52 Card?
     * 4 SUIT of card : SPADE, DIAMOND, HEART, CLUB
     * 0 to 12 
     * 
     * 1. Deck : 52 Cards in it 
     *      SetCards();
     *      Suffle();
     *      GetCard(int val, SUIT suit);
     *      
     * 2. Card : 
     *      SUIT
     *      Value
     *      Available
     *      
     *      
     *      
     * 
     */
    class DeckOfCards
    {
    }


    public enum SUIT
    {
        SPADE,
        DIAMOND,
        HEART,
        CLUB
    }

    public class Card
    {
        private bool available = true;
        protected int faceValue;
        protected SUIT suit;

        public Card(int v, SUIT suit)
        {
            faceValue = v;
            this.suit = suit;
        }

        public int Value()
        {
            return faceValue;
        }
        public SUIT Suit()
        {
            return suit;
        }

        public bool IsAvailable()
        {
            return available;
        }
        public void SetAvailable()
        {
            available = true;
        }
        public void SetUnavailable()
        {
            available = false;
        }
    }

    public class Deck
    {
        private Card[] cards;
        public Deck()
        {
            cards = new Card[52];
            //string[] s = new string[4] { "SPADE", "DIAMOND", "HEART", "CLUB"};
            int idx = 0;
            for(int i =0; i <4 ; i++)
            {
                for (int j= 1; j <= 13; j++)
                {
                    if(i==0)
                        cards[idx++] = new Card(j,SUIT.SPADE);

                    if (i == 1)
                        cards[idx++] = new Card(j, SUIT.DIAMOND);

                    if (i == 2)
                        cards[idx++] = new Card(j, SUIT.HEART);

                    if (i == 3)
                        cards[idx++] = new Card(j, SUIT.CLUB);
                }
            }
        }

        public void Shuffle()
        {

        }

     
    }

    public class Hand
    {
        IList<Card> handCards = new List<Card>();

        public int Score()
        {
            int score = 0;
            foreach (Card c in handCards)
            {
                score += c.Value();
            }

            return score;
        }
        public void AddCard(Card c)
        {
            handCards.Add(c);
        }
    }

    public class BlackJack : Hand
    {
        public bool IsBusted()
        {
            return Score() > 21;
        }
        public bool IsBlackJAck()
        {
            return true;
        }
        public bool Is21()
        {
            return Score() == 21;
        }


    }



    
}
