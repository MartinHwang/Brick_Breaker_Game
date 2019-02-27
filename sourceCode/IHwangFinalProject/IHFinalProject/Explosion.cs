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
    public class Explosion : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public Vector2 Position { get; set; }
        public SpriteBatch SpriteBatch { get => spriteBatch; set => spriteBatch = value; }
        public Texture2D Tex { get => tex; set => tex = value; }

        private Vector2 dimension;
        private List<Rectangle> frames;
        private int frameIndex = -1;

        private int delay;
        private int delayCounter;

        private const int ROW = 5;
        private const int COL = 5;

        public Explosion(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            int delay) : base(game)
        {
            this.SpriteBatch = spriteBatch;
            this.Tex = tex;
            this.Position = position;
            this.delay = delay;
            dimension = new Vector2(tex.Width / COL, tex.Height / ROW);
            //stop/disable animation
            this.stopAnimation();
            //create frames
            Frames();
        }

        public void startAnimation()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public void stopAnimation()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        private void Frames()
        {
            frames = new List<Rectangle>();
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    int x = j * (int)dimension.X;
                    int y = i * (int)dimension.Y;
                    Rectangle r = new Rectangle(x, y,
                        (int)dimension.X, (int)dimension.Y);
                    frames.Add(r);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex > ROW * COL - 1)
                {
                    frameIndex = -1;
                    stopAnimation();
                }
                delayCounter = 0;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (frameIndex >= 0)
            {
                SpriteBatch.Begin();
                //version 4
                SpriteBatch.Draw(Tex, Position, frames[frameIndex], Color.White);

                SpriteBatch.End();
            }
            base.Draw(gameTime);
        }

    }
}
