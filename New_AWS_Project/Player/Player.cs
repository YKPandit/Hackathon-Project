namespace New_AWS_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

public class Player
{
    private Game1 player;
    private Texture2D playerTexture;
    private Vector2 playerPosition;
	private float moveSpeed = 4.0f;
	private Item[] inventory = new Item[5];
	private int lastSlot = 0;
	private int currentSlot = 0;
	private SpriteEffects spriteEffect = SpriteEffects.None;
	private KeyboardState previousState = Keyboard.GetState();

	private int screenWidth;
	private int screenHeight;

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
    public Player(Game1 player, Vector2 position)
    {
        this.player = player;
        this.playerPosition = position;
		
		
		screenWidth = player.GraphicsDevice.Viewport.Width;
		screenHeight = player.GraphicsDevice.Viewport.Height;
		inventoryPosition = new Vector2(screenWidth-75, screenHeight-29);

		inventorySlots[0] = new Vector2(inventoryPosition.X + 12, inventoryPosition.Y + 14);
		for(int i = 1; i < 4; i++)
		{
			inventorySlots[i] = new Vector2(inventorySlots[i-1].X + 17, inventorySlots[i-1].Y);
		}
        LoadContent();
    }
    

	// Generation of player
    public void LoadContent()
    {
        playerTexture = player.Content.Load<Texture2D>("priest1_v1_1");
		inventorySprite = player.Content.Load<Texture2D>("Sample-InventorySlotsSet_Single");
    }
    
    public void Update(GameTime gameTime, Matrix transformMatrix)
    {
		KeyboardState currentKeyboardState = Keyboard.GetState();
		mousePosition(Matrix.Invert(transformMatrix));
    	playerMovement(currentKeyboardState);
		Inventory(currentKeyboardState);
		
		ClampToScreen();
	    if (inventory[currentSlot] != null)
	    { 
		    inventory[currentSlot].Update(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
	    }
    }

	public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(playerTexture, playerPosition, null, Color.White, 0f, Vector2.Zero, 1f, spriteEffect, 0f);
		spriteBatch.Draw(inventorySprite, inventoryPosition, Color.White);
		for(int i = 0; i < 4; i++)
		{
			if(inventorySprites[i] != null)
			{
				spriteBatch.Draw(inventorySprites[i], inventorySlots[i], null, Color.White, 0f, Vector2.Zero, new Vector2(0.2f,0.2f), SpriteEffects.None, 0f);
			}
			
		}
    }
	
    
	// Player Movement
	private void playerMovement(KeyboardState currentKey)
	{
		// Movement checking
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
	

	
	private void Inventory(KeyboardState currentKey){
		if (currentKey.IsKeyDown(Keys.E) && !previousState.IsKeyDown(Keys.E) && inventory[currentSlot] != null)
		{
			drop();
		}
		previousState = currentKey;

        if (currentKey.IsKeyDown(Keys.D1))
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
        if (currentKey.IsKeyDown(Keys.D2))
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
        if (currentKey.IsKeyDown(Keys.D3))
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
        if (currentKey.IsKeyDown(Keys.D4))
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
        if (currentKey.IsKeyDown(Keys.D5))
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

    private void mousePosition(Matrix transformMatrix)
    {
        Vector2 currentMousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
		Vector2 globalMousePosition = Vector2.Transform(currentMousePosition, transformMatrix);

        // The mouse x and y positions are returned relative to the
        // upper-left corner of the game window
        if(playerPosition.X + playerTexture.Width/2f < globalMousePosition.X)
		{
			spriteEffect = SpriteEffects.None;
		}
		else if(playerPosition.X + playerTexture.Width/2f > globalMousePosition.X)
		{
			spriteEffect = SpriteEffects.FlipHorizontally;
		}

		inventory[currentSlot]?.mousePosition(globalMousePosition);
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

	

	// In your Update method, after movement calculation but before setting final position:
	private void ClampToScreen()
	{
    	// Assuming playerPosition is your Vector2 position
    	// And playerTexture is your player's texture
    	float minX = playerTexture.Width / 2f;
    	float minY = playerTexture.Height / 2f;
    	float maxX = screenWidth - (playerTexture.Width / 2f);
    	float maxY = screenHeight - (playerTexture.Height / 2f);

    	playerPosition.X = Math.Clamp(playerPosition.X, minX, maxX);
    	playerPosition.Y = Math.Clamp(playerPosition.Y, minY, maxY);
	}

}