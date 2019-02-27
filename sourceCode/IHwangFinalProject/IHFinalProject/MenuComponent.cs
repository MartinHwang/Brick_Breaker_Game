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
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont;
        private SpriteFont highLightFont;
        private List<string> menuItems;
        private Texture2D tex;
        public Vector2 logoPosition;
    
        public int SelectedIndex { get; set; } = 0;
        private Vector2 menuPosition;
        private Color regularColor = Color.DarkBlue;
        private Color highLightColor = Color.AntiqueWhite;
        private KeyboardState oldState;

        public MenuComponent(Game game,
            SpriteBatch spriteBatch,
            SpriteFont regularFont,
            SpriteFont highLightFont,
            string[] menu, 
            Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.highLightFont = highLightFont;
            menuItems = menu.ToList<string>();
            this.tex = tex;
            menuPosition = new Vector2(Shared.stage.X / 3, Shared.stage.Y / 2);
            logoPosition = new Vector2(0, -150);
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = menuPosition;
            spriteBatch.Begin();
            spriteBatch.Draw(tex, logoPosition, Color.White);
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (SelectedIndex == i)
                {
                    spriteBatch.DrawString(highLightFont, menuItems[i], tempPos, highLightColor);
                    tempPos.Y += highLightFont.LineSpacing;
                }
                else
                {
                    spriteBatch.DrawString(regularFont, menuItems[i], tempPos, regularColor);
                    tempPos.Y += regularFont.LineSpacing;
                }

            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                SelectedIndex++;
                if (SelectedIndex == menuItems.Count)
                {
                    SelectedIndex = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = menuItems.Count - 1;
                }
            }
            oldState = ks; 
            base.Update(gameTime);
        }
    }
}
