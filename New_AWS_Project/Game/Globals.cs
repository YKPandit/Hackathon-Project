// Global Helper things
namespace New_AWS_Project;

public static class Globals
{

    public static Game1 game1 { get; set; }
    public static ContentManager Content { get; set; }
    public static float totalSeconds { get; set; }
    public static SpriteBatch _spriteBatch { get; set; }
    public static GraphicsDeviceManager _graphics;
    public static Camera _camera { get; set; }

    //desired Game resolution
    public static Vector2 _resolution = new Vector2(640, 360);

    // actual render resolution
    public static Vector2 _screenSize { get; set; }
    
    public static void Update(GameTime gameTime)
    {
        totalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}