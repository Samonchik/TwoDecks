using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Documents;

namespace TwoDecks
{
    internal class Deck : ObservableCollection<Card>
    {
        private static Random random = new Random();

        public Deck()
        {
            Reset();
        }
        public void Reset()
        {
            Clear();
            for (int numberOfSuit = 0; numberOfSuit <= (int)Suits.Spides; numberOfSuit++)
            {
                for (int numberOfValue = 1; numberOfValue <= (int)Values.King; numberOfValue++)
                {
                    Add(new Card((Values)numberOfValue,(Suits)numberOfSuit));
                }
            }
        }
        public Card Deal(int index)
        {
            Card cardToDeal = base[index];
            RemoveAt(index);
            return cardToDeal;
        }
      
        public void Shuffle()
        {
            var copyOfDeck = new List<Card>(this);
            Clear();
            while (copyOfDeck.Count > 0)
            {
                int index = random.Next(copyOfDeck.Count);
                var randomCard = copyOfDeck[index];
                Add(randomCard);
                copyOfDeck.RemoveAt(index);
            }
        }
        public void Sort()
        {
            List<Card> sortedCard = new List<Card>(this);
            sortedCard.Sort(new CardComparerByValue());
            Clear();
            foreach (var card in sortedCard)
            {
                Add(card);
            }
        }
    }
}
