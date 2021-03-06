﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    cards.Add(new Card((Suits)suit, (Values)value));
                }
            }
        }

        public Deck(IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }

        public int Count { get { return cards.Count; } }

        public void Add(Card card)
        {
            cards.Add(card);
        }

        public Card Deal(int index)
        {
            Card card = cards[index];
            cards.RemoveAt(index);
            return card;
        }

        public void Shuffle()
        {
            List<Card> newCards = new List<Card>();
            while (cards.Count > 0)
            {
                int cardIndex = random.Next(cards.Count);
                newCards.Add(cards[cardIndex]);
                cards.RemoveAt(cardIndex);
            }
            cards = newCards;
        }

        public IEnumerable<string> GetCardNames()
        {
            string[] cardNames = new string[cards.Count];
            for (int i = 0; i < cards.Count; i++)
            {
                cardNames[i] = cards[i].Name;
            }
            return cardNames;
        }

        public void Sort()
        {
            cards.Sort(new CardComparer_bySuit());
        }

        public Card Peek(int cardIndex)
        {
            return cards[cardIndex];
        }

        public Card Deal()
        {
            return Deal(0);
        }

        public bool ContainsValue(Values value)
        {
            foreach (Card card in cards)
            {
                if (card.Value == value)
                {
                    return true;
                }
            }
            return false;
        }

        public Deck PullOutValues(Values value)
        {
            Deck deck = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
            {
                if (cards[i].Value == value)
                {
                    deck.Add(Deal(i));
                }
            }
            return deck;
        }

        public bool HasBook(Values value)
        {
            int numberOfCards = 0;
            foreach (Card card in cards)
            {
                if (card.Value == value)
                {
                    numberOfCards++;
                }
            }
            if (numberOfCards == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SortByValue()
        {
            cards.Sort(new CardComparer_byValue());
        }
    }
}
