namespace New_AWS_Project;

public class Player
{
    private Texture2D playerTexture;
    private Vector2 playerPosition;
	private int moveSpeed = 200;
	private SpriteEffects spriteEffect = SpriteEffects.None;
	private Inventory inventory = new Inventory();

	// Health
	private int playerHealth = 100;
	private float healthScale = 0.75f;
	private Vector2 healthScaleVector = new Vector2(0.75f, 0.75f);
	private Texture2D healthBar;
	private Vector2 healthBarPosition = Vector2.Zero;
	private Texture2D healthBarUI;

    
   
    public Rectangle PositionRectangle
    {
        get
        {
            return new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerTexture.Width, playerTexture.Height);
        }
    }
    public Player(Vector2 position)
    {
        this.playerPosition = position;
        LoadContent();
    }
    

	// Generation of player
    public void LoadContent()
    {
        playerTexture = Globals.Content.Load<Texture2D>("priest1_v1_1");
		healthBar = Globals.Content.Load<Texture2D>("health");
		healthBarUI = Globals.Content.Load<Texture2D>("health ui");
    }
    
    public void Update()
    {
    	playerMovement();
		inventory.Update(playerPosition + new Vector2(playerTexture.Width/2, playerTexture.Height/2));
    }

	public void Draw()
    {
        Globals._spriteBatch.Draw(playerTexture, playerPosition, null, Color.White, 0f, Vector2.Zero, 1f, spriteEffect, 0f);
        Globals._spriteBatch.Draw(healthBarUI, healthBarPosition, Color.White);
        Globals._spriteBatch.Draw(healthBar, new Vector2(25, 4.375f), null, Color.White, 0f, Vector2.Zero, healthScaleVector, SpriteEffects.None, 0f);
		inventory.Draw();
    }

	public Vector2 getPosition()
	{
		return playerPosition;
	}
    
	// Player Movement
	private void playerMovement()
	{
		// Movement checking
		if (InputManager.Direction != Vector2.Zero)
		{
			var dir = Vector2.Normalize(InputManager.Direction);

			playerPosition = new(MathHelper.Clamp (playerPosition.X + (dir.X * moveSpeed * Globals.totalSeconds), 0, Globals._resolutionWidth - playerTexture.Width),
								MathHelper.Clamp (playerPosition.Y + (dir.Y * moveSpeed * Globals.totalSeconds), 0, Globals._resolutionHeight - playerTexture.Height));
		}


		// Player Sprite flipping and Item rotation based on mouse
		if(playerPosition.X + playerTexture.Width/2f < InputManager.MousePosition.X)
		{
			spriteEffect = SpriteEffects.None;
		}
		else if(playerPosition.X + playerTexture.Width/2f > InputManager.MousePosition.X)
		{
			spriteEffect = SpriteEffects.FlipHorizontally;
		}
	}
    public void playerDamage(int damage)
    {
	    playerHealth -= damage;
	    healthScale -= damage/100f;
	    healthScaleVector = new Vector2(healthScale, healthScaleVector.Y);
    }

	public void pickUp(Item item)
    {
	    if (!inventory.inventoryFull && Keyboard.GetState().IsKeyDown(Keys.Q))
	    {
			int slot = 0;
			while (inventory.inventory[slot] != null)
			{
				slot++;
				if (slot == 4)
				{
					inventory.inventoryFull = true;
					break;
				}
			}
			inventory.inventorySprites[slot] = item.getTexture();
		    inventory.inventory[slot] = item;
		    item.pickedUpItem();
			if (slot == inventory.currentSlot){
				inventory.inventory[slot].setPosition(playerPosition + new Vector2(playerTexture.Width/2, playerTexture.Height/2));
			}

	    }
    }
}