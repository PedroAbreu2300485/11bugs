using Decktacular;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _11bugs_Solitaire
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Settings settings = new Settings();

        public Game1()
        {
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
			int newWidth = (int)(currentWidth * settings.screenResize);
			int newHeight = (int)(currentHeight * settings.screenResize);

			// Define a nova resolução sem habilitar tela cheia
			_graphics.PreferredBackBufferWidth = newWidth;
			_graphics.PreferredBackBufferHeight = newHeight;
			_graphics.IsFullScreen = false; // Garantir que o modo de tela cheia está desativado
			_graphics.ApplyChanges();

			base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
