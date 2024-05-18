using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11bugs.Common
{
    internal class Piles
    {
        List<Cards> Pile1 { get; set; }
        List<Cards> Pile2 { get; set; }
        List<Cards> Pile3 { get; set; }
        List<Cards> Pile4 { get; set; }
        List<Cards> Pile5 { get; set; }
        List<Cards> Pile6 { get; set; }
        List<Cards> Pile7 { get; set; }
             
        List<Cards> AceClubsPile { get; set; }
        List<Cards> AceDiamondsPile { get; set; }
        List<Cards> AceHeartsPile { get; set; }
        List<Cards> AceSpadesPile { get; set; }
        List<Cards> HiddenPile { get; set; }
        List<Cards> ShownedPile { get; set; }



        public Piles()
        {
            List<Cards> Pile1 = new List<Cards>();
            List<Cards> Pile2 = new List<Cards>();
            List<Cards> Pile3 = new List<Cards>();
            List<Cards> Pile4 = new List<Cards>();
            List<Cards> Pile5 = new List<Cards>();
            List<Cards> Pile6 = new List<Cards>();
            List<Cards> Pile7 = new List<Cards>();

            List<Cards> AceClubsPile = new List<Cards>();
            List<Cards> AceDiamondsPile = new List<Cards>();
            List<Cards> AceHeartsPile = new List<Cards>();
            List<Cards> AceSpadesPile = new List<Cards>();
            List<Cards> HiddenPile = new List<Cards>();
            List<Cards> ShownedPile = new List<Cards>();
        }

    }
}
