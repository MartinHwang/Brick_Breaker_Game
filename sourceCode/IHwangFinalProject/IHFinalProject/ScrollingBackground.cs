using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace IHFinalProject
{
    public class ScrollingBackground : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Rectangle srcRect;
        private Vector2 position1, position2;
        private Vector2 speed;
        public ScrollingBackground(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Rectangle srcRect,
            Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position1 = position;
            this.srcRect = srcRect;
            this.position2 = new Vector2(position1.X, position1.Y + tex.Height);
            this.srcRect = srcRect;
            this.speed = speed;
        }
        public void StopScrollingBackground()
        {
            this.Enabled = false;
        }
        public void StartScrollingBackground()
        {
            this.Enabled = true;
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position1, srcRect, Color.White);
            spriteBatch.Draw(tex, position2, srcRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public override void Update(GameTime gameTime)
        {
            position1 += speed;
            position2 += speed;
            if (position1.Y < -srcRect.Height)
            {
                position1.Y = position2.Y + srcRect.Height;
            }
            if (position2.Y < -srcRect.Height)
            {
                position2.Y = position1.Y + srcRect.Y;
            }
            base.Update(gameTime);
        }

    }
}
