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
    public class StartScene : GameScene
    {
        private SpriteBatch spriteBatch;
        public MenuComponent Menu { get; set; }
        
        private string[] menuItems =
        {
            "Play Game",
            "Help",
            "About",
            "Quit"
        };
        public StartScene(Game game, 
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            //TODO: consturct any game components here
            SpriteFont regularFont = game.Content.Load<SpriteFont>("Fonts/regularfont");
            SpriteFont hilightFont = game.Content.Load<SpriteFont>("Fonts/highlightfont");
            Texture2D tex = game.Content.Load<Texture2D>("Images/brickBreakerLogo");
            Menu = new MenuComponent(game, spriteBatch, regularFont, hilightFont, menuItems, tex);
            this.Components.Add(Menu);
        }
    }
}
