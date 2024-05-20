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
		public Dictionary<Cards, Texture2D> CardsImages = new Dictionary<Cards, Texture2D>();

		private Microsoft.Xna.Framework.Vector2 Pile1Pos = new Microsoft.Xna.Framework.Vector2(50, 200);
		private Microsoft.Xna.Framework.Vector2 Pile2Pos = new Microsoft.Xna.Framework.Vector2(200, 200);
		private Microsoft.Xna.Framework.Vector2 Pile3Pos = new Microsoft.Xna.Framework.Vector2(350, 200);
		private Microsoft.Xna.Framework.Vector2 Pile4Pos = new Microsoft.Xna.Framework.Vector2(500, 200);
		private Microsoft.Xna.Framework.Vector2 Pile5Pos = new Microsoft.Xna.Framework.Vector2(650, 200);
		private Microsoft.Xna.Framework.Vector2 Pile6Pos = new Microsoft.Xna.Framework.Vector2(800, 200);
		private Microsoft.Xna.Framework.Vector2 Pile7Pos = new Microsoft.Xna.Framework.Vector2(950, 200);
		private Microsoft.Xna.Framework.Vector2 HiddenPilePos = new Microsoft.Xna.Framework.Vector2(50, 10);
		private Microsoft.Xna.Framework.Vector2 ShownedPilePos = new Microsoft.Xna.Framework.Vector2(200, 10);
		private Microsoft.Xna.Framework.Vector2 AceClubsPilePos = new Microsoft.Xna.Framework.Vector2(500, 10);
		private Microsoft.Xna.Framework.Vector2 AceDiamondsPilePos = new Microsoft.Xna.Framework.Vector2(650, 10);
		private Microsoft.Xna.Framework.Vector2 AceHeartsPilePos = new Microsoft.Xna.Framework.Vector2(800, 10);
		private Microsoft.Xna.Framework.Vector2 AceSpadesPilePos = new Microsoft.Xna.Framework.Vector2(950, 10);

		public Board()
		{
			piles.ClubsPile = Cards.CA;
			piles.DiamondsPile = Cards.DA;
			piles.HeartsPile = Cards.HA;
			piles.SpadesPile = Cards.SA;
		}

		public void SetPiles(Piles piles)
		{
			this.piles = piles;
		}

		public void Draw(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Vector2 imageScale, Microsoft.Xna.Framework.Color color, Texture2D overlayTexture)
		{
			if(piles == null) return;

			if(piles.HiddenPile.Count == 0) spriteBatch.Draw(CardsImages[Cards.Place], HiddenPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			else spriteBatch.Draw(CardsImages[Cards.Back], HiddenPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);

			spriteBatch.Draw(CardsImages[Cards.Place], ShownedPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);

			DrawPiles(piles.Pile1, Pile1Pos, spriteBatch, imageScale, color, overlayTexture);
			DrawPiles(piles.Pile2, Pile2Pos, spriteBatch, imageScale, color, overlayTexture);
			DrawPiles(piles.Pile3, Pile3Pos, spriteBatch, imageScale, color, overlayTexture);
			DrawPiles(piles.Pile4, Pile4Pos, spriteBatch, imageScale, color, overlayTexture);
			DrawPiles(piles.Pile5, Pile5Pos, spriteBatch, imageScale, color, overlayTexture);
			DrawPiles(piles.Pile6, Pile6Pos, spriteBatch, imageScale, color, overlayTexture);
			DrawPiles(piles.Pile7, Pile7Pos, spriteBatch, imageScale, color, overlayTexture);

			spriteBatch.Draw(CardsImages[piles.ClubsPile], AceClubsPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			spriteBatch.Draw(CardsImages[piles.DiamondsPile], AceDiamondsPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			spriteBatch.Draw(CardsImages[piles.HeartsPile], AceHeartsPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			spriteBatch.Draw(CardsImages[piles.SpadesPile], AceSpadesPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
		}

		private void DrawPiles(List<(Cards, bool)> cards, Microsoft.Xna.Framework.Vector2 pilePos, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Vector2 imageScale, Microsoft.Xna.Framework.Color color, Texture2D overlayTexture)
		{
			if(cards.Count == 0) { spriteBatch.Draw(CardsImages[Cards.Place], pilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f); }
			else
			{
				for(int i = 0; i < cards.Count; i++)
				{
					Microsoft.Xna.Framework.Vector2 cardPosition = new Microsoft.Xna.Framework.Vector2((int)pilePos.X, (int)pilePos.Y + i * 35);
					spriteBatch.Draw(CardsImages[cards[i].Item1], new Microsoft.Xna.Framework.Vector2((int)(pilePos.X), (int)pilePos.Y + i * 35), null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);

					if(cards[i].Item2)
					{
						Microsoft.Xna.Framework.Color overlayColor = new Microsoft.Xna.Framework.Color(0, 0, 255, 128); // Azul semi-transparente
						Microsoft.Xna.Framework.Rectangle overlayRectangle = new Microsoft.Xna.Framework.Rectangle((int)cardPosition.X, (int)cardPosition.Y, (int)(CardsImages[cards[i].Item1].Width * imageScale.X), (int)(CardsImages[cards[i].Item1].Height * imageScale.Y));
						spriteBatch.Draw(overlayTexture, overlayRectangle, overlayColor);
					}
				}
			}
		}
	}
}
