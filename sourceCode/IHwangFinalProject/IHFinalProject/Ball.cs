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
    public class Ball : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public Vector2 position;
        public Vector2 speed;
        private Vector2 stage;
        private GameOver go;
        private ScrollingBackground sb, sb2;
        private SoundEffect failSound;
        private SoundEffect boundSound;
        public Ball(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed,
            Vector2 stage, GameOver go, 
            ScrollingBackground sb, 
            ScrollingBackground sb2, 
            SoundEffect failSound,
            SoundEffect boundSound) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
            this.go = go;
            this.sb = sb;
            this.sb2 = sb2;
            this.failSound = failSound;
            this.boundSound = boundSound;
        }

        public override void Update(GameTime gameTime)
        {
            
            this.position += this.speed;
            // handle top wall
            if (position.Y < 0)
            {
                speed.Y = Math.Abs(speed.Y);
                boundSound.Play();
               
            }
            //right wall
            if (position.X + tex.Width > stage.X)
            {
                speed.X = -Math.Abs(speed.X);
                boundSound.Play();
            }

            //left wall
            if (position.X < 0)
            {
                speed.X = Math.Abs(speed.X);
                boundSound.Play();
            }

            //bottom wall
            if (position.Y > stage.Y)
            {
               
                this.Enabled = false;
                failSound.Play();
                go.show();
                sb.StopScrollingBackground();
                sb2.StopScrollingBackground();

            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
