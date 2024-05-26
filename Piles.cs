using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11bugs.Common
{
	internal class Piles
	{
		public List<(Card card, bool isSelected)> Pile1 { get; set; }
		public List<(Card card, bool isSelected)> Pile2 { get; set; }
		public List<(Card card, bool isSelected)> Pile3 { get; set; }
		public List<(Card card, bool isSelected)> Pile4 { get; set; }
		public List<(Card card, bool isSelected)> Pile5 { get; set; }
		public List<(Card card, bool isSelected)> Pile6 { get; set; }
		public List<(Card card, bool isSelected)> Pile7 { get; set; }

		public Card ClubsPile { get; set; }
		public Card DiamondsPile { get; set; }
		public Card HeartsPile { get; set; }
		public Card SpadesPile { get; set; }
		public Card HiddenPile { get; set; }
		public Card ShownPile { get; set; }



		public Piles(bool tests = false)
		{
			Pile1 = new List<(Card, bool)>();
			Pile2 = new List<(Card, bool)>();
			Pile3 = new List<(Card, bool)>();
			Pile4 = new List<(Card, bool)>();
			Pile5 = new List<(Card, bool)>();
			Pile6 = new List<(Card, bool)>();
			Pile7 = new List<(Card, bool)>();

			ClubsPile = Card.Clubs;
			DiamondsPile = Card.Diamonds;
			HeartsPile = Card.Hearts;
			SpadesPile = Card.Spades;

			HiddenPile = Card.Place;
			ShownPile = Card.Place;

			if(tests) Tests();

		}

		private void Tests()
		{
			Pile1 = GetRandomCards();
			Pile2 = GetRandomCards();
			Pile3 = GetRandomCards();
			Pile4 = GetRandomCards();
			Pile5 = GetRandomCards();
			Pile6 = GetRandomCards();
			Pile7 = GetRandomCards();

			Random random = new Random();
			HiddenPile = random.Next(10) == 0 ? Card.Place : Card.Back;
			ShownPile = random.Next(10) == 0 ? Card.C4 : Card.Place;

		}
		public static List<(Card, bool)> GetRandomCards()
		{
			Random random = new Random();
			int numberOfCards = random.Next(0, 6);
			List<(Card, bool)> cardsList = new List<(Card, bool)>();

			// Excluir as últimas cartas indesejadas
			Array values = Enum.GetValues(typeof(Card));
			int limit = (int)Card.Back;
			Card[] validCards = new Card[limit];
			Array.Copy(values, validCards, limit);

			for(int i = 0; i < numberOfCards; i++)
			{
				Card randomCard = (Card)validCards[random.Next(validCards.Length)];
				cardsList.Add((randomCard, random.Next(10) == 0));
			}

			return cardsList;
		}
	}
}
