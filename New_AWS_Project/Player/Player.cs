namespace New_AWS_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player
{
    private Game1 player;
    private Texture2D playerTexture;
    private Vector2 playerPosition;
    private float width;
	private float moveSpeed = 4.0f;

    
    public Rectangle PositionRectangle
    {
        get
        {
            return new Rectangle((int)playerPosition.X, (int)playerPosition.Y, (int)width, (int)SpriteHeight);
        }
    }
    public Player(Game1 player, Vector2 position)
    {
        this.player = player;
        this.playerPosition = position;
        this.width = 10.0f;

        LoadContent();
    }
    

	// Generation of player
    public void LoadContent()
    {
        playerTexture = player.Content.Load<Texture2D>("priest1_v1_1");
    }
    
    public void Update(GameTime gameTime)
    {
		KeyboardState currentKeyboardState = Keyboard.GetState();
    	playerMovement(currentKeyboardState);
    }

	public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(playerTexture, PositionRectangle, Color.White);
    }
	
	// Height of the player sprite
	public float SpriteHeight
    {
        get
        {
            float scale = width / playerTexture.Width;
            return playerTexture.Height * scale;
        }
    }

    
	// Player Movement
	private void playerMovement(KeyboardState currentKey)
	{
		if (currentKey.IsKeyDown(Keys.W))
        {
            playerPosition.Y -= moveSpeed;
        }
        if (currentKey.IsKeyDown(Keys.S))
        {
            playerPosition.Y += moveSpeed;
        }
        if (currentKey.IsKeyDown(Keys.A))
        {
            playerPosition.X -= moveSpeed;
        }
        if (currentKey.IsKeyDown(Keys.D))
        {
            playerPosition.X += moveSpeed;
        }
	}


    private void mousePosition()
    {
        
    }
}