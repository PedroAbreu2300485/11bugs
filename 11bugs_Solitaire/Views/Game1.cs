using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _11bugs.View
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Common.Settings settings = new Common.Settings();

		private Texture2D _image;
		private Vector2 _imageScale;

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
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

			_image = Content.Load<Texture2D>("SemCarta\\posicao");

			_imageScale = new Vector2(100f / _image.Width, 150f / _image.Height);
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
            GraphicsDevice.Clear(Color.Green);

            _spriteBatch.Begin();

			_spriteBatch.Draw(_image, new Vector2(10, 10), null, Color.White, 0f, Vector2.Zero, _imageScale, SpriteEffects.None, 0f);

			//_spriteBatch.Draw(_image, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);

			_spriteBatch.End();

			base.Draw(gameTime);
        }
    }
}
