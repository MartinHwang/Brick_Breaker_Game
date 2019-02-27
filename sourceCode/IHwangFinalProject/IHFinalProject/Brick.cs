using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;


namespace IHFinalProject
{
    public class Brick : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 stage;
        public Vector2 position;
        public Rectangle bottomRect;
        public Rectangle leftRect;
        public Rectangle upperRect;
        public Rectangle rightRect;
        public Color color;

        public Brick(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 stage,
            Vector2 position, Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.stage = stage;
            this.position = position;
            this.color = color;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, color);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void hide()
        {
            this.Visible = false;
            this.Enabled = false;
        }
        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }

        public void createRects()
        {
            bottomRect = new Rectangle((int)position.X, (int)position.Y + tex.Height, tex.Width, 3);
            upperRect = new Rectangle((int)position.X, (int)position.Y - 3, tex.Width, 3);
            leftRect = new Rectangle((int)position.X - 3, (int)position.Y, 3, tex.Height);
            rightRect = new Rectangle((int)position.X + tex.Width, (int)position.Y, 3, tex.Height);
        }
    }
}
