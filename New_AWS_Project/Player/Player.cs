namespace New_AWS_Project;

public class Player
{
    private Texture2D playerTexture;
    private Vector2 playerPosition;
	private int moveSpeed = 200;
	private SpriteEffects spriteEffect = SpriteEffects.None;

	// Inventory
	private Item[] inventory = new Item[5];
	private int currentSlot = 0;
	private Texture2D inventorySprite;
	private Vector2 inventoryPosition;
	private Vector2[] inventorySlots = new Vector2[4];
	private Texture2D[] inventorySprites = new Texture2D[4];
	private bool inventoryFull = false;

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
		inventorySprite = Globals.Content.Load<Texture2D>("Sample-InventorySlotsSet_Single");
		healthBar = Globals.Content.Load<Texture2D>("health");
		healthBarUI = Globals.Content.Load<Texture2D>("health ui");
    }
    
    public void Update()
    {
    	playerMovement();
		Inventory();
		
		// This shit is ass, gotta fix it
		if(inventoryPosition.X == 0)
		{
			inventoryPosition = new Vector2(Globals.screenWidth - 75, (int)(Globals.screenHeight) - 29);

			inventorySlots[0] = new Vector2(inventoryPosition.X + 5, inventoryPosition.Y + 7);
			for(int i = 1; i < 4; i++)
			{
				inventorySlots[i] = new Vector2(inventorySlots[i-1].X + 17, inventorySlots[i-1].Y);
			}
		}
		
	    if (inventory[currentSlot] != null)
	    { 
		    inventory[currentSlot].Update(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
	    }
		
	    // playerDamage(1);
    }

	public void Draw()
    {
        Globals._spriteBatch.Draw(playerTexture, playerPosition, null, Color.White, 0f, Vector2.Zero, 1f, spriteEffect, 0f);
        Globals._spriteBatch.Draw(inventorySprite, inventoryPosition, Color.White);
        Globals._spriteBatch.Draw(healthBarUI, healthBarPosition, Color.White);
        Globals._spriteBatch.Draw(healthBar, new Vector2(25, 4.375f), null, Color.White, 0f, Vector2.Zero, healthScaleVector, SpriteEffects.None, 0f);
		
		for(int i = 0; i < 4; i++)
		{
			if(inventorySprites[i] != null)
			{
				Vector2 scale = new Vector2(15/inventorySprites[i].Width, 15/inventorySprites[i].Height);
				Globals._spriteBatch.Draw(
		            inventorySprites[i],
		            inventorySlots[i],
		            null,
		            Color.White ,
		            45,
		            Vector2.Zero,
		            0.67f,
		            spriteEffect,
		            0f
				);
			}
			
		}
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

		inventory[currentSlot]?.mousePosition(InputManager.MousePosition);
	}
	

	
	private void Inventory(){
		
		if (!InputManager._previousKeyboardState.IsKeyDown(Keys.E) && InputManager._currentKeyboardState.IsKeyDown(Keys.E) && inventory[currentSlot] != null)
		{
			drop();
		}

        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D1))
        {
	        int oldSlot = currentSlot == 0? -1 : currentSlot;
	        currentSlot = 0;
	        if (inventory[currentSlot] != null)
	        {
		        inventory[currentSlot].setPosition(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
	        }
	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }

        }
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D2))
        {

	        int oldSlot = currentSlot != 1? currentSlot:-1;
	        currentSlot = 1;
	        if (inventory[currentSlot] != null)
	        {
		        inventory[currentSlot].setPosition(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
	        }
	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }
        }
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D3))
        {

	        int oldSlot = currentSlot != 2? currentSlot:-1;
	        currentSlot = 2;
	        if (inventory[currentSlot] != null)
	        {
		        inventory[currentSlot].setPosition(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
	        }
	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }
        }
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D4))
        {

	        int oldSlot = currentSlot != 3? currentSlot:-1;
	        currentSlot = 3;
	        if (inventory[currentSlot] != null)
	        {
		        inventory[currentSlot].setPosition(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
	        }
	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }

        }
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D5))
        {

	        int oldSlot = currentSlot != 4? currentSlot:-1;
	        currentSlot = 4;
	        if (inventory[currentSlot] != null)
	        {
		        inventory[currentSlot].setPosition(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
	        }
	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }

        }
	}

    public void pickUp(Item item)
    {
	    if (!inventoryFull && Keyboard.GetState().IsKeyDown(Keys.Q))
	    {
			int slot = 0;
			while (inventory[slot] != null)
			{
				slot++;
				if (slot == 4)
				{
					inventoryFull = true;
					break;
				}
			}
			inventorySprites[slot] = item.getTexture();
		    inventory[slot] = item;
		    item.pickedUpItem();
	    }
    }

    public void drop()
    {
	    Item droppedItem = inventory[currentSlot];
	    inventory[currentSlot] = null;
	    inventorySprites[currentSlot] = null;

		inventoryFull = false;
		
		droppedItem.setPosition(new Vector2(playerPosition.X + 100, playerPosition.Y));
	    droppedItem.pickedUp = false;
    }

    public void playerDamage(int damage)
    {
	    playerHealth -= damage;
	    healthScale -= damage/100f;
	    healthScaleVector = new Vector2(healthScale, healthScaleVector.Y);
    }
}