namespace New_AWS_Project;

public class Player
{
    private Texture2D playerTexture;
    private Vector2 playerPosition;
	private int moveSpeed = 200;
	private Item[] inventory = new Item[5];
	private int lastSlot = 0;
	private int currentSlot = 0;
	private SpriteEffects spriteEffect = SpriteEffects.None;
	private Texture2D inventorySprite;
	private Vector2 inventoryPosition;
	private Vector2[] inventorySlots = new Vector2[4];
	private Texture2D[] inventorySprites = new Texture2D[4];

    
   
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
    }
    
    public void Update(GameTime gameTime)
    {
    	playerMovement();
		Inventory();
		
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
    }

	public void Draw(GameTime gameTime)
    {
        Globals._spriteBatch.Draw(playerTexture, playerPosition, null, Color.White, 0f, Vector2.Zero, 1f, spriteEffect, 0f);
        Globals._spriteBatch.Draw(inventorySprite, inventoryPosition, Color.White);
		
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
	
    
	// Player Movement
	private void playerMovement()
	{
		// Movement checking
		if (InputManager.Direction != Vector2.Zero)
		{
			var dir = Vector2.Normalize(InputManager.Direction);

			playerPosition += dir * moveSpeed * Globals.totalSeconds;

		}

		// Screen boundaries
		if (playerPosition.X < 0)
        {
            playerPosition.X = 0;
        }
		if (playerPosition.Y < 0)
		{
			playerPosition.Y = 0;
		}
		if (playerPosition.X > Globals.screenWidth - playerTexture.Width)
		{
			playerPosition.X = Globals.screenWidth - playerTexture.Width;
		}
		if (playerPosition.Y > Globals.screenHeight - playerTexture.Height)
		{
			playerPosition.Y = Globals.screenHeight - playerTexture.Height;
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

		bool swapping = false;
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D1))
        {
			swapping = true;
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
			swapping = false;
        }
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D2))
        {
			swapping = true;
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
			swapping = false;
        }
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D3))
        {
			swapping = true;
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
			swapping = false;
        }
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D4))
        {
			swapping = true;
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
			swapping = false;
        }
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D5))
        {
			swapping = true;
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
			swapping = false;
        }
	}

    public void pickUp(Item item)
    {
	    if (lastSlot < 4 && Keyboard.GetState().IsKeyDown(Keys.Q))
	    {
			inventorySprites[lastSlot] = item.getTexture();
		    inventory[lastSlot] = item;
		    item.pickedUpItem();
		    lastSlot++;
			
	    }
    }

    public void drop()
    {
	    Item droppedItem = inventory[currentSlot];
	    inventory[currentSlot] = null;
	    inventorySprites[currentSlot] = null;
	    
	    
	    if (currentSlot < 5 && inventory[currentSlot + 1] != null)
	    {
		    currentSlot += 1;
	    }
	    else if (currentSlot > 0 && inventory[currentSlot - 1] != null)
	    {
		    currentSlot -= 1;
			lastSlot--;
	    }
	    else
	    {
		    currentSlot = 0;
			lastSlot--;
	    }
		
		droppedItem.setPosition(new Vector2(playerPosition.X + 100, playerPosition.Y));
	    droppedItem.pickedUp = false;
    }
}