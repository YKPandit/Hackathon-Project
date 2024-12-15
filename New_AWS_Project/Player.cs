namespace New_AWS_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Player
{
    private Game1 player;
    private Texture2D playerTexture;
    private Vector2 playerPosition;
    private float width;

    
    public Rectangle PositionRectangle
    {
        get
        {
            return new Rectangle((int)playerPosition.X, (int)playerPosition.Y, (int)width, (int)width);
        }
    }
    public Player(Game1 player, Vector2 position)
    {
        this.player = player;
        this.playerPosition = position;
        this.width = 10.0f;

        LoadContent();
    }
    
    public void LoadContent()
    {
        playerTexture = player.Content.Load<Texture2D>("priest1_v1_1");
    }
    
    public void Update(GameTime gameTime)
    {

    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(playerTexture, PositionRectangle, Color.White);
    }


}