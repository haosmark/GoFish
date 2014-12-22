using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFish
{
    class Player
    {
        private string name;
        public string Name { get { return this.name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;

        public Player(String name, Random random, TextBox textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm = textBoxOnForm;
            this.cards = new Deck();

            this.textBoxOnForm.Text = this.name + " has just joined the game" + Environment.NewLine;
            // initialize 4 private fields, then add a line to the textBox control
            // on the form that says "Joe has just joined the game"- but use the name in
            // the private field, and don't forget to add a line break at the end of every
            // line you add the text box
        }

        public Values GetRandomValues()
        {
            // get a random value - value has to be in the deck

        }

        public Deck DoYouHaveAny(Values value)
        {
            // this is where opponent asks if I have any cards of a certain value
            // Use Deck.PullOutValues() to pull out the values. Add a line to the TextBox
            // that says, "Joe has 3 sixes" - use the new Card.Plural() static method
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {
            // overloaded method - choose a random value from the deck using GetRandomValue()
            // and ask for it using AskForACard()
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value)
        {
            // Ask the other players for a value. First add a line to the textbox: "Joe asks if anyone has a Queen"
            // then go through the list of players that was passed in as a parameter and ask each player if
            // he has any of the value ( using his DoYouHaveAny() method ). He'll pass you a deck of cards - add them to my deck.
            // Keep track of how many cards were added. If there weren't any, you'll need to deal yourself a card from the stock
            // (which was also passed as a parameter), and you'll have to add a line to the textbox "Joe has to draw from the stock"
        }

        public int CardCount { get { return cards.Count; } }
        public void TakeCard(Card card)
        {
            cards.Add(card);
        }

        public IEnumerable<string> GetCardNames()
        {
            return cards.GetCardNames();
        }

        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }

        public void SortHand() { cards.SortByValue(); }

        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 1; i <= 13; i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                {
                    if (cards.Peek(card).Value == value)
                    {
                        howMany++;
                    }
                }
                if (howMany == 4)
                {
                    books.Add(value);
                    cards.PullOutValues(value);
                }
            }
            return books;
        }
    }
}
