using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11bugs.Common
{
	public enum Cards
	{
		C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, CJ, CQ, CK,  // Clubs 
		D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, DJ, DQ, DK,  // Diamonds 
		H1, H2, H3, H4, H5, H6, H7, H8, H9, H10, HJ, HQ, HK,  // Hearts 
		S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, SJ, SQ, SK,  // Spades
		Place, // Carta sem imagem
		Back,   // Costas da carta
		Clubs, Diamonds, Hearts, Spades
	}
}
