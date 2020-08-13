using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI.OOODesigns.ex_7_1
{
    public class DeckOfCards
    {
        private Hashtable Cards { get; set; }
        public Hashtable GetCards()
        {
            return this.Cards;
        }
        public void Add(Card card)
        {
            if (!this.Validate(card))
            {
                return;
            }
            this.Cards.Add(CardToUniqueName(card), card);
        }

        private bool Validate(Card card)
        {
            if (this.Cards.ContainsKey(CardToUniqueName(card)))
            {
                return false;
            }
            return true;

        }
        private string CardToUniqueName(Card card)
        {
            return card.Value + "_" + card.Type.Rank.ToString();
        }
    }

    public class Card
    {
        public class CardType
        {
            public enum Colours
            {
                Black,
                Red
            }
            public enum Ranks
            {
                Spade,
                Club,
                Diamond,
                Heart
            }
            public Colours Color { get; set; }
            public Ranks Rank { get; set; }
        }
        public string Value { get; set; }
        public CardType Type { get; set; }
    }

    public class CardGame
    {
        public string Name { get; set; }
        public List<CardPlayer> Players { get; set; }
    }
    public class Blackjack : CardGame
    {
        private DeckOfCards DeckOfCard { get; set; }

        public bool IsBlackjack(CardPlayer player)
        {
            var cards = player.GetCurrentCards();
            var c1 = cards[0];
            var c2 = cards[1];
            var jqk10 = new string[] { "10", "J", "Q", "K" };
            if ((c1.Value == "A" && jqk10.Contains(c2.Value)) || c2.Value == "A" && jqk10.Contains(c1.Value))
            {
                return true;
            }
            return false;
        }
    }

    public class CardPlayer
    {
        private List<Card> CurrentCards { get; set; } = new List<Card>();
        public void Add(Card card)
        {
            this.CurrentCards.Add(card);
        }
        public List<Card> GetCurrentCards()
        {
            return this.CurrentCards;
        }
    }
}
