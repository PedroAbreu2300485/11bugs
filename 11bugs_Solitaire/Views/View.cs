using _11bugs.Common;
using _11bugs.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _11bugs.View
{
	public delegate void Carta(int numCarta);

	class View : Game
	{
		public delegate void PedeDefinicoes(ref string asDefinicoes);
		public delegate void CardType(Card card);
		public event PedeDefinicoes PedirDefinicoes;

		public event CardType CartaClicada;
		public event Carta CartaLargada;

		public delegate void Notificar();
		public event Notificar InterfaceDesenhada;
		public event Notificar NovoJogoDesenhado;
		public event Notificar UserClicouNovoJogo;
		public event Notificar UserClicouGravarJogo;
		public event Notificar UserClicouAbrirJogo;
		public event Notificar UserClicouSair;

		public event Notificar UserAlterouAsDefinicoes;


		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private Texture2D overlayTexture;

		private MouseState _previousMouseState;
		private Board board;

		private Vector2 _imageScale;

		public View(Board board = null)
		{
			Controller.Controller controller = new Controller.Controller(this);

			this.board = new Board();

			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			int currentWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			int currentHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

			int newWidth = 1100;
			int newHeight = 900;

			_graphics.PreferredBackBufferWidth = newWidth;
			_graphics.PreferredBackBufferHeight = newHeight;
			_graphics.IsFullScreen = false;
			_graphics.ApplyChanges();

			_previousMouseState = Mouse.GetState();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			overlayTexture = new Texture2D(GraphicsDevice, 1, 1);
			overlayTexture.SetData(new[] { Color.White });

			_imageScale = new Vector2(1, 1);
			board.CardsImages.Add(Card.Place, Content.Load<Texture2D>(@"SemCarta\posicao"));
			board.CardsImages.Add(Card.Hearts, Content.Load<Texture2D>(@"SemCarta\Copas"));
			board.CardsImages.Add(Card.Spades, Content.Load<Texture2D>(@"SemCarta\Espadas"));
			board.CardsImages.Add(Card.Diamonds, Content.Load<Texture2D>(@"SemCarta\Ouros"));
			board.CardsImages.Add(Card.Clubs, Content.Load<Texture2D>(@"SemCarta\Paus"));

			board.CardsImages.Add(Card.Back, Content.Load<Texture2D>(@"Costas\preto"));

			board.CardsImages.Add(Card.HA, Content.Load<Texture2D>(@"Frentes\Copas_As"));
			board.CardsImages.Add(Card.H2, Content.Load<Texture2D>(@"Frentes\Copas_2"));
			board.CardsImages.Add(Card.H3, Content.Load<Texture2D>(@"Frentes\Copas_3"));
			board.CardsImages.Add(Card.H4, Content.Load<Texture2D>(@"Frentes\Copas_4"));
			board.CardsImages.Add(Card.H5, Content.Load<Texture2D>(@"Frentes\Copas_5"));
			board.CardsImages.Add(Card.H6, Content.Load<Texture2D>(@"Frentes\Copas_6"));
			board.CardsImages.Add(Card.H7, Content.Load<Texture2D>(@"Frentes\Copas_7"));
			board.CardsImages.Add(Card.H8, Content.Load<Texture2D>(@"Frentes\Copas_8"));
			board.CardsImages.Add(Card.H9, Content.Load<Texture2D>(@"Frentes\Copas_9"));
			board.CardsImages.Add(Card.HT, Content.Load<Texture2D>(@"Frentes\Copas_10"));
			board.CardsImages.Add(Card.HJ, Content.Load<Texture2D>(@"Frentes\Copas_J"));
			board.CardsImages.Add(Card.HQ, Content.Load<Texture2D>(@"Frentes\Copas_Q"));
			board.CardsImages.Add(Card.HK, Content.Load<Texture2D>(@"Frentes\Copas_K"));

			board.CardsImages.Add(Card.SA, Content.Load<Texture2D>(@"Frentes\Espadas_As"));
			board.CardsImages.Add(Card.S2, Content.Load<Texture2D>(@"Frentes\Espadas_2"));
			board.CardsImages.Add(Card.S3, Content.Load<Texture2D>(@"Frentes\Espadas_3"));
			board.CardsImages.Add(Card.S4, Content.Load<Texture2D>(@"Frentes\Espadas_4"));
			board.CardsImages.Add(Card.S5, Content.Load<Texture2D>(@"Frentes\Espadas_5"));
			board.CardsImages.Add(Card.S6, Content.Load<Texture2D>(@"Frentes\Espadas_6"));
			board.CardsImages.Add(Card.S7, Content.Load<Texture2D>(@"Frentes\Espadas_7"));
			board.CardsImages.Add(Card.S8, Content.Load<Texture2D>(@"Frentes\Espadas_8"));
			board.CardsImages.Add(Card.S9, Content.Load<Texture2D>(@"Frentes\Espadas_9"));
			board.CardsImages.Add(Card.ST, Content.Load<Texture2D>(@"Frentes\Espadas_10"));
			board.CardsImages.Add(Card.SJ, Content.Load<Texture2D>(@"Frentes\Espadas_J"));
			board.CardsImages.Add(Card.SQ, Content.Load<Texture2D>(@"Frentes\Espadas_Q"));
			board.CardsImages.Add(Card.SK, Content.Load<Texture2D>(@"Frentes\Espadas_K"));

			board.CardsImages.Add(Card.DA, Content.Load<Texture2D>(@"Frentes\Ouros_As"));
			board.CardsImages.Add(Card.D2, Content.Load<Texture2D>(@"Frentes\Ouros_2"));
			board.CardsImages.Add(Card.D3, Content.Load<Texture2D>(@"Frentes\Ouros_3"));
			board.CardsImages.Add(Card.D4, Content.Load<Texture2D>(@"Frentes\Ouros_4"));
			board.CardsImages.Add(Card.D5, Content.Load<Texture2D>(@"Frentes\Ouros_5"));
			board.CardsImages.Add(Card.D6, Content.Load<Texture2D>(@"Frentes\Ouros_6"));
			board.CardsImages.Add(Card.D7, Content.Load<Texture2D>(@"Frentes\Ouros_7"));
			board.CardsImages.Add(Card.D8, Content.Load<Texture2D>(@"Frentes\Ouros_8"));
			board.CardsImages.Add(Card.D9, Content.Load<Texture2D>(@"Frentes\Ouros_9"));
			board.CardsImages.Add(Card.DT, Content.Load<Texture2D>(@"Frentes\Ouros_10"));
			board.CardsImages.Add(Card.DJ, Content.Load<Texture2D>(@"Frentes\Ouros_J"));
			board.CardsImages.Add(Card.DQ, Content.Load<Texture2D>(@"Frentes\Ouros_Q"));
			board.CardsImages.Add(Card.DK, Content.Load<Texture2D>(@"Frentes\Ouros_K"));

			board.CardsImages.Add(Card.CA, Content.Load<Texture2D>(@"Frentes\Paus_As"));
			board.CardsImages.Add(Card.C2, Content.Load<Texture2D>(@"Frentes\Paus_2"));
			board.CardsImages.Add(Card.C3, Content.Load<Texture2D>(@"Frentes\Paus_3"));
			board.CardsImages.Add(Card.C4, Content.Load<Texture2D>(@"Frentes\Paus_4"));
			board.CardsImages.Add(Card.C5, Content.Load<Texture2D>(@"Frentes\Paus_5"));
			board.CardsImages.Add(Card.C6, Content.Load<Texture2D>(@"Frentes\Paus_6"));
			board.CardsImages.Add(Card.C7, Content.Load<Texture2D>(@"Frentes\Paus_7"));
			board.CardsImages.Add(Card.C8, Content.Load<Texture2D>(@"Frentes\Paus_8"));
			board.CardsImages.Add(Card.C9, Content.Load<Texture2D>(@"Frentes\Paus_9"));
			board.CardsImages.Add(Card.CT, Content.Load<Texture2D>(@"Frentes\Paus_10"));
			board.CardsImages.Add(Card.CJ, Content.Load<Texture2D>(@"Frentes\Paus_J"));
			board.CardsImages.Add(Card.CQ, Content.Load<Texture2D>(@"Frentes\Paus_Q"));
			board.CardsImages.Add(Card.CK, Content.Load<Texture2D>(@"Frentes\Paus_K"));

		}

		protected override void Update(GameTime gameTime)
		{
			if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			MouseState currentMouseState = Mouse.GetState();
			if(_previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Released)
			{
				var cardClicked = board.GetClickedCard(currentMouseState.Position);
				if(cardClicked != null)
					CartaClicada((Card)cardClicked);
			}
			_previousMouseState = currentMouseState;
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Green);

			_spriteBatch.Begin();

			board.Draw(_spriteBatch, _imageScale, Color.White, overlayTexture);

			_spriteBatch.End();

			base.Draw(gameTime);
		}


		internal void DefinicoesCarregadas()
		{
			Console.WriteLine("Definicoes carregadaas");
		}

		internal void NovoJogoCriado()
		{
			Console.WriteLine("NovoJogoCriado");
		}

		internal void EstadoAtualizado(IPiles piles)
		{
			board.SetPiles(piles);
		}

	}
}
