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
    public class CollisionManager : GameComponent
    {
        private Bat bat;
        private Ball ball;
        private SoundEffect explosionSound;
        private Explosion explosion;
        private Score score;
        private List<Brick> brickWall;
        public CollisionManager(Game game,
            Bat bat,
            Ball ball,
            Explosion explosion,
            SoundEffect explosionSound, Score score, List<Brick> brickWall) : base(game)
        {
            this.bat = bat;
            this.ball = ball;
            this.explosion = explosion;
            this.explosionSound = explosionSound;
            this.score = score;
            this.brickWall = brickWall;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle ballRect = ball.getBound();
            Rectangle batRect = bat.getBound();
            if (ballRect.Intersects(batRect))
            {
                ball.speed = new Vector2(ball.speed.X, -Math.Abs(ball.speed.Y));
            }
            for(int i = 0; i < brickWall.Count; i++)
            {
                Rectangle brickRect = brickWall[i].getBound();
                if (ballRect.Intersects(brickRect))
                {
                    brickWall[i].createRects();

                    if (ballRect.Intersects(brickWall[i].bottomRect))
                    {
                        ball.speed = new Vector2(ball.speed.X, Math.Abs(ball.speed.Y));
                    }
                    if (ballRect.Intersects(brickWall[i].upperRect))
                    {
                        ball.speed = new Vector2(ball.speed.X, -Math.Abs(ball.speed.Y));
                    }
                    if (ballRect.Intersects(brickWall[i].leftRect))
                    {
                        ball.speed = new Vector2(-Math.Abs(ball.speed.X), ball.speed.Y);
                    }
                    if (ballRect.Intersects(brickWall[i].rightRect))
                    {
                        ball.speed = new Vector2(Math.Abs(ball.speed.X), ball.speed.Y);
                    }
                    explosionSound.Play();
                    explosion.Position = ball.position;
                    explosion.startAnimation();
                    brickWall[i].hide();
                    brickWall.RemoveAt(i);
                    score.getScore();
                }
            }
            base.Update(gameTime);
        }
    }
}
