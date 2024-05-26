using _11bugs.Common;
using _11bugs.View;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _11bugs.Views
{
	internal class Board
	{
		public Piles piles = new Piles();
		public Dictionary<Card, Texture2D> CardsImages = new Dictionary<Card, Texture2D>();
		private Dictionary<Card, Microsoft.Xna.Framework.Rectangle> cardsPos;

		private Microsoft.Xna.Framework.Vector2 Pile1Pos, Pile2Pos, Pile3Pos, Pile4Pos, Pile5Pos, Pile6Pos, Pile7Pos,
			HiddenPilePos, ShownPilePos, AceClubsPilePos, AceDiamondsPilePos, AceHeartsPilePos, AceSpadesPilePos;

		public Board()
		{
			Pile1Pos = new Microsoft.Xna.Framework.Vector2(50, 200);
			Pile2Pos = new Microsoft.Xna.Framework.Vector2(200, 200);
			Pile3Pos = new Microsoft.Xna.Framework.Vector2(350, 200);
			Pile4Pos = new Microsoft.Xna.Framework.Vector2(500, 200);
			Pile5Pos = new Microsoft.Xna.Framework.Vector2(650, 200);
			Pile6Pos = new Microsoft.Xna.Framework.Vector2(800, 200);
			Pile7Pos = new Microsoft.Xna.Framework.Vector2(950, 200);
			HiddenPilePos = new Microsoft.Xna.Framework.Vector2(50, 10);
			ShownPilePos = new Microsoft.Xna.Framework.Vector2(200, 10);
			AceClubsPilePos = new Microsoft.Xna.Framework.Vector2(500, 10);
			AceDiamondsPilePos = new Microsoft.Xna.Framework.Vector2(650, 10);
			AceHeartsPilePos = new Microsoft.Xna.Framework.Vector2(800, 10);
			AceSpadesPilePos = new Microsoft.Xna.Framework.Vector2(950, 10);

			cardsPos = new Dictionary<Card, Microsoft.Xna.Framework.Rectangle>();

			piles.ClubsPile = Card.Clubs;
			piles.DiamondsPile = Card.Diamonds;
			piles.HeartsPile = Card.Hearts;
			piles.SpadesPile = Card.Spades;
		}

		public void SetPiles(Piles piles)
		{
			this.piles = piles;
		}

		public bool IsPointInside(Microsoft.Xna.Framework.Vector2 position, int width, int height, Microsoft.Xna.Framework.Point point)
		{
			// Criar um retângulo a partir do Vector2 e das dimensões fornecidas
			Microsoft.Xna.Framework.Rectangle rect = new Microsoft.Xna.Framework.Rectangle((int)position.X, (int)position.Y, width, height);

			// Verificar se o ponto está dentro do retângulo
			return rect.Contains(point);
		}



		public Card? GetClickedCard(Microsoft.Xna.Framework.Point mousePoint)
		{
			//var a = IsPointInside(HiddenPilePos,94,147, mousePoint);

			List<Card> cards = new List<Card>();
			
			foreach(var carta in cardsPos)
			{
				if(carta.Value.Contains(mousePoint))
				{
					cards.Add(carta.Key);
				}
			}
			if(cards.Count == 0)
			{
				return null;
			}
			else
			{
				return cards[cards.Count - 1];
			}
		}

		public void Draw(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Vector2 imageScale, Microsoft.Xna.Framework.Color color, Texture2D overlayTexture)
		{
			if(piles == null) return;

			CardsPosClear();

			spriteBatch.Draw(CardsImages[piles.HiddenPile], HiddenPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);

			spriteBatch.Draw(CardsImages[Card.Place], ShownPilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);

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

		private void DrawPiles(List<(Card, bool)> cards, Microsoft.Xna.Framework.Vector2 pilePos, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Vector2 imageScale, Microsoft.Xna.Framework.Color color, Texture2D overlayTexture)
		{
			try
			{
				if(cards.Count == 0) { spriteBatch.Draw(CardsImages[Card.Place], pilePos, null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f); }
				else
				{
					for(int i = 0; i < cards.Count; i++)
					{
						Microsoft.Xna.Framework.Vector2 cardPosition = new Microsoft.Xna.Framework.Vector2((int)pilePos.X, (int)pilePos.Y + i * 35);
						Microsoft.Xna.Framework.Rectangle cardRect = new Microsoft.Xna.Framework.Rectangle((int)cardPosition.X, (int)cardPosition.Y, (int)(CardsImages[cards[i].Item1].Width * imageScale.X), (int)(CardsImages[cards[i].Item1].Height * imageScale.Y));

						if(!cardsPos.ContainsKey(cards[i].Item1))
							cardsPos.Add(cards[i].Item1, cardRect);

						spriteBatch.Draw(CardsImages[cards[i].Item1], new Microsoft.Xna.Framework.Vector2((int)(pilePos.X), (int)pilePos.Y + i * 35), null, color, 0f, Microsoft.Xna.Framework.Vector2.Zero, imageScale, SpriteEffects.None, 0f);

						if(cards[i].Item2)
						{
							Microsoft.Xna.Framework.Color overlayColor = new Microsoft.Xna.Framework.Color(0, 0, 255, 128);
							Microsoft.Xna.Framework.Rectangle overlayRectangle = new Microsoft.Xna.Framework.Rectangle((int)cardPosition.X, (int)cardPosition.Y, (int)(CardsImages[cards[i].Item1].Width * imageScale.X), (int)(CardsImages[cards[i].Item1].Height * imageScale.Y));
							spriteBatch.Draw(overlayTexture, overlayRectangle, overlayColor);
						}
					}
				}
			}
			catch(Exception ex)
			{

				throw;
			}
		}
		private void CardsPosClear()
		{
			cardsPos.Clear();
			try
			{
				if(!cardsPos.ContainsKey(Card.Hidden)) cardsPos.Add(Card.Hidden, new Microsoft.Xna.Framework.Rectangle((int)HiddenPilePos.X, (int)HiddenPilePos.Y, 94, 147));
				if(!cardsPos.ContainsKey(Card.Shown)) cardsPos.Add(Card.Shown, new Microsoft.Xna.Framework.Rectangle((int)ShownPilePos.X, (int)ShownPilePos.Y, 94, 147));

				if(!cardsPos.ContainsKey(Card.Clubs)) cardsPos.Add(Card.Clubs, new Microsoft.Xna.Framework.Rectangle((int)AceClubsPilePos.X, (int)AceClubsPilePos.Y, 94, 147));
				if(!cardsPos.ContainsKey(Card.Hearts)) cardsPos.Add(Card.Hearts, new Microsoft.Xna.Framework.Rectangle((int)AceHeartsPilePos.X, (int)AceHeartsPilePos.Y, 94, 147));
				if(!cardsPos.ContainsKey(Card.Diamonds)) cardsPos.Add(Card.Diamonds, new Microsoft.Xna.Framework.Rectangle((int)AceDiamondsPilePos.X, (int)AceDiamondsPilePos.Y, 94, 147));
				if(!cardsPos.ContainsKey(Card.Spades)) cardsPos.Add(Card.Spades, new Microsoft.Xna.Framework.Rectangle((int)AceSpadesPilePos.X, (int)AceSpadesPilePos.Y, 94, 147));

				if(!cardsPos.ContainsKey(Card.Pile1)) cardsPos.Add(Card.Pile1, new Microsoft.Xna.Framework.Rectangle((int)Pile1Pos.X, (int)Pile1Pos.Y, 94, 147));
				if(!cardsPos.ContainsKey(Card.Pile2)) cardsPos.Add(Card.Pile2, new Microsoft.Xna.Framework.Rectangle((int)Pile2Pos.X, (int)Pile2Pos.Y, 94, 147));
				if(!cardsPos.ContainsKey(Card.Pile3)) cardsPos.Add(Card.Pile3, new Microsoft.Xna.Framework.Rectangle((int)Pile3Pos.X, (int)Pile3Pos.Y, 94, 147));
				if(!cardsPos.ContainsKey(Card.Pile4)) cardsPos.Add(Card.Pile4, new Microsoft.Xna.Framework.Rectangle((int)Pile4Pos.X, (int)Pile4Pos.Y, 94, 147));
				if(!cardsPos.ContainsKey(Card.Pile5)) cardsPos.Add(Card.Pile5, new Microsoft.Xna.Framework.Rectangle((int)Pile5Pos.X, (int)Pile5Pos.Y, 94, 147));
				if(!cardsPos.ContainsKey(Card.Pile6)) cardsPos.Add(Card.Pile6, new Microsoft.Xna.Framework.Rectangle((int)Pile6Pos.X, (int)Pile6Pos.Y, 94, 147));
				if(!cardsPos.ContainsKey(Card.Pile7)) cardsPos.Add(Card.Pile7, new Microsoft.Xna.Framework.Rectangle((int)Pile7Pos.X, (int)Pile7Pos.Y, 94, 147));
			}
			catch(Exception ex)
			{
			}
		}
	}
}
