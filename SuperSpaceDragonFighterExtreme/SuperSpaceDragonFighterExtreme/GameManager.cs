using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace SuperSpaceDragonFighterExtreme
{
    public enum GameState
    {
        Intro,
        MainMenu,
        Options,
        Playing
    };

    static public class GameManager
    {
        #region Variables

     //   public static List<Level> levels;
        private static int currentLevel;
        public static GameState gameState = GameState.MainMenu;

        #region Logo Variables

        private static Texture2D logoTexture;
        private static Vector2 logoCenter;
        private static int alphaValue = 1;
        private static int fadeIncrement = 3;
        private static double fadeDelay = 0.20;
        private static int delayer = 1;
        private static int checkIntro = 0;
        private static double frameTime;
        private static GraphicsDeviceManager graphicsDM;

        #endregion

        #endregion

        #region Properties

        public static int CurrentLevel
        {
            get { return currentLevel; }
        }

        #endregion

        public static void Initialize(GraphicsDeviceManager graphics)
        {
            logoTexture = Game1.logoTexture;
            logoCenter = new Vector2(logoTexture.Width / 2, logoTexture.Height / 2);
            graphicsDM = graphics;
        }

        public static void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                case GameState.Intro:
                    {
                        //fade in logo
                        fadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;

                        if (fadeDelay <= 0)
                        {
                            //reset fade delay
                            fadeDelay = 0.45;

                            //increment / decrement fade value of logo
                            alphaValue += fadeIncrement;

                            if (alphaValue <= 0)
                                fadeIncrement *= -1;
                        }

                        if (delayer <= 400)
                            delayer++;
                        else
                            delayer = 401;

                        frameTime = gameTime.ElapsedGameTime.Milliseconds / 1000.00;
                        break;
                    }

                case GameState.MainMenu:
                    {
                        //MenuManager.Update();
                        break;
                    }
                case GameState.Options:
                    {
                        //TODO: Add options class to framework
                        break;
                    }
                case GameState.Playing:
                    break;
            }
        }

        public static void Draw(SpriteBatch sb, SpriteBatch sbHud)
        {
            switch (gameState)
            {
                case GameState.Intro:
                    {
                        if (delayer >= 400)
                            gameState = GameState.MainMenu;
                        else
                        {
                            graphicsDM.GraphicsDevice.Clear(Color.White);
                            DrawLogo(sbHud);
                        }
                        break;
                    }
                case GameState.MainMenu:
                    {
                        //MenuManager.Draw(sbHud);
                        break;
                    }
                case GameState.Options:
                    {
                        //TODO: Draw Options
                        break;
                    }
                case GameState.Playing:
                    {
                        break;
                    }
            }
        }

        private static void DrawLogo(SpriteBatch sbHud)
        {
            sbHud.Draw(logoTexture, new Rectangle(0,0, logoTexture.Width, logoTexture.Height),
                new Color(255,255,255, (byte)MathHelper.Clamp(alphaValue, 0, 255)));
        }
    }
}
