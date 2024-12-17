namespace New_AWS_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class Player
{
    private Game1 player;
    private Texture2D playerTexture;
    private Vector2 playerPosition;
	private float moveSpeed = 4.0f;
	private Item[] inventory = new Item[5];
	private int lastSlot = 0;
	private SpriteEffects spriteEffect = SpriteEffects.None;

   
    public Rectangle PositionRectangle
    {
        get
        {
            return new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerTexture.Width, playerTexture.Height);
        }
    }
    public Player(Game1 player, Vector2 position)
    {
        this.player = player;
        this.playerPosition = position;

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
		mousePosition();
    	playerMovement(currentKeyboardState);
    }

	public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(playerTexture, playerPosition, null, Color.White, 0f, Vector2.Zero, 1f, spriteEffect, 0f);
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
        MouseState current_mouse = Mouse.GetState();

        // The mouse x and y positions are returned relative to the
        // upper-left corner of the game window.

        if(playerPosition.X + playerTexture.Width/2 < current_mouse.X)
		{
			spriteEffect = SpriteEffects.None;
		}
		else if(playerPosition.X + playerTexture.Width/2 > current_mouse.X)
		{
			spriteEffect = SpriteEffects.FlipHorizontally;
		}
    }
}