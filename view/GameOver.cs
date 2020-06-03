using SFML.Graphics;
using SFML.System;

namespace TowerDefence
{
    public class GameOver : Transformable, Drawable
    {
        public static RectangleShape Background;
        public static Text GameOverLabel;
        public static Text ScoreLabel;
        public static RectangleShape NewGameButton;
        public static RectangleShape MainMenuButton;

        public GameOver()
        {
            Background = new RectangleShape()
            {
                Size = new Vector2f(Config.ScreenWidth, Config.ScreenHeight),
                FillColor = Color.Blue,
            };
            
            GameOverLabel = new Text()
            {
                Font = Sources.FPSfont,
                DisplayedString = "YOU'RE FUCKING DAED NIGGA",
                CharacterSize = 100,
                Position = new Vector2f(100, 100)
            };
            
            ScoreLabel = new Text()
            {
                Font = Sources.FPSfont,
                DisplayedString = "YOUR SCORE IS: 0, YOU BITCH",
                CharacterSize = 70,
                Position = new Vector2f(150, 250)
            };            
        }

        public static void setScore(int score)
        {
            return;
        }
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(Background);
            target.Draw(GameOverLabel);
            target.Draw(ScoreLabel);
        }
    }
}