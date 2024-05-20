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
		public event PedeDefinicoes PedirDefinicoes;

		public event Carta CartaClicada;
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
		private Common.Settings settings = new Common.Settings();
		private Common.Cards cards = new Common.Cards();
		private Board board;

		private Texture2D _image;
		private Vector2 _imageScale;

		public View(Board board = null)
		{
			_11bugs.Controller.Controller controller = new _11bugs.Controller.Controller(this);

			if(board == null)
				this.board = new Board(0);
			else
				this.board = board;

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

			board.CardsImages.Add(Common.Cards.Back, Content.Load<Texture2D>(@"Costas\preto"));

			board.CardsImages.Add(Common.Cards.HA, Content.Load<Texture2D>(@"Frentes\Copas_As"));
			board.CardsImages.Add(Common.Cards.H2, Content.Load<Texture2D>(@"Frentes\Copas_2"));
			board.CardsImages.Add(Common.Cards.H3, Content.Load<Texture2D>(@"Frentes\Copas_3"));
			board.CardsImages.Add(Common.Cards.H4, Content.Load<Texture2D>(@"Frentes\Copas_4"));
			board.CardsImages.Add(Common.Cards.H5, Content.Load<Texture2D>(@"Frentes\Copas_5"));
			board.CardsImages.Add(Common.Cards.H6, Content.Load<Texture2D>(@"Frentes\Copas_6"));
			//board.CardsImages.Add(Common.Cards.H7, Content.Load<Texture2D>(@"Frentes\Copas_7"));
			board.CardsImages.Add(Common.Cards.H8, Content.Load<Texture2D>(@"Frentes\Copas_8"));
			board.CardsImages.Add(Common.Cards.H9, Content.Load<Texture2D>(@"Frentes\Copas_9"));
			board.CardsImages.Add(Common.Cards.HT, Content.Load<Texture2D>(@"Frentes\Copas_10"));
			board.CardsImages.Add(Common.Cards.HJ, Content.Load<Texture2D>(@"Frentes\Copas_J"));
			board.CardsImages.Add(Common.Cards.HQ, Content.Load<Texture2D>(@"Frentes\Copas_Q"));
			board.CardsImages.Add(Common.Cards.HK, Content.Load<Texture2D>(@"Frentes\Copas_K"));

			board.CardsImages.Add(Common.Cards.SA, Content.Load<Texture2D>(@"Frentes\Espadas_As"));
			board.CardsImages.Add(Common.Cards.S2, Content.Load<Texture2D>(@"Frentes\Espadas_2"));
			board.CardsImages.Add(Common.Cards.S3, Content.Load<Texture2D>(@"Frentes\Espadas_3"));
			board.CardsImages.Add(Common.Cards.S4, Content.Load<Texture2D>(@"Frentes\Espadas_4"));
			board.CardsImages.Add(Common.Cards.S5, Content.Load<Texture2D>(@"Frentes\Espadas_5"));
			board.CardsImages.Add(Common.Cards.S6, Content.Load<Texture2D>(@"Frentes\Espadas_6"));
			board.CardsImages.Add(Common.Cards.S7, Content.Load<Texture2D>(@"Frentes\Espadas_7"));
			board.CardsImages.Add(Common.Cards.S8, Content.Load<Texture2D>(@"Frentes\Espadas_8"));
			board.CardsImages.Add(Common.Cards.S9, Content.Load<Texture2D>(@"Frentes\Espadas_9"));
			board.CardsImages.Add(Common.Cards.ST, Content.Load<Texture2D>(@"Frentes\Espadas_10"));
			board.CardsImages.Add(Common.Cards.SJ, Content.Load<Texture2D>(@"Frentes\Espadas_J"));
			board.CardsImages.Add(Common.Cards.SQ, Content.Load<Texture2D>(@"Frentes\Espadas_Q"));
			board.CardsImages.Add(Common.Cards.SK, Content.Load<Texture2D>(@"Frentes\Espadas_K"));

			board.CardsImages.Add(Common.Cards.DA, Content.Load<Texture2D>(@"Frentes\Ouros_As"));
			board.CardsImages.Add(Common.Cards.D2, Content.Load<Texture2D>(@"Frentes\Ouros_2"));
			board.CardsImages.Add(Common.Cards.D3, Content.Load<Texture2D>(@"Frentes\Ouros_3"));
			board.CardsImages.Add(Common.Cards.D4, Content.Load<Texture2D>(@"Frentes\Ouros_4"));
			board.CardsImages.Add(Common.Cards.D5, Content.Load<Texture2D>(@"Frentes\Ouros_5"));
			board.CardsImages.Add(Common.Cards.D6, Content.Load<Texture2D>(@"Frentes\Ouros_6"));
			board.CardsImages.Add(Common.Cards.D7, Content.Load<Texture2D>(@"Frentes\Ouros_7"));
			board.CardsImages.Add(Common.Cards.D8, Content.Load<Texture2D>(@"Frentes\Ouros_8"));
			board.CardsImages.Add(Common.Cards.D9, Content.Load<Texture2D>(@"Frentes\Ouros_9"));
			board.CardsImages.Add(Common.Cards.DT, Content.Load<Texture2D>(@"Frentes\Ouros_10"));
			board.CardsImages.Add(Common.Cards.DJ, Content.Load<Texture2D>(@"Frentes\Ouros_J"));
			board.CardsImages.Add(Common.Cards.DQ, Content.Load<Texture2D>(@"Frentes\Ouros_Q"));
			board.CardsImages.Add(Common.Cards.DK, Content.Load<Texture2D>(@"Frentes\Ouros_K"));

			board.CardsImages.Add(Common.Cards.CA, Content.Load<Texture2D>(@"Frentes\Paus_As"));
			board.CardsImages.Add(Common.Cards.C2, Content.Load<Texture2D>(@"Frentes\Paus_2"));
			board.CardsImages.Add(Common.Cards.C3, Content.Load<Texture2D>(@"Frentes\Paus_3"));
			board.CardsImages.Add(Common.Cards.C4, Content.Load<Texture2D>(@"Frentes\Paus_4"));
			//board.CardsImages.Add(Common.Cards.C5, Content.Load<Texture2D>(@"Frentes\Paus_5"));
			board.CardsImages.Add(Common.Cards.C6, Content.Load<Texture2D>(@"Frentes\Paus_6"));
			board.CardsImages.Add(Common.Cards.C7, Content.Load<Texture2D>(@"Frentes\Paus_7"));
			board.CardsImages.Add(Common.Cards.C8, Content.Load<Texture2D>(@"Frentes\Paus_8"));
			board.CardsImages.Add(Common.Cards.C9, Content.Load<Texture2D>(@"Frentes\Paus_9"));
			board.CardsImages.Add(Common.Cards.CT, Content.Load<Texture2D>(@"Frentes\Paus_10"));
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

		internal void EstadoAtualizado(Piles piles)
		{
			Console.WriteLine("Estado atualizado");
		}

	}
}
