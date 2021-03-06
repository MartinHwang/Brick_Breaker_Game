﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IHFinalProject
{
    public class AboutScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;

        public AboutScene(Game game,
             SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            tex = game.Content.Load<Texture2D>("Images/spaceBackgroundWithLogo");
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, new Vector2(0, 0), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }   
    }
}
