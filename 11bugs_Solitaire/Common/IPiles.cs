using _11bugs.Common;
using System.Collections.Generic;

public interface IPiles
{
	List<(Card card, bool isSelected)> Pile1 { get; set; }
	List<(Card card, bool isSelected)> Pile2 { get; set; }
	List<(Card card, bool isSelected)> Pile3 { get; set; }
	List<(Card card, bool isSelected)> Pile4 { get; set; }
	List<(Card card, bool isSelected)> Pile5 { get; set; }
	List<(Card card, bool isSelected)> Pile6 { get; set; }
	List<(Card card, bool isSelected)> Pile7 { get; set; }

	Card ClubsPile { get; set; }
	Card DiamondsPile { get; set; }
	Card HeartsPile { get; set; }
	Card SpadesPile { get; set; }
	Card HiddenPile { get; set; }
	Card ShownPile { get; set; }
}