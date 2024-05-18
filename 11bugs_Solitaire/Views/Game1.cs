using _11bugs.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _11bugs.View
{
	class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private Common.Settings settings = new Common.Settings();
		private Common.Cards cards = new Common.Cards();
		private Board board;

		private Texture2D _image;
		private Vector2 _imageScale;

		public Game1(Board board)
		{
			this.board = board;
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{

			// Obtém a resolução atual do monitor principal
			int currentWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			int currentHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

			// Calcula a nova resolução, aumentando de acordo com o valor de screenSizeRelation
			//int newWidth = (int)(currentWidth * settings.screenResize);
			//int newHeight = (int)(currentHeight * settings.screenResize);
			int newWidth = 1100;
			int newHeight = 800;

			// Define a nova resolução sem habilitar tela cheia
			_graphics.PreferredBackBufferWidth = newWidth;
			_graphics.PreferredBackBufferHeight = newHeight;
			_graphics.IsFullScreen = false;
			_graphics.ApplyChanges();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			_imageScale = new Vector2(100f / 79, 150f / 123);
			board.CardsImages.Add(Common.Cards.Place, Content.Load<Texture2D>(@"SemCarta\posicao"));
			board.CardsImages.Add(Common.Cards.Hearts, Content.Load<Texture2D>(@"SemCarta\Copas"));
			board.CardsImages.Add(Common.Cards.Spades, Content.Load<Texture2D>(@"SemCarta\Espadas"));
			board.CardsImages.Add(Common.Cards.Diamonds, Content.Load<Texture2D>(@"SemCarta\Ouros"));
			board.CardsImages.Add(Common.Cards.Clubs, Content.Load<Texture2D>(@"SemCarta\Paus"));

			board.CardsImages.Add(Common.Cards.H1, Content.Load<Texture2D>(@"Frentes\Copas_As"));
			board.CardsImages.Add(Common.Cards.H2, Content.Load<Texture2D>(@"Frentes\Copas_2"));
			board.CardsImages.Add(Common.Cards.H3, Content.Load<Texture2D>(@"Frentes\Copas_3"));
			board.CardsImages.Add(Common.Cards.H4, Content.Load<Texture2D>(@"Frentes\Copas_4"));
			board.CardsImages.Add(Common.Cards.H5, Content.Load<Texture2D>(@"Frentes\Copas_5"));
			board.CardsImages.Add(Common.Cards.H6, Content.Load<Texture2D>(@"Frentes\Copas_6"));
			//board.CardsImages.Add(Common.Cards.H7, Content.Load<Texture2D>(@"Frentes\Copas_7"));
			board.CardsImages.Add(Common.Cards.H8, Content.Load<Texture2D>(@"Frentes\Copas_8"));
			board.CardsImages.Add(Common.Cards.H9, Content.Load<Texture2D>(@"Frentes\Copas_9"));
			board.CardsImages.Add(Common.Cards.H10, Content.Load<Texture2D>(@"Frentes\Copas_10"));
			board.CardsImages.Add(Common.Cards.HJ, Content.Load<Texture2D>(@"Frentes\Copas_J"));
			board.CardsImages.Add(Common.Cards.HQ, Content.Load<Texture2D>(@"Frentes\Copas_Q"));
			board.CardsImages.Add(Common.Cards.HK, Content.Load<Texture2D>(@"Frentes\Copas_K"));

			board.CardsImages.Add(Common.Cards.S1, Content.Load<Texture2D>(@"Frentes\Espadas_As"));
			board.CardsImages.Add(Common.Cards.S2, Content.Load<Texture2D>(@"Frentes\Espadas_2"));
			board.CardsImages.Add(Common.Cards.S3, Content.Load<Texture2D>(@"Frentes\Espadas_3"));
			board.CardsImages.Add(Common.Cards.S4, Content.Load<Texture2D>(@"Frentes\Espadas_4"));
			board.CardsImages.Add(Common.Cards.S5, Content.Load<Texture2D>(@"Frentes\Espadas_5"));
			board.CardsImages.Add(Common.Cards.S6, Content.Load<Texture2D>(@"Frentes\Espadas_6"));
			board.CardsImages.Add(Common.Cards.S7, Content.Load<Texture2D>(@"Frentes\Espadas_7"));
			board.CardsImages.Add(Common.Cards.S8, Content.Load<Texture2D>(@"Frentes\Espadas_8"));
			board.CardsImages.Add(Common.Cards.S9, Content.Load<Texture2D>(@"Frentes\Espadas_9"));
			board.CardsImages.Add(Common.Cards.S10, Content.Load<Texture2D>(@"Frentes\Espadas_10"));
			board.CardsImages.Add(Common.Cards.SJ, Content.Load<Texture2D>(@"Frentes\Espadas_J"));
			board.CardsImages.Add(Common.Cards.SQ, Content.Load<Texture2D>(@"Frentes\Espadas_Q"));
			board.CardsImages.Add(Common.Cards.SK, Content.Load<Texture2D>(@"Frentes\Espadas_K"));

			board.CardsImages.Add(Common.Cards.D1, Content.Load<Texture2D>(@"Frentes\Ouros_As"));
			board.CardsImages.Add(Common.Cards.D2, Content.Load<Texture2D>(@"Frentes\Ouros_2"));
			board.CardsImages.Add(Common.Cards.D3, Content.Load<Texture2D>(@"Frentes\Ouros_3"));
			board.CardsImages.Add(Common.Cards.D4, Content.Load<Texture2D>(@"Frentes\Ouros_4"));
			board.CardsImages.Add(Common.Cards.D5, Content.Load<Texture2D>(@"Frentes\Ouros_5"));
			board.CardsImages.Add(Common.Cards.D6, Content.Load<Texture2D>(@"Frentes\Ouros_6"));
			board.CardsImages.Add(Common.Cards.D7, Content.Load<Texture2D>(@"Frentes\Ouros_7"));
			board.CardsImages.Add(Common.Cards.D8, Content.Load<Texture2D>(@"Frentes\Ouros_8"));
			board.CardsImages.Add(Common.Cards.D9, Content.Load<Texture2D>(@"Frentes\Ouros_9"));
			board.CardsImages.Add(Common.Cards.D10, Content.Load<Texture2D>(@"Frentes\Ouros_10"));
			board.CardsImages.Add(Common.Cards.DJ, Content.Load<Texture2D>(@"Frentes\Ouros_J"));
			board.CardsImages.Add(Common.Cards.DQ, Content.Load<Texture2D>(@"Frentes\Ouros_Q"));
			board.CardsImages.Add(Common.Cards.DK, Content.Load<Texture2D>(@"Frentes\Ouros_K"));

			board.CardsImages.Add(Common.Cards.C1, Content.Load<Texture2D>(@"Frentes\Paus_As"));
			board.CardsImages.Add(Common.Cards.C2, Content.Load<Texture2D>(@"Frentes\Paus_2"));
			board.CardsImages.Add(Common.Cards.C3, Content.Load<Texture2D>(@"Frentes\Paus_3"));
			board.CardsImages.Add(Common.Cards.C4, Content.Load<Texture2D>(@"Frentes\Paus_4"));
			//board.CardsImages.Add(Common.Cards.C5, Content.Load<Texture2D>(@"Frentes\Paus_5"));
			board.CardsImages.Add(Common.Cards.C6, Content.Load<Texture2D>(@"Frentes\Paus_6"));
			board.CardsImages.Add(Common.Cards.C7, Content.Load<Texture2D>(@"Frentes\Paus_7"));
			board.CardsImages.Add(Common.Cards.C8, Content.Load<Texture2D>(@"Frentes\Paus_8"));
			board.CardsImages.Add(Common.Cards.C9, Content.Load<Texture2D>(@"Frentes\Paus_9"));
			board.CardsImages.Add(Common.Cards.C10, Content.Load<Texture2D>(@"Frentes\Paus_10"));
			board.CardsImages.Add(Common.Cards.CJ, Content.Load<Texture2D>(@"Frentes\Paus_J"));
			board.CardsImages.Add(Common.Cards.CQ, Content.Load<Texture2D>(@"Frentes\Paus_Q"));
			board.CardsImages.Add(Common.Cards.CK, Content.Load<Texture2D>(@"Frentes\Paus_K"));

		}

		protected override void Update(GameTime gameTime)
		{
			if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Green);

			_spriteBatch.Begin();

			board.Draw(_spriteBatch, _imageScale, Color.White);

			//_spriteBatch.Draw(_image, new Vector2(10, 10), null, Color.White, 0f, Vector2.Zero, _imageScale, SpriteEffects.None, 0f);

			//_spriteBatch.Draw(_image, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
