using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SuperSpaceDragonFighterExtreme
{
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Variables

        #region Constants

        const int SCREEN_WIDTH = 1240;
        const int SCREEN_HEIGHT = 800;

        #endregion

        #region Fonts

        SpriteFont fontSmall;
        SpriteFont fontLarge;

        #endregion

        GraphicsDeviceManager graphics;
        SpriteBatch sb;
        SpriteBatch sbHUD;
        bool exitGame = false;

        #region Textures

        public static Texture2D logoTexture;

        #endregion

        #endregion

        #region Ctor

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        #endregion

        #region XNA Methods

        protected override void Initialize()
        {
            Window.Title = "Super Space Dragon Fighter Extreme";
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            sb = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            GameManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        #endregion
    }
}
