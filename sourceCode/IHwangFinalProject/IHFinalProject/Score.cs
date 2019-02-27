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
    public class Score : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private Vector2 position;
        private Color color;
        private string message;
        private int currScore;
        public Score(Game game,
           SpriteBatch spriteBatch,
           SpriteFont font,
           Vector2 position,
           string message, int score,
           Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = font;
            this.position = position;
            this.color = color;
            this.message = message;
            this.currScore = score;
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, message, position, color);
            spriteBatch.End();
            base.Draw(gameTime);
        }
      
        public void getScore()
        {
            currScore += 10;
            message = "Current Score: " + currScore;
        } 
    }
}
