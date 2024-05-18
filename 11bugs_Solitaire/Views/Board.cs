using _11bugs.Common;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace _11bugs.Views
{
	internal class Board
	{
		public Piles piles = new Piles();
		public Dictionary<Cards,Texture2D> CardsImages = new Dictionary<Cards, Texture2D>();

		private Microsoft.Xna.Framework.Vector2 Pile1Pos = new Microsoft.Xna.Framework.Vector2(50,200);
		private Microsoft.Xna.Framework.Vector2 Pile2Pos = new Microsoft.Xna.Framework.Vector2(200,200);
		private Microsoft.Xna.Framework.Vector2 Pile3Pos = new Microsoft.Xna.Framework.Vector2(350,200);
		private Microsoft.Xna.Framework.Vector2 Pile4Pos = new Microsoft.Xna.Framework.Vector2(500,200);
		private Microsoft.Xna.Framework.Vector2 Pile5Pos = new Microsoft.Xna.Framework.Vector2(650,200);
		private Microsoft.Xna.Framework.Vector2 Pile6Pos = new Microsoft.Xna.Framework.Vector2(800,200);
		private Microsoft.Xna.Framework.Vector2 Pile7Pos = new Microsoft.Xna.Framework.Vector2(950,200);
		private Microsoft.Xna.Framework.Vector2 HiddenPilePos = new Microsoft.Xna.Framework.Vector2(50, 10);
		private Microsoft.Xna.Framework.Vector2 ShownedPilePos = new Microsoft.Xna.Framework.Vector2(200, 10);
		private Microsoft.Xna.Framework.Vector2 AceClubsPilePos = new Microsoft.Xna.Framework.Vector2(500, 10);
		private Microsoft.Xna.Framework.Vector2 AceDiamondsPilePos = new Microsoft.Xna.Framework.Vector2(650, 10);
		private Microsoft.Xna.Framework.Vector2 AceHeartsPilePos = new Microsoft.Xna.Framework.Vector2(800, 10);
		private Microsoft.Xna.Framework.Vector2 AceSpadesPilePos = new Microsoft.Xna.Framework.Vector2(950, 10);

		public Board() {
			piles.Pile1.Add(Cards.Back);
			piles.Pile1.Add(Cards.DK);
			piles.Pile1.Add(Cards.CQ);
			piles.Pile1.Add(Cards.DJ);
			piles.Pile1.Add(Cards.CT);
			piles.Pile1.Add(Cards.D9);
			piles.Pile1.Add(Cards.C8);
			piles.Pile1.Add(Cards.D7);
			piles.Pile1.Add(Cards.C6);
			piles.Pile1.Add(Cards.D5);
			piles.Pile1.Add(Cards.C4);
			piles.Pile1.Add(Cards.D3);
			piles.Pile1.Add(Cards.C2);
			piles.Pile1.Add(Cards.D1);
			piles.Pile2.Add(Cards.Back);
			piles.Pile2.Add(Cards.Back);
			piles.Pile2.Add(Cards.Back);
			piles.Pile2.Add(Cards.Back);
			piles.Pile2.Add(Cards.Back);
			piles.Pile3.Add(Cards.Back);
			piles.Pile3.Add(Cards.D7);
			piles.Pile3.Add(Cards.S6);
			piles.Pile4.Add(Cards.S2);
            piles.Pile5.Add(Cards.C1);
            piles.Pile6.Add(Cards.Back);
			piles.Pile6.Add(Cards.HK);
			piles.Pile6.Add(Cards.SQ);
			piles.HiddenPile.Add(Cards.Back);

			piles.AceClubsPile = Cards.C3;
		}
		public void Draw(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Vector2 imageScale, Microsoft.Xna.Framework.Color color)
		{
			if(piles == null) return;

			if(piles.HiddenPile.Count == 0) spriteBatch.Draw(CardsImages[Cards.Place], HiddenPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			else spriteBatch.Draw(CardsImages[Cards.Back], HiddenPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);

			spriteBatch.Draw(CardsImages[Cards.Place], ShownedPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);

			DrawPiles(piles.Pile1,Pile1Pos, spriteBatch, imageScale, color);
			DrawPiles(piles.Pile2,Pile2Pos, spriteBatch, imageScale, color);
			DrawPiles(piles.Pile3,Pile3Pos, spriteBatch, imageScale, color);
			DrawPiles(piles.Pile4,Pile4Pos, spriteBatch, imageScale, color);
			DrawPiles(piles.Pile5,Pile5Pos, spriteBatch, imageScale, color);
			DrawPiles(piles.Pile6,Pile6Pos, spriteBatch, imageScale, color);
			DrawPiles(piles.Pile7,Pile7Pos, spriteBatch, imageScale, color);

			spriteBatch.Draw(CardsImages[piles.AceClubsPile], AceClubsPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			spriteBatch.Draw(CardsImages[piles.AceDiamondsPile], AceDiamondsPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			spriteBatch.Draw(CardsImages[piles.AceHeartsPile], AceHeartsPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			spriteBatch.Draw(CardsImages[piles.AceSpadesPile], AceSpadesPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
		}

		private void DrawPiles(List<Cards> cards, Microsoft.Xna.Framework.Vector2 pilePos, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Vector2 imageScale, Microsoft.Xna.Framework.Color color)
		{
			if(cards.Count == 0) { spriteBatch.Draw(CardsImages[Cards.Place], pilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f); }
			else
			{
				for(int i = 0; i < cards.Count; i++)
				{
					spriteBatch.Draw(CardsImages[cards[i]], new Microsoft.Xna.Framework.Vector2((int)(pilePos.X), (int)pilePos.Y + i * 35), null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
				}
			}
		}
	}
}
