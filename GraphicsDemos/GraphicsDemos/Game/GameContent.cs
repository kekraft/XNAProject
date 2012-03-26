using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XANALand.Game
{
    public abstract class GameContent
    {
        protected GraphicsDevice Device;

        public virtual void LoadContent(ContentManager c, GraphicsDevice g)
        {
            Device = g;
        }

        public virtual void UnloadContent()
        {

        }

        public abstract void Update(GameTime g);
        public abstract void Draw(GameTime g);
    }
}
