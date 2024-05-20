using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11bugs.Common
{
    internal class Piles
    {
        public List<Cards> Pile1 { get; set; }
        public List<Cards> Pile2 { get; set; }
        public List<Cards> Pile3 { get; set; }
        public List<Cards> Pile4 { get; set; }
        public List<Cards> Pile5 { get; set; }
        public List<Cards> Pile6 { get; set; }
        public List<Cards> Pile7 { get; set; }
             
        public Cards ClubsPile { get; set; }
        public Cards DiamondsPile { get; set; }
        public Cards HeartsPile { get; set; }
        public Cards SpadesPile { get; set; }
        public List<Cards> HiddenPile { get; set; }
        public List<Cards> ShownedPile { get; set; }



        public Piles(bool tests = false)
        {
            Pile1 = new List<Cards>();
            Pile2 = new List<Cards>();
            Pile3 = new List<Cards>();
            Pile4 = new List<Cards>();
            Pile5 = new List<Cards>();
            Pile6 = new List<Cards>();
            Pile7 = new List<Cards>();

            ClubsPile = Cards.Clubs;
            DiamondsPile = Cards.Diamonds;
            HeartsPile = Cards.Hearts;
            SpadesPile = Cards.Spades;

            HiddenPile = new List<Cards>();
            ShownedPile = new List<Cards>();

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
		public static List<Cards> GetRandomCards()
		{
			Random random = new Random();
			int numberOfCards = random.Next(1, 6); 
			List<Cards> cardsList = new List<Cards>();

			Array values = Enum.GetValues(typeof(Cards));
			for(int i = 0; i < numberOfCards; i++)
			{
				Cards randomCard = (Cards)values.GetValue(random.Next(values.Length));
				cardsList.Add(randomCard);
			}

			return cardsList;
		}
	}
}
