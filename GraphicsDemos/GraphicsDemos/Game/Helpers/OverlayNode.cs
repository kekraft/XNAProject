using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using GraphicsToolkit.Input;
using GraphicsToolkit;
using Microsoft.Xna.Framework.Input;

namespace XANALand.Game
{
    /// <summary>
    /// 
    /// </summary>
    /// <author>Stephen Kiningham</author>
    public class OverlayNode : GameContent
    {
        private GraphicsDevice device;
        private SpriteFont debugFont;
        private SpriteBatch spriteBatch;
        private Vector2 spriteFontPosition = new Vector2(1, 1);
        private string[] text = { "Hello World" };
        private bool showDebug = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="g"></param>
        public override void LoadContent(ContentManager c, GraphicsDevice g)
        {
            device = g;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(device);

            debugFont = c.Load<SpriteFont>("DebugFont");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public override void Update(GameTime g)
        {
            if (InputHandler.IsNewButtonPress(Buttons.Start, PlayerIndex.One) || InputHandler.IsNewKeyPress(Keys.F3))
            {
                showDebug = !showDebug;
            }
        }

        /// <summary>
        /// Draws the debug overlay
        /// </summary>
        /// <param name="g">Gametime variable.</param>
        public override void Draw(GameTime g)
        {
            if (showDebug)
            {
                spriteBatch.Begin();
                text[0] = string.Format("FPS: {0}", Math.Round(1 / g.ElapsedGameTime.TotalSeconds));
                spriteBatch.DrawString(debugFont, text[0], spriteFontPosition, Color.White);
                spriteBatch.End();
            }
        }
    }
}
