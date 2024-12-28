// Global Helper things
namespace New_AWS_Project;

public static class Globals
{

    public static Game1 game1 { get; set; }
    public static ContentManager Content { get; set; }
    public static float totalSeconds { get; set; }
    public static SpriteBatch _spriteBatch { get; set; }
    public static Matrix _screenScaleMatrix { get; set; }

    //desired Game resolution
    public static int _resolutionWidth = 640;
    public static int _resolutionHeight = 360;

    // actual render resolution
    public static int screenWidth { get; set; }
    public static int screenHeight { get; set; }
    
    public static void Update(GameTime gameTime)
    {
        totalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}