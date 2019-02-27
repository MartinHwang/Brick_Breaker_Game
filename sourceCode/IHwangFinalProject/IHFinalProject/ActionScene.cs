using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IHFinalProject
{
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Bat bat;
        private Ball ball;
        private CollisionManager cm;
        private GameOver go;
        Explosion explosion;
        Vector2 ballInitPos, ballSpeed;
        Vector2 gameOverPos;
        Vector2 brickInit;
        Score score;
        Vector2 scoreInitPos;
        string message;
        public int currScore = 0;
        private List<Brick> brickWall;
        private Color color;

        public ActionScene(Game game,
            SpriteBatch spriteBatch, GraphicsDeviceManager graphics) : base(game)
        {
            this.spriteBatch = spriteBatch;
            //Background
            Texture2D tex = game.Content.Load<Texture2D>("Images/space");
            Rectangle srcRect = new Rectangle(0, 0, 1024, 1024);
            Vector2 pos = new Vector2(graphics.PreferredBackBufferWidth - srcRect.Width, 0);
            ScrollingBackground sb = new ScrollingBackground(game, spriteBatch, tex, pos, srcRect, new Vector2(0, -2));
            Vector2 pos2 = new Vector2(graphics.PreferredBackBufferWidth - srcRect.Width,
               graphics.PreferredBackBufferHeight-srcRect.Height);
            ScrollingBackground sb2 = new ScrollingBackground(game, spriteBatch, tex, pos2, srcRect, new Vector2(0, -2));

            //GameOver Message
            Texture2D gameOverText = game.Content.Load<Texture2D>("Images/gameOver");
            gameOverPos = new Vector2(230, 120);
            go = new GameOver(game, spriteBatch, gameOverText, gameOverPos);
            
            //Bat
            Texture2D batTex = game.Content.Load<Texture2D>("Images/Bat");
            SoundEffect backgroundSound = game.Content.Load<SoundEffect>("Sounds/background");
            bat = new Bat(game, spriteBatch, batTex, new Vector2(6, 0));

            //Ball
            Texture2D ballTex = game.Content.Load<Texture2D>("Images/Ball");
            SoundEffect failSound = game.Content.Load<SoundEffect>("Sounds/fail");
            SoundEffect boundSound = game.Content.Load<SoundEffect>("Sounds/bound");
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth,
               graphics.PreferredBackBufferHeight);
            ballInitPos = new Vector2(Shared.stage.X / 2 - ballTex.Width / 2,
                Shared.stage.Y / 2 - ballTex.Height / 2);
            ballSpeed = new Vector2(4, -4);
            ball = new Ball(game, spriteBatch, ballTex, ballInitPos, 
                ballSpeed, Shared.stage, go, sb, sb2, 
                failSound, boundSound);

            //Brick
            Texture2D brickTex = game.Content.Load<Texture2D>("Images/brick");
            brickInit = new Vector2(Shared.stage.X - 780,
                Shared.stage.Y  - 450);
            color = Color.White;
            brickWall = new List<Brick>();
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        color = Color.Red;
                        break;
                    case 1:
                        color = Color.Orange;
                        break;
                    case 2:
                        color = Color.Yellow;
                        break;
                    case 3:
                        color = Color.Green;
                        break;
                    case 4:
                        color = Color.Indigo;
                        break;
                    case 5:
                        color = Color.Lime;
                        break;
                }
                for (int j = 0; j < 7; j++)
                {
                    Brick brick = new Brick(game, spriteBatch, brickTex, Shared.stage, brickInit, color);
                    brickWall.Add(brick);
                    brickInit.X += brickTex.Width + 5;
                }
                brickInit.X = Shared.stage.X - 780;
                brickInit.Y += brickTex.Height + 5;
            }

            //Explosion
            Texture2D explosionTex = game.Content.Load<Texture2D>("Images/explosion");
            SoundEffect explosionSound = game.Content.Load<SoundEffect>("Sounds/explosion");
            explosion = new Explosion(game, spriteBatch, explosionTex,
                Vector2.Zero, 3);

            //Score
            SpriteFont scoreFont = Game.Content.Load<SpriteFont>("Fonts/messagefont");
            scoreInitPos= new Vector2(Shared.stage.X - 780, Shared.stage.Y -50);
            message = "Current Score: " + currScore;
            score = new Score(game, spriteBatch, scoreFont, scoreInitPos, message, currScore, Color.AntiqueWhite);
        
            //CollisionManager
            cm = new CollisionManager(game, bat, ball, explosion, explosionSound, score, brickWall);

            //Run 
            this.Components.Add(sb);
            this.Components.Add(sb2);          
            this.Components.Add(bat);
            foreach (var brick in brickWall)
            {
                this.Components.Add(brick);
            }
            this.Components.Add(ball);
            this.Components.Add(explosion);
            this.Components.Add(score);
            this.Components.Add(cm);
            this.Components.Add(go);
            go.hide();
        }
    }
}
