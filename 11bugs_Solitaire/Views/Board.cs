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

		public Board() { }
		public void Draw(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Vector2 imageScale, Microsoft.Xna.Framework.Color color)
		{
			if(piles == null) return;
			if(piles.HiddenPile.Count == 0) spriteBatch.Draw(CardsImages[Cards.Place], HiddenPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			if(piles.ShownedPile.Count == 0) spriteBatch.Draw(CardsImages[Cards.Place], ShownedPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);

			if(piles.Pile1.Count == 0) spriteBatch.Draw(CardsImages[Cards.Place], Pile1Pos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			if(piles.Pile2.Count == 0) spriteBatch.Draw(CardsImages[Cards.Place], Pile2Pos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			if(piles.Pile3.Count == 0) spriteBatch.Draw(CardsImages[Cards.Place], Pile3Pos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			if(piles.Pile4.Count == 0) spriteBatch.Draw(CardsImages[Cards.Place], Pile4Pos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			if(piles.Pile5.Count == 0) spriteBatch.Draw(CardsImages[Cards.Place], Pile5Pos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			if(piles.Pile6.Count == 0) spriteBatch.Draw(CardsImages[Cards.Place], Pile6Pos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			if(piles.Pile7.Count == 0) spriteBatch.Draw(CardsImages[Cards.Place], Pile7Pos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);

			if(piles.AceClubsPile.Count == 0) spriteBatch.Draw(CardsImages[Cards.Clubs], AceClubsPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			if(piles.AceDiamondsPile.Count == 0) spriteBatch.Draw(CardsImages[Cards.Diamonds], AceDiamondsPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			if(piles.AceHeartsPile.Count == 0) spriteBatch.Draw(CardsImages[Cards.Hearts], AceHeartsPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
			if(piles.AceSpadesPile.Count == 0) spriteBatch.Draw(CardsImages[Cards.Spades], AceSpadesPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);
		}
	}
}
