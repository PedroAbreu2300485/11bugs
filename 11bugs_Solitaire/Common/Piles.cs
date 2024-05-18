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
             
        public Cards AceClubsPile { get; set; }
        public Cards AceDiamondsPile { get; set; }
        public Cards AceHeartsPile { get; set; }
        public Cards AceSpadesPile { get; set; }
        public List<Cards> HiddenPile { get; set; }
        public List<Cards> ShownedPile { get; set; }



        public Piles()
        {
            Pile1 = new List<Cards>();
            Pile2 = new List<Cards>();
            Pile3 = new List<Cards>();
            Pile4 = new List<Cards>();
            Pile5 = new List<Cards>();
            Pile6 = new List<Cards>();
            Pile7 = new List<Cards>();

            AceClubsPile = Cards.Clubs;
            AceDiamondsPile = Cards.Diamonds;
            AceHeartsPile = Cards.Hearts;
            AceSpadesPile = Cards.Spades;

            HiddenPile = new List<Cards>();
            ShownedPile = new List<Cards>();
        }

    }
}
