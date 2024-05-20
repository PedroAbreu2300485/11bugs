using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11bugs.Common
{
    internal class Piles
    {
        public List<(Cards card, bool isSelected)> Pile1 { get; set; }
        public List<(Cards card, bool isSelected)> Pile2 { get; set; }
        public List<(Cards card, bool isSelected)> Pile3 { get; set; }
        public List<(Cards card, bool isSelected)> Pile4 { get; set; }
        public List<(Cards card, bool isSelected)> Pile5 { get; set; }
        public List<(Cards card, bool isSelected)> Pile6 { get; set; }
        public List<(Cards card, bool isSelected)> Pile7 { get; set; }
             
        public Cards ClubsPile { get; set; }
        public Cards DiamondsPile { get; set; }
        public Cards HeartsPile { get; set; }
        public Cards SpadesPile { get; set; }
        public List<(Cards, bool)> HiddenPile { get; set; }
        public List<(Cards, bool)> ShownedPile { get; set; }



        public Piles(bool tests = false)
        {
            Pile1 = new List<(Cards, bool)>();
            Pile2 = new List<(Cards, bool)>();
            Pile3 = new List<(Cards, bool)>();
            Pile4 = new List<(Cards, bool)>();
            Pile5 = new List<(Cards, bool)>();
            Pile6 = new List<(Cards, bool)>();
			Pile7 = new List<(Cards, bool)>();

			ClubsPile = Cards.Clubs;
            DiamondsPile = Cards.Diamonds;
            HeartsPile = Cards.Hearts;
            SpadesPile = Cards.Spades;

            HiddenPile = new List<(Cards, bool)>();
            ShownedPile = new List<(Cards, bool)>();

            if(tests)	Tests();

		}

		private void Tests()
		{
            Pile1 = GetRandomCards();
            Pile2 = GetRandomCards();
            Pile3 = GetRandomCards();
            Pile4 = GetRandomCards();
            Pile6 = GetRandomCards();
            Pile7 = GetRandomCards();

		}
		public static List<(Cards, bool)> GetRandomCards()
		{
			Random random = new Random();
			int numberOfCards = random.Next(1, 6); 
			List<(Cards, bool)> cardsList = new List<(Cards, bool)>();

			Array values = Enum.GetValues(typeof(Cards));
			for(int i = 0; i < numberOfCards; i++)
			{
				Cards randomCard = (Cards)values.GetValue(random.Next(values.Length));
				cardsList.Add((randomCard, random.Next(2) == 0));
			}

			return cardsList;
		}
	}
}
